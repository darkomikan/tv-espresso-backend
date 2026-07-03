using System.Windows.Forms;
using System.IO;
using tv_espresso.Models;
using System.Text.RegularExpressions;
using System.Text.Json;
using System.Threading.Tasks;
using System.Net.Http.Json;

namespace tv_espresso_admin
{
    public partial class Form1 : Form
    {
        private bool initialDirectorySet = false;
        private string root = "";
        private Video video = new Video { Id = "", Title = "", Uri = "" };
        private List<Video> videosInDb = new List<Video>();
        private static readonly HttpClient http = new HttpClient();

        public Form1()
        {
            InitializeComponent();
        }

        private async Task fetchVideosInDbAsync()
        {
            try
            {
                //videosInDb = (await http.GetFromJsonAsync<List<Video>>("http://home.darkomikan.com:7080/api/video/getall"))!;
                videosInDb = (await http.GetFromJsonAsync<List<Video>>("http://192.168.10.100:7080/api/video/getall"))!;
                videosInDb ??= new List<Video>();
                previousTitleTextBox.AutoCompleteCustomSource = [.. videosInDb.Select(v => v.Title)];
            }
            catch (HttpRequestException ex)
            {
                resTextArea.Text = ex.Message;
            }
        }

        private void selectRootButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                root = folderBrowserDialog.SelectedPath;
                rootTextBox.Text = root;
                selectVideoButton.Enabled = true;
                selectShowButton.Enabled = true;

