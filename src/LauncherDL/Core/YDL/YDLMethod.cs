namespace LauncherDL.Core.YTDLP;

#pragma warning disable CS1998  // Remove this after DownloadMetho has awaitables
sealed partial class YDL
{
    /// <summary>
    /// Update Method
    /// </summary>
    public async void UpdateMethod()
    {
        if (!IsUpdate)
            throw new UpdateMethodException();

        var Args = "-U";
        
        progressBar.Value = 99;
        await TaskProcess.StartProcess.ProcessTask(Args, ConsoleLive.UpdateLiveOutputComment);
        WindowsComponents.FreezeComponents();
    }

    /// <summary>
    /// FileFormat Method
    /// </summary>
    public async void FileFormatMethod()
    {
        if (!IsFileFormat)
            throw new FileFormatMethodException();

        var Args = $"--compat-options format-sort -F {Link} --no-playlist";

        if (config.AllowCookies) Args += $" --cookies-from-browser {config.BrowserCookie}";

        // Clear existing list on ComboBoxFormat and its Temporarylist
        TemporaryList.Clear();
        comboBoxFormat.ResetBox();
        
        // Clear metadata values
        MetadataWindow.MetadataClear();

        ConsoleLive.SelectedError = 0;
        await TaskProcess.StartProcess.ProcessTask(Args, ConsoleLive.FileFormatLiveOutputComment);

        // Always leave a default list :D
        TemporaryList.Add(new()
        {
            Name        =       "Default",
            ID          =       "Best",
            FORMAT      =       "Best",
            RESOLUTION  =       "Best",
            FPS         =       "N/A",
            SIZE        =       "N/A",
            BITRATE     =       "~"
        });

        TaskProcess.EndProcess.ProcessTaskEnded();
    }

    /// <summary>
    /// Convert Method
    /// </summary>
    public async void ConvertMethod()
    {
        if (IsUpdate || IsFileFormat)
            throw new ConvertMethodException();

        var FFMPEG_STRINGS =
        "-metadata description=\"Converted on LauncherDL\" " +
        "-metadata comment=\"Converted on LauncherDL\" ";

        var Args = $"-i \"{Link}\" {comboBoxQuality.GetItemUID} {FFMPEG_STRINGS} \"{config.DefaultOutput}\\Convert\\{textBoxName.Text}.{Format}\"";
        ConsoleLive.SelectedError = 2;

        if (!Directory.Exists($"{config.DefaultOutput}\\Convert"))
            Directory.CreateDirectory($"{config.DefaultOutput}\\Convert");

        await TaskProcess.StartProcess.ProcessTask(Args, ConsoleLive.ConvertLiveOutputComment);
        TaskProcess.EndProcess.ProcessTaskEnded();
    }

    /// <summary>
    /// Download Method
    /// </summary>
    public async void DownloadMethod()
    {
        if (IsUpdate || IsFileFormat)
            throw new DownloadMethodException();

        var Args = Format;
        ConsoleLive.SelectedError = 1;
    }
}