namespace LauncherDL.Core.TaskProcess;

// Literally ported from v6 to v5
sealed class LinkValidate
{
    public bool IsValid;
    public bool HasPlaylist;
    bool IsError = false;
    bool TempHasPlaylist;
    string url;

    public LinkValidate(string _url)
    {
        url = _url;
    }

    public LinkValidate Validate()
    {
        try
        {
            Uri Link = new(url);
            var UrlHost = URLname.Match(Link.Host).Groups["host"].Value;
            var UrlPath = Link.PathAndQuery;
            GetFileName();

            return new(default)
            {
                IsValid = !IsError,
                HasPlaylist = TempHasPlaylist
            };
        }
        catch
        {
            return new(default)
            {
                IsValid = false,
                HasPlaylist = false
            };
        }
    }
    private async void GetFileName()
    {
        await Task.Run(async()=>
        {
            Process Proc = new();

            string Arguments = $"--get-filename -o '%(title)s' {url} --verbose --no-playlist --encoding utf8";
            if (config.AllowCookies) Arguments += $" --cookies-from-browser {config.BrowserCookie}";

            Proc.StartInfo = new(YDL_Path, Arguments)
            {
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                CreateNoWindow = true
            };
            
            Proc.OutputDataReceived += (s,e) =>
                DL_Dispatch.Invoke(()=>{
                    console.AddFormattedText($"<Green>[SUCCESS] <>{e.Data}");
                    if(textBoxLink.Text.IsEmpty()) textBoxName.Text = e.Data;
                }, e.Data);
            

            Proc.ErrorDataReceived += (s, e) =>
                DL_Dispatch.Invoke(()=>{
                    if (e.Data.Contains("ERROR") || e.Data.Contains("Traceback"))
                    {
                        TempHasPlaylist = false;
                        if (e.Data.Contains("--no-playlist"))
                            TempHasPlaylist = true;

                        if (e.Data.Contains("cookies"))
                            console.AddFormattedText($"<Yellow>[INFO] <>If the link from facebook or other social media that is not public or needed an account, Please set the \"AllowCookies\" on the \"Config\". This method might be risky so I'm not liable if your account is blocked or locked");

                        IsError = true;
                    }
                }, e.Data);

            Proc.Start();
            Proc.BeginOutputReadLine();
            Proc.BeginErrorReadLine();
            await Proc.WaitForExitAsync();
        });
    }

}