                createButton.Enabled = true;
                select4kUriButton.Enabled = true;
                selectCoverUriButton.Enabled = true;
                selectThemeUriButton.Enabled = true;
                selectSubtitleEnButton.Enabled = true;
                selectSubtitleSrButton.Enabled = true;
                remove4kUriButton.Enabled = true;
                removeCoverUriButton.Enabled = true;
                removeThemeUriButton.Enabled = true;
                removeSubtitleSrButton.Enabled = true;
                removeSubtitleEnButton.Enabled = true;
            }
        }

        private async void selectVideoButton_Click(object sender, EventArgs e)
        {
            await fetchVideosInDbAsync();
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (!initialDirectorySet)
            {
                openFileDialog.InitialDirectory = root;
                initialDirectorySet = true;
            }
            openFileDialog.RestoreDirectory = true;
            openFileDialog.Filter = "Video Files|*.avi;*.mov;*.mp4;*.vob;*.wmv;*.mkv|All Files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                video.Uri = Path.GetRelativePath(root, openFileDialog.FileName);
                uriTextBox.Text = video.Uri;

                string sPattern = @"S\d{2}";
                string ePattern = @"E\d{2}";
                string yPattern = @"\(\d{4}\)";

                Match sMatch = Regex.Match(openFileDialog.SafeFileName, sPattern, RegexOptions.IgnoreCase);
                Match eMatch = Regex.Match(openFileDialog.SafeFileName, ePattern, RegexOptions.IgnoreCase);
                Match yMatch = Regex.Match(Path.GetDirectoryName(video.Uri)!, yPattern);

                coverUriTextBox.Text = "";
                uri4kTextBox.Text = "";
                subtitleEnTextBox.Text = "";
                subtitleSrTextBox.Text = "";
                skipSegmentsTextBox.Text = "";
                previousTitleTextBox.Text = "";
                if (sMatch.Success)
                {
                    seasonNumeric.Value = int.Parse(sMatch.Value[1..].TrimStart('0'));
                    if (eMatch.Success)
                    {
                        episodeNumeric.Value = int.Parse(eMatch.Value[1..].TrimStart('0'));
                        episodeTitleTextBox.Text = openFileDialog.SafeFileName.Substring(openFileDialog.SafeFileName.IndexOf(eMatch.Value) + 3,
                            openFileDialog.SafeFileName.Length - 4 - openFileDialog.SafeFileName.IndexOf(eMatch.Value) - 3);
                        if (episodeTitleTextBox.Text.Contains("720p"))
                            episodeTitleTextBox.Text = episodeTitleTextBox.Text[..episodeTitleTextBox.Text.IndexOf("720p")];
                        if (episodeTitleTextBox.Text.Contains("1080p"))
                            episodeTitleTextBox.Text = episodeTitleTextBox.Text[..episodeTitleTextBox.Text.IndexOf("1080p")];
                        if (episodeTitleTextBox.Text.Contains("(480p"))
                            episodeTitleTextBox.Text = episodeTitleTextBox.Text[..episodeTitleTextBox.Text.IndexOf("(480p")];
                        episodeTitleTextBox.Text = episodeTitleTextBox.Text.Replace('.', ' ').Trim();
                        if (episodeTitleTextBox.Text[..2] == "- ")
                            episodeTitleTextBox.Text = episodeTitleTextBox.Text[2..];

                        titleTextBox.Text = Path.GetDirectoryName(Path.GetDirectoryName(video.Uri));
                    }
                }
                else
                {
                    seasonNumeric.Value = 0;
                    episodeNumeric.Value = 0;
                    episodeTitleTextBox.Text = "";
                    translatedEpisodeTitleTextBox.Text = "";
                    titleTextBox.Text = Path.GetDirectoryName(video.Uri);
                    if (yMatch.Success)
                    {
                        yearNumeric.Value = int.Parse(yMatch.Value[1..^1]);
                        titleTextBox.Text = titleTextBox.Text[..titleTextBox.Text.IndexOf(yMatch.Value)].Trim();
                    }
                }
                if (titleTextBox.Text.Contains(Path.DirectorySeparatorChar))
                    titleTextBox.Text = titleTextBox.Text[(titleTextBox.Text.LastIndexOf(Path.DirectorySeparatorChar) + 1)..];

                string[] files = Directory.GetFiles(Path.GetDirectoryName(openFileDialog.FileName)!);
                IEnumerable<string> covers = files.Where(f => Path.GetExtension(f) == ".jpg" || Path.GetExtension(f) == ".jpeg" || Path.GetExtension(f) == ".png");
                if (covers.Any())
                    coverUriTextBox.Text = Path.GetRelativePath(root, covers.ElementAt(0));
                IEnumerable<string> themes = files.Where(f => Path.GetExtension(f) == ".mp3");
                if (themes.Any())
                    themeUriTextBox.Text = Path.GetRelativePath(root, themes.ElementAt(0));

                if (!eMatch.Success)
                {
                    IEnumerable<string> srts = files.Where(f => Path.GetExtension(f) == ".srt");
                    if (srts.Any())
                        subtitleSrTextBox.Text = Path.GetRelativePath(root, srts.ElementAt(0));
                }
                else
                {
                    IEnumerable<string> srts = files.Where(f => Path.GetExtension(f) == ".srt" && f.Contains(eMatch.Value, StringComparison.CurrentCultureIgnoreCase));
                    if (srts.Any())
                        subtitleSrTextBox.Text = Path.GetRelativePath(root, srts.ElementAt(0));
                }
            }
        }

        private async void selectShowButton_Click(object sender, EventArgs e)
        {
            await fetchVideosInDbAsync();
            FolderBrowserDialog showBrowserDialog = new FolderBrowserDialog();

            if (showBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                videoList.Items.Clear();
                coverUriTextBox.Text = "";
                uri4kTextBox.Text = "";
                subtitleEnTextBox.Text = "";
                subtitleSrTextBox.Text = "";
                skipSegmentsTextBox.Text = "";
                previousTitleTextBox.Text = "";

                titleTextBox.Text = showBrowserDialog.SelectedPath;
                if (titleTextBox.Text.Contains(Path.DirectorySeparatorChar))
                    titleTextBox.Text = titleTextBox.Text[(titleTextBox.Text.LastIndexOf(Path.DirectorySeparatorChar) + 1)..];

                string[] files = Directory.GetFiles(showBrowserDialog.SelectedPath);
                IEnumerable<string> themes = files.Where(f => Path.GetExtension(f) == ".mp3");
                if (themes.Any())
                    themeUriTextBox.Text = Path.GetRelativePath(root, themes.ElementAt(0));

                string[] folders = Directory.GetDirectories(showBrowserDialog.SelectedPath);
                IEnumerable<string> seasons = folders.Where(f => f[(f.LastIndexOf(Path.DirectorySeparatorChar) + 1)..].StartsWith("Season"));
                foreach (var season in seasons)
                {
                    int sNumber = int.Parse(season[^2..].Trim());
                    string sCover = "";
                    files = Directory.GetFiles(season);

                    IEnumerable<string> covers = files.Where(f => Path.GetExtension(f) == ".jpg" || Path.GetExtension(f) == ".jpeg" || Path.GetExtension(f) == ".png");
                    if (covers.Any())
                        sCover = Path.GetRelativePath(root, covers.ElementAt(0));

                    IEnumerable<string> episodes = files.Where(f => Path.GetExtension(f) == ".mkv" || Path.GetExtension(f) == ".mp4" || Path.GetExtension(f) == ".wmv" || Path.GetExtension(f) == ".vob" || Path.GetExtension(f) == ".avi" || Path.GetExtension(f) == ".mov");
                    IEnumerable<string> srts = files.Where(f => Path.GetExtension(f) == ".srt");

                    foreach (var episode in episodes)
                    {
                        Video v = new Video { Id = "", Title = titleTextBox.Text, Uri = Path.GetRelativePath(root, episode) };
                        if (videosInDb.Any((item) => item.Uri == v.Uri || (item.Series is not null && item.Series.Count > 0 ? item.Series.Any((sItem) => sItem.Any((eItem) => eItem.Uri == v.Uri)) : false)))
                            continue;
                        v.Season = sNumber;
                        v.CoverUri = sCover;
                        Match eMatch = Regex.Match(episode, episodeRegexTextBox.Text, RegexOptions.IgnoreCase);
                        if (eMatch.Success)
                        {
                            v.Episode = int.Parse(new string(eMatch.Value.Where(char.IsDigit).ToArray()).TrimStart('0'));
                            v.EpisodeTitle = episode[(episode.LastIndexOf(Path.DirectorySeparatorChar) + 1)..];
                            if (titleStartsCheckBox.Checked)
                                v.EpisodeTitle = v.EpisodeTitle.Substring(v.EpisodeTitle.IndexOf(eMatch.Value) + eMatch.Length, v.EpisodeTitle.Length - 4 - v.EpisodeTitle.IndexOf(eMatch.Value) - eMatch.Length);
                            if (startsWithTextBox.Text.Length > 0 && v.EpisodeTitle.Contains(startsWithTextBox.Text))
                                v.EpisodeTitle = v.EpisodeTitle[(v.EpisodeTitle.IndexOf(startsWithTextBox.Text) + 1)..];
                            if (endsWithTextBox.Text.Length > 0 && v.EpisodeTitle.Contains(endsWithTextBox.Text))
                                v.EpisodeTitle = v.EpisodeTitle[..v.EpisodeTitle.IndexOf(endsWithTextBox.Text)];
                            if (removeDotsCheckBox.Checked)
                                v.EpisodeTitle = v.EpisodeTitle.Replace('.', ' ').Trim();
                        }

                        IEnumerable<string> eSrts = srts.Where(f => f.Contains(eMatch.Value, StringComparison.CurrentCultureIgnoreCase));
                        IEnumerable<string> engSrts = eSrts.Where(f => f.Contains(".eng", StringComparison.CurrentCultureIgnoreCase));
                        IEnumerable<string> srbSrts = eSrts.Where(f => f.Contains(".srb", StringComparison.CurrentCultureIgnoreCase));
                        if (engSrts.Any())
                        {
                            v.SubtitleEngUri = Path.GetRelativePath(root, engSrts.ElementAt(0));
                            eSrts = eSrts.Except(engSrts);
                        }
                        if (srbSrts.Any())
                        {
                            v.SubtitleSrbUri = Path.GetRelativePath(root, srbSrts.ElementAt(0));
                            eSrts = eSrts.Except(srbSrts);
                        }
                        if (eSrts.Any())
                        {
                            if (showSubtitlesEnCheckBox.Checked)
                                v.SubtitleEngUri = Path.GetRelativePath(root, eSrts.ElementAt(0));
                            else
                                v.SubtitleSrbUri = Path.GetRelativePath(root, eSrts.ElementAt(0));
                        }

                        videoList.Items.Add(v);
                    }
                }
            }
        }

        private void select4kUriButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (!initialDirectorySet)
            {
                openFileDialog.InitialDirectory = root;
                initialDirectorySet = true;
            }
            openFileDialog.RestoreDirectory = true;
            openFileDialog.Filter = "Video Files|*.avi;*.mov;*.mp4;*.wmv;*.mkv|All Files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                video.Uri4k = Path.GetRelativePath(root, openFileDialog.FileName);
                uri4kTextBox.Text = video.Uri4k;
            }
        }

        private void selectCoverUriButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (!initialDirectorySet)
            {
                openFileDialog.InitialDirectory = root;
                initialDirectorySet = true;
            }
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                video.CoverUri = Path.GetRelativePath(root, openFileDialog.FileName);
                coverUriTextBox.Text = video.CoverUri;
            }
        }

        private void selectThemeUriButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (!initialDirectorySet)
            {
                openFileDialog.InitialDirectory = root;
                initialDirectorySet = true;
            }
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                video.ThemeUri = Path.GetRelativePath(root, openFileDialog.FileName);
                themeUriTextBox.Text = video.ThemeUri;
            }
        }

        private void selectSubtitleSrButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (!initialDirectorySet)
            {
                openFileDialog.InitialDirectory = root;
                initialDirectorySet = true;
            }
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                video.SubtitleSrbUri = Path.GetRelativePath(root, openFileDialog.FileName);
                subtitleSrTextBox.Text = video.SubtitleSrbUri;
            }
        }

        private void selectSubtitleEnButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (!initialDirectorySet)
            {
                openFileDialog.InitialDirectory = root;
                initialDirectorySet = true;
            }
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                video.SubtitleEngUri = Path.GetRelativePath(root, openFileDialog.FileName);
                subtitleEnTextBox.Text = video.SubtitleEngUri;
            }
        }

        private async void createButton_Click(object sender, EventArgs e)
        {
            video.Uri = uriTextBox.Text;
            video.Title = titleTextBox.Text.Trim();
            video.TranslatedTitle = translatedTitleTextBox.Text.Trim();
            video.Year = (int)yearNumeric.Value;
            video.Season = (int)seasonNumeric.Value;
            video.Episode = (int)episodeNumeric.Value;
            video.VideoFhd = fhdCheckBox.Checked;
            video.EpisodeTitle = episodeTitleTextBox.Text.Trim();
            video.TranslatedEpisodeTitle = translatedEpisodeTitleTextBox.Text.Trim();
            video.Uri4k = uri4kTextBox.Text;
            video.CoverUri = coverUriTextBox.Text;
            video.ThemeUri = themeUriTextBox.Text;
            video.SubtitleSrbUri = subtitleSrTextBox.Text;
            video.SubtitleEngUri = subtitleEnTextBox.Text;
            video.Director = directorTextBox.Text.Trim();
            video.Actors = actorsTextBox.Text.Trim() != "" ? actorsTextBox.Text.Split(',', options: StringSplitOptions.TrimEntries) : [];
            video.Genres = genresTextBox.Text.Split(',', options: StringSplitOptions.TrimEntries);
            video.SkipSegments = skipSegmentsTextBox.Text.Trim() != "" ? skipSegmentsTextBox.Text.Split(',', options: StringSplitOptions.TrimEntries) : [];
            video.PreviousTitle = previousTitleTextBox.Text.Trim();
            video.Priority = (int)priorityNumeric.Value;

            resTextArea.Text = "";
            string jsonPayload = JsonSerializer.Serialize(video);
            var content = new StringContent(jsonPayload, System.Text.Encoding.UTF8, "application/json");

            try
            {
                //HttpResponseMessage res = await http.PostAsync("http://home.darkomikan.com:7080/api/video/insert", content);
                HttpResponseMessage res = await http.PostAsync("http://192.168.10.100:7080/api/video/insert", content);
                res.EnsureSuccessStatusCode();
                string responseBody = await res.Content.ReadAsStringAsync();
                using JsonDocument jsonDocument = JsonDocument.Parse(responseBody);
                resTextArea.Text = JsonSerializer.Serialize(jsonDocument.RootElement, new JsonSerializerOptions { WriteIndented = true });
                if (videoList.SelectedItem != null)
                {
                    int index = videoList.SelectedIndex;
                    videoList.Items.RemoveAt(index);
                    if (index < videoList.Items.Count)
                        videoList.SetSelected(index, true);
                    else if (index - 1 < videoList.Items.Count && videoList.Items.Count > 0)
                        videoList.SetSelected(index - 1, true);
                }
            }
            catch (HttpRequestException ex)
            {
                resTextArea.Text = ex.Message;
            }
        }

        private void remove4kUriButton_Click(object sender, EventArgs e)
        {
            uri4kTextBox.Clear();
        }

        private void removeCoverUriButton_Click(object sender, EventArgs e)
        {
            coverUriTextBox.Clear();
        }

        private void removeThemeUriButton_Click(object sender, EventArgs e)
        {
            themeUriTextBox.Clear();
        }

        private void removeSubtitleSrButton_Click(object sender, EventArgs e)
        {
            subtitleSrTextBox.Clear();
        }

        private void removeSubtitleEnButton_Click(object sender, EventArgs e)
        {
            subtitleEnTextBox.Clear();
        }

        private void videoList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (videoList.SelectedItem != null)
            {
                uriTextBox.Text = ((Video)videoList.SelectedItem).Uri;
                seasonNumeric.Value = ((Video)videoList.SelectedItem).Season;
                episodeNumeric.Value = ((Video)videoList.SelectedItem).Episode;
                episodeTitleTextBox.Text = ((Video)videoList.SelectedItem).EpisodeTitle;
                coverUriTextBox.Text = ((Video)videoList.SelectedItem).CoverUri;
                subtitleSrTextBox.Text = ((Video)videoList.SelectedItem).SubtitleSrbUri;
                subtitleEnTextBox.Text = ((Video)videoList.SelectedItem).SubtitleEngUri;
            }
        }
    }
}
