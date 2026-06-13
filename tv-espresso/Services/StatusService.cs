namespace tv_espresso.Services
{
    public class StatusService
    {
        public readonly string rootPath;

        public StatusService(IConfiguration configuration)
        {
            rootPath = configuration["TvEspressoRoot"]!;
        }

        public string GetLatestVersion()
        {
            var releasesPath = Path.Combine(rootPath, "apk");
            var apkFiles = Directory.GetFiles(releasesPath, "tv-espresso_*.apk");
            if (!apkFiles.Any())
                return "";

            var latest = apkFiles.Select(f =>
            {
                var fileName = Path.GetFileNameWithoutExtension(f);
                var versionStr = fileName.Replace("tv-espresso_", "");
                return Version.TryParse(versionStr, out var v) ?
                    new { FilePath = f, FileName = Path.GetFileName(f), Version = v, VersionStr = versionStr } : null;
            }).Where(x => x != null).OrderByDescending(x => x!.Version).FirstOrDefault();

            if (latest == null)
                return "";
            else
                return Path.Combine("apk", latest.FileName);
        }
    }
}
