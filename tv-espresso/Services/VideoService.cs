using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using tv_espresso.Models;

namespace tv_espresso.Services
{
    public class VideoService
    {
        public readonly string rootPath;
        private readonly IMongoCollection<Video> videosCollection;
        private static readonly ConcurrentDictionary<string, SemaphoreSlim> locks = new();

        public VideoService(IConfiguration configuration)
        {
            rootPath = configuration["TvEspressoRoot"]!;
            var mongoClient = new MongoClient(configuration["TvEspressoDatabase:ConnectionString"]);
            var mongoDatabase = mongoClient.GetDatabase(configuration["TvEspressoDatabase:DatabaseName"]);
            videosCollection = mongoDatabase.GetCollection<Video>(configuration["TvEspressoDatabase:VideosCollectionName"]);
        }

        private static List<Video> OrderFilmsAndSeries(List<Video> videos, bool skipVeselja = true)
        {
            int i;
            List<Video> ordered = new List<Video>();
            foreach (var video in videos)
            {
                if (skipVeselja && video.Genres.Any(g => g.Equals("veselja", StringComparison.CurrentCultureIgnoreCase)))
                    continue;
                if (video.Episode == 0)
                    ordered.Add(video);
                else
                {
                    Video? theSeries = null;
                    if ((theSeries = ordered.Find(v => v.Title == video.Title && v.Director == video.Director && v.Actors.Length == video.Actors.Length)) == null)
                    {
                        theSeries = new Video
                        {
                            Id = "TVS" + video.Id,
                            Title = video.Title,
                            Uri = "",
                            TranslatedTitle = video.TranslatedTitle,
                            Year = video.Year,
                            CoverUri = video.CoverUri,
                            ThemeUri = video.ThemeUri,
                            Director = video.Director,
                            Actors = video.Actors,
                            Genres = video.Genres,
                            VideoFhd = video.VideoFhd,
                            Season = 0,
                            Episode = 0,
                            EpisodeTitle = "",
                            SubtitleEngUri = "",
                            SubtitleSrbUri = "",
                            TranslatedEpisodeTitle = "",
                            Uri4k = "",
                            Series = []
                        };
                        ordered.Add(theSeries);
                    }
                    Video dummy = new Video { Id = "", Title = video.Title, Uri = "" };
                    for (i = theSeries.Series.Count; i < video.Season; ++i)
                        theSeries.Series.Add([]);
                    for (i = theSeries.Series[video.Season - 1].Count; i < video.Episode; ++i)
                        theSeries.Series[video.Season - 1].Add(dummy);
                    theSeries.Series[video.Season - 1][video.Episode - 1] = video;
                }
            }
            foreach (var video in ordered)
            {
                if (video.Uri == "")
                {
                    video.Year = video.Series[0][0].Year;
                    video.CoverUri = video.Series[0][0].CoverUri;
                    video.ThemeUri = video.Series[0][0].ThemeUri;
                }
            }
            return ordered;
        }

        public async Task<List<Video>> GetAsync() => OrderFilmsAndSeries(await videosCollection.Find(_ => true).ToListAsync());

        public async Task<List<Video>> GetMatchingAsync(string phrase)
        {
            var filterBuilder = Builders<Video>.Filter;
            var filter = filterBuilder.Text(phrase);
            var sort = Builders<Video>.Sort.MetaTextScore("score");

            return OrderFilmsAndSeries(await videosCollection.Find(filter).Sort(sort).ToListAsync());
        }

        public async Task<List<Video>> GetByGenreAsync(string genre)
        {
            return OrderFilmsAndSeries(await videosCollection.AsQueryable().Where(v => v.Genres.Any(g => g.Equals(genre, StringComparison.CurrentCultureIgnoreCase))).ToListAsync(), genre != "veselja");
        }

        public async Task<List<Video>> GetByDirectorAsync(string director)
        {
            return OrderFilmsAndSeries(await videosCollection.AsQueryable().Where(v => v.Director != null && v.Director.Contains(director, StringComparison.CurrentCultureIgnoreCase)).ToListAsync());
        }

        public async Task<List<Video>> GetByActorAsync(string actor)
        {
            return OrderFilmsAndSeries(await videosCollection.AsQueryable().Where(v => v.Actors.Any(a => a.Contains(actor, StringComparison.CurrentCultureIgnoreCase))).ToListAsync());
        }

        public async Task<Video?> GetAsync(string id) => await videosCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task InsertAsync(Video newVideo) => await videosCollection.InsertOneAsync(newVideo);

        public async Task UpdateAsync(Video updatedVideo) => await videosCollection.ReplaceOneAsync(x => x.Id == updatedVideo.Id, updatedVideo);

        public async Task DeleteAsync(string id) => await videosCollection.DeleteOneAsync(x => x.Id == id);

