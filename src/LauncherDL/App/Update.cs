namespace Update;

sealed class Updater
{
    readonly public double CurrentVersion = 7.1;
    readonly public double NewVersion;

    public Updater()
    {
        using Stream streamData = CheckVersion().Result;
        using StreamReader reader = new(streamData, Encoding.UTF8);
        string Data = reader.ReadToEnd();

        if (string.IsNullOrEmpty(Data)) return;

        kasuNhentaiCS.Json.JsonDeserializer DataJson = new(Data);

        NewVersion = float.Parse(DataJson.selector("tag_name").Replace("v", ""));
        string message = $"New version (Launcher DL v{NewVersion}) is available at Github repository!\n\nDownload it now on the website?";
        string Visit = $"https://github.com/IchimakiKasura/Launcher-DL-3/releases/tag/{DataJson.selector("tag_name")}";

        if (NewVersion > CurrentVersion)
            if (MessageBox.Show(message,
                                "Update Notification",
                                MessageBoxButton.OKCancel,
                                MessageBoxImage.Information) is MessageBoxResult.OK)
                                Process.Start("explorer", Visit);
    }

    async Task<Stream> CheckVersion()
    {
        System.Net.Http.HttpResponseMessage resp;

        try
        {
            using (System.Net.Http.HttpClient req = new())
            {
                req.Timeout = TimeSpan.FromMilliseconds(800);
                req.DefaultRequestVersion = System.Net.HttpVersion.Version30;
                req.DefaultRequestHeaders.Add("User-Agent", "Launcher DL Update Checker");
                var res = req.GetAsync("https://api.github.com/repos/ichimakikasura/launcher-dl-3/releases/latest").Result;
                resp = res;
            }
            
            return await resp.Content.ReadAsStreamAsync();
        }
        catch { return Stream.Null; }
    }
}