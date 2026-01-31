using System.Windows.Forms;
using System.IO;
using tv_espresso.Models;
using System.Text.RegularExpressions;
using System.Text.Json;
using System.Threading.Tasks;

namespace tv_espresso_admin
{
    public partial class Form1 : Form
    {
        private bool initialDirectorySet = false;
        private string root = "";
        private Video video = new Video { Id = "", Title = "", Uri = "" };
        private static readonly HttpClient http = new HttpClient();

        public Form1()
        {
            InitializeComponent();
        }

        private void selectRootButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                root = folderBrowserDialog.SelectedPath;
                rootTextBox.Text = root;
                selectVideoButton.Enabled = true;

                createButton.Enabled = true;
                select4kUriButton.Enabled = true;
                selectCoverUriButton.Enabled = true;
                selectThemeUriButton.Enabled = true;
                selectSubtitleEnButton.Enabled = true;
                selectSubtitleSrButton.Enabled = true;
            }
        }

        private void selectVideoButton_Click(object sender, EventArgs e)
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
                        episodeTitleTextBox.Text = episodeTitleTextBox.Text.Replace('.', ' ').Trim();

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

        private void select4kUriButton_Click(object sender, EventArgs e)
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

            resTextArea.Text = "";
            string jsonPayload = JsonSerializer.Serialize(video);
            var content = new StringContent(jsonPayload, System.Text.Encoding.UTF8, "application/json");

            try
            {
                HttpResponseMessage res = await http.PostAsync("http://192.168.1.28:7080/api/video/insert", content);
                res.EnsureSuccessStatusCode();
                string responseBody = await res.Content.ReadAsStringAsync();
                resTextArea.Text = responseBody;
            }
            catch (HttpRequestException ex) 
            {
                resTextArea.Text = ex.Message;
            }
        }
    }
}