        public TimeSpan? GetDuration(string uri)
        {
            string filePath = Path.Combine(rootPath, uri);
            if (!File.Exists(filePath))
                return null;
            try
            {
                using var tfile = TagLib.File.Create(filePath);
                TimeSpan duration = tfile.Properties.Duration;
                return duration;
            }
            catch (Exception)
            {
                return null;
            }
        }

        private static async Task<int> HasSubtitleTrackAsync(string videoPath)
        {
            var psi = new ProcessStartInfo
            {
                FileName = "ffprobe",
                Arguments =
                    $"-v error -select_streams s " +
                    "-show_entries stream=index:stream_tags=language " +
                    "-of json " +
                    $"\"{videoPath}\"",
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using var process = Process.Start(psi)!;
            var output = await process.StandardOutput.ReadToEndAsync();
            await process.WaitForExitAsync();

            using var doc = JsonDocument.Parse(output);

            if (!doc.RootElement.TryGetProperty("streams", out var streams))
                return 0;

            int subtitles = 0;
            foreach (var stream in streams.EnumerateArray())
            {
                if (stream.TryGetProperty("tags", out var tags) && tags.TryGetProperty("language", out var lang) &&
                    (string.Equals(lang.GetString(), "srp", StringComparison.OrdinalIgnoreCase) ||
                    string.Equals(lang.GetString(), "sr", StringComparison.OrdinalIgnoreCase) ||
                    string.Equals(lang.GetString(), "srb", StringComparison.OrdinalIgnoreCase)))
                    return 2;
                else
                    subtitles = 1;
            }

            return subtitles;
        }

        private static async Task RunMkvmergeAsync(string arguments)
        {
            var psi = new ProcessStartInfo
            {
                FileName = "mkvmerge",
                Arguments = arguments,
                RedirectStandardError = true,
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            var stderr = new StringBuilder();
            using var process = new Process { StartInfo = psi };
            process.ErrorDataReceived += (_, e) =>
            {
                if (!string.IsNullOrWhiteSpace(e.Data))
                    stderr.AppendLine(e.Data);
            };
            process.Start();
            process.BeginErrorReadLine();

            await process.WaitForExitAsync();

            if (process.ExitCode != 0)
                System.Console.WriteLine($"mkvmerge failed (exit code {process.ExitCode}):\n{stderr}");
        }

        public async Task<bool> EnsureEmbeddedSubtitlesAsync(string videoPath, string srtPathSr, string srtPathEn)
        {
            var sem = locks.GetOrAdd(videoPath, _ => new SemaphoreSlim(1, 1));
            await sem.WaitAsync();
            try
            {
                bool extChanged = false;
                videoPath = Path.Combine(rootPath, videoPath);
                var ext = Path.GetExtension(videoPath).ToLowerInvariant();
                if (!File.Exists(videoPath))
                    return false;

                int subtitlesCount = await HasSubtitleTrackAsync(videoPath);
                if (subtitlesCount == 2)
                    return false;

                var tempVideo = videoPath.Replace(ext, "") + "_tmp_" + ".mkv";

                if (subtitlesCount == 0 && srtPathEn != "")
                {
                    srtPathEn = Path.Combine(rootPath, srtPathEn);
                    await RunMkvmergeAsync(
                        "--compression -1:none " +
                        $"-o \"{tempVideo}\" " +
                        $"\"{videoPath}\" " +
                        "--language 0:en " +
                        "--track-name 0:English " +
                        "--default-track 0:no " +
                        $"\"{srtPathEn}\""
                    );
                    if (ext == ".mkv")
                        File.Replace(tempVideo, videoPath, null);
                    else
                    {
                        string newFileName = videoPath.Replace(ext, ".mkv");
                        File.Move(tempVideo, newFileName, true);
                        File.Delete(videoPath);
                        ext = ".mkv";
                        videoPath = newFileName;
                        extChanged = true;
                    }
                    await Task.Delay(1000);
                }
                if (srtPathSr != "")
                {
                    srtPathSr = Path.Combine(rootPath, srtPathSr);
                    await RunMkvmergeAsync(
                        "--compression -1:none " +
                        $"-o \"{tempVideo}\" " +
                        $"\"{videoPath}\" " +
                        "--language 0:sr " +
                        "--track-name 0:Serbian " +
                        "--default-track 0:yes " +
                        $"\"{srtPathSr}\""
                    );
                    if (ext == ".mkv")
                        File.Replace(tempVideo, videoPath, null);
                    else
                    {
                        string newFileName = videoPath.Replace(ext, ".mkv");
                        File.Move(tempVideo, newFileName, true);
                        File.Delete(videoPath);
                        extChanged = true;
                    }
                }
                return extChanged;
            }
            finally
            {
                sem.Release();
            }
        }
    }
}
