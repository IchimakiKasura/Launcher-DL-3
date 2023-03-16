namespace LauncherDL.Core.YTDLP;

#pragma warning disable CS1998  // Remove this after DownloadMethod and ConvertMethod has awaitables
sealed partial class YDL
{
    /// <summary>Update Method</summary>
    public async void UpdateMethod()
    {
        if (!IsUpdate)
            throw new UpdateMethodException();

        var Args = "-U";
        
        progressBar.Value = 99;
        await TaskProcess.StartProcess.ProcessTask(Args, ConsoleLive.UpdateLiveOutputComment);
        WindowsComponents.FreezeComponents();
    }

    /// <summary>FileFormat Method</summary>
    public async void FileFormatMethod()
    {
        if (!IsFileFormat)
            throw new FileFormatMethodException();

        var Args = $"--compat-options format-sort -F {Link} --no-playlist";

        if (config.AllowCookies) Args += $" --cookies-from-browser {config.BrowserCookie}";

        // Clear existing list on ComboBoxFormat and its Temporarylist
        TemporaryList.Clear();
        comboBoxFormat.ResetBox();

        ConsoleLive.SelectedError = 0;
        await TaskProcess.StartProcess.ProcessTask(Args, ConsoleLive.FileFormatLiveOutputComment);
        TaskProcess.EndProcess.ProcessTaskEnded();
    }

    /// <summary>Download Method</summary>
    public async void DownloadMethod()
    {
        if (IsUpdate || IsFileFormat)
            throw new DownloadMethodException();

        var Args = Format;
        ConsoleLive.SelectedError = 1;
    }

    /// <summary>Convert Method</summary>
    public async void ConvertMethod()
    {
        if (IsUpdate || IsFileFormat)
            throw new ConvertMethodException();

        var Args = $"-i \"{Link}\" -q 0 \"{config.DefaultOutput}\\Convert\\{textBoxName.Text}.{Format}\"";
        ConsoleLive.SelectedError = 2;

		if (!Directory.Exists($"{config.DefaultOutput}\\Convert"))
			Directory.CreateDirectory($"{config.DefaultOutput}\\Convert");

        await TaskProcess.StartProcess.ProcessTask(Args, ConsoleLive.ConvertLiveOutputComment);
        TaskProcess.EndProcess.ProcessTaskEnded();
    }
}