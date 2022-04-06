namespace Launcher_DL_v6;


public class ValidateLink
{
    private MainWindow MW = Launcher_DL_v6.MainWindow.MW;
    public bool IsValid { get; set; }
    public bool HasPlaylist { get; set; }
    bool IsError = false;

    public async Task<ValidateLink> Validate(string url)
    {
        try
        {
            Uri Link = new(url);
            var UrlHost = LauncherDL_Regex.URLname.Match(Link.Host).Groups["host"].Value;
            var UrlPath = Link.PathAndQuery;
            await GetFileName(MW.Input_Link.Text);

            return new()
            {
                IsValid = !IsError,
                HasPlaylist = UrlPath.Contains("&list=")
            };
        }
        catch (Exception e)
        {
            Console.WriteLine($"\x1b[31m{e}\x1b[0m");
            return new()
            {
                IsValid = false,
                HasPlaylist = false
            };
        }
    }
    private async Task<string> GetFileName(string url)
    {
        string Name = string.Empty;

        Process Proc = new();
        Proc.StartInfo = new(MainWindow.YDL_link, MW.YTDL_Validate())
        {
            UseShellExecute = false,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            CreateNoWindow = true
        };
        Proc.EnableRaisingEvents = true;
        
        Proc.OutputDataReceived += delegate (object s, DataReceivedEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.Data))
                MW.Output_text.Dispatcher.Invoke(DispatcherPriority.Normal, (Action)delegate
                {
                    MW.Output_text.AddFormattedText($"<Green>[SUCCESS] <>{e.Data}");
                });
        };

        Proc.ErrorDataReceived += delegate (object s, DataReceivedEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.Data))
                MW.Output_text.Dispatcher.Invoke(DispatcherPriority.Normal, (Action)delegate
                {
                    if (e.Data.Contains("ERROR") || e.Data.Contains("Traceback"))
                    {
                        IsError = true;
                        DebugOutput.ERROR_Debug(e.Data);
                    }
                });
        };
    
        Proc.Start();
        Proc.BeginOutputReadLine();
        Proc.BeginErrorReadLine();
        await Proc.WaitForExitAsync();

        return Name;
    }

}