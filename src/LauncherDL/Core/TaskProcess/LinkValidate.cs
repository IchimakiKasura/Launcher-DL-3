namespace LauncherDL.Core.TaskProcess;

// Literally ported from v6 to v5
sealed class LinkValidate
{
    public bool IsValid;
    bool IsError = false;
    string url;

    public LinkValidate(string _url = "") =>
        url = _url;
    
    public async Task<LinkValidate> Validate()
    {
        // Force to disable the components
        WindowsComponents.FreezeComponents();
        
        try
        {
            Uri Link = new(url);
            var UrlHost = URLname.Match(Link.Host).Groups["host"].Value;
            var UrlPath = Link.PathAndQuery;
            await GetFileName();

            WindowsComponents.FreezeComponents();
            return new()
            {
                IsValid = !IsError,
            };
        }
        catch
        {
            WindowsComponents.FreezeComponents();
            return new()
            {
                IsValid = false,
            };
        }
    }
    
    private async Task GetFileName()
    {
        ConsoleLive.SelectedError = 2;

        string Arguments = $"--get-filename -o '%(title)s' {url} --no-playlist --encoding utf8";
        if (config.AllowCookies) Arguments += $" --cookies-from-browser {config.BrowserCookie}";

        Process LinkValidationProcess = new()
        {
            StartInfo = new()
            {
                FileName = YDL_Path,
                Arguments = Arguments,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                CreateNoWindow = true,
                StandardOutputEncoding = Encoding.UTF8,
                StandardErrorEncoding = Encoding.UTF8
            }
        };

        LinkValidationProcess.OutputDataReceived += (s,e) =>
            DL_Dispatch.Invoke(()=>{
                if(e.Data.IsEmpty()) return;
                var FetchedTitle = e.Data.Remove(e.Data.Length - 1,1).Remove(0, 1).Trim();
                console.AddFormattedText($"<Lime%14>[SUCCESS] <%14>{FetchedTitle}");
                if(textBoxName.Text.IsEmpty())
                    textBoxName.Text = FetchedTitle;
            });
        
        LinkValidationProcess.ErrorDataReceived += (s, e) =>
            DL_Dispatch.Invoke(()=>{
                if(e.Data.IsEmpty()) return;
                if (e.Data.Contains("ERROR") || e.Data.Contains("Traceback"))
                {
                    if (e.Data.Contains("cookies"))
                        console.AddFormattedText($"<Yellow%14>[INFO] <%14>If the link from facebook or other social media that is not public or needed an account, Please set the \"AllowCookies\" on the \"Config\". This method might be risky so I'm not liable if your account is blocked or locked");

                    IsError = true;
                }
                if(e.Data.Contains("ERROR:"))
                    ConsoleLive.Error_Invoked("error");
            });

        await LinkValidationProcess.StartAsync();
        LinkValidationProcess.BeginOutputReadLine();
        LinkValidationProcess.BeginErrorReadLine();
        await LinkValidationProcess.WaitForExitAsync();
    }

}