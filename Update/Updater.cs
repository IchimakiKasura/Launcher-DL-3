namespace Update;

class Updater
{
    private float CurrentVersion = 6.7f;

    public Updater()
    {
        string Data = CheckVersion().Result;

        if (string.IsNullOrEmpty(Data)) return;

        kasuNhentaiCS.Json.JsonDeserializer DataJson = new(Data);

        float NewVersion = float.Parse(DataJson.selector("tag_name").Replace("v", ""));
        string message = $"New version (Launcher DL v{NewVersion}) is available at Github repository!\n\nDownload it now on the website?";
        string Visit = $"https://github.com/IchimakiKasura/Launcher-DL-3/releases/tag/{DataJson.selector("tag_name")}";

        if (NewVersion > CurrentVersion)
            if (MessageBox.Show(message,
                                "Update Notification",
                                MessageBoxButton.OKCancel,
                                MessageBoxImage.Information) == MessageBoxResult.OK)
                                Process.Start("explorer", Visit);
    }

    private Task<string> CheckVersion()
    {
        System.Net.Http.HttpResponseMessage resp;
        int status;

        try
        {
            using (System.Net.Http.HttpClient req = new())
            {
                req.DefaultRequestVersion = new("2.0");
                req.DefaultRequestHeaders.Add("User-Agent", "Launcher DL Update Checker");
                var res = req.GetAsync("https://api.github.com/repos/ichimakikasura/launcher-dl-3/releases/latest").Result;
                status = (int)res.StatusCode;
                resp = res;
            }

            return resp.Content.ReadAsStringAsync();
        }
        catch { return null; }
    }
}