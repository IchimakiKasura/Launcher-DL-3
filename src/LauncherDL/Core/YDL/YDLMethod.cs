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

        var Arguments = $"--compat-options format-sort -F {Link} --no-playlist";

        if (config.AllowCookies) Arguments += $" --cookies-from-browser {config.BrowserCookie}";

        // Clear existing list on ComboBoxFormat and its Temporarylist
        TemporaryList.Clear();
        comboBoxFormat.ResetBox();
        
        // Clear metadata values
        MetadataWindow.MetadataClear();

        ConsoleLive.SelectedError = 0;
        await TaskProcess.StartProcess.ProcessTask(Arguments, ConsoleLive.FileFormatLiveOutputComment);

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

        var Arguments = $"-i \"{Link}\" {comboBoxQuality.GetItemUID} {FFMPEG_STRINGS} \"{config.DefaultOutput}\\Convert\\{textBoxName.Text}.{Format}\"";
        ConsoleLive.SelectedError = 2;

        if (!Directory.Exists($"{config.DefaultOutput}\\Convert"))
            Directory.CreateDirectory($"{config.DefaultOutput}\\Convert");

        await TaskProcess.StartProcess.ProcessTask(Arguments, ConsoleLive.ConvertLiveOutputComment);
        TaskProcess.EndProcess.ProcessTaskEnded();
    }



    /// <summary>
    /// Download Method
    /// </summary>
    public async void DownloadMethod()
    {
        if (IsUpdate || IsFileFormat)
            throw new DownloadMethodException();

        string FolderType = "Formatted\\%(ext)s";
        string Arguments = "N/A";
        string ExtensionFormat = "N/A";
        ConsoleLive.SelectedError = 1;

        // To be change
        switch(Type)
        {
            case TypeOfButton.CustomType:
                Arguments = $"-f \"{Format}\"";
                ExtensionFormat = "%(ext)s";
            break;

            case TypeOfButton.VideoType:
                FolderType = "Video";
                
                Arguments = $"ext:mp4:m4a --recode-video {Format}"; 
                ExtensionFormat = Format;

                if(Format is not "auto") break;

                Arguments= $"-f b"; 
                ExtensionFormat = "%(ext)s";
            break;

            case TypeOfButton.AudioType:
                FolderType = "Audio";

                Arguments = $"-f ba -x --audio-format {Format}"; 
                ExtensionFormat = Format;

                if(Format is not "auto") break;

                Arguments = $"-f ba -x"; 
                ExtensionFormat = "%(ext)s";
            break;
        }

        var FILE_EXIST_PATH = $"{config.DefaultOutput}\\{FolderType}\\{textBoxName.Text}.{ExtensionFormat}";

        if(CheckFileExist(FILE_EXIST_PATH, Type))
        {
            console.DLAddConsole(CONSOLE_ERROR_SOFT_STRING, ConvertButton.NAME_EXIST);

            WindowsComponents.FreezeComponents();

            return;
        }

        Arguments = $"{Arguments} {Link} -o \"{FILE_EXIST_PATH}\"";

        if (!config.EnablePlaylist) Arguments += " --no-playlist";
        if (config.AllowCookies) Arguments += $" --cookies-from-browser {config.BrowserCookie}";
        
        if(FFmpeg.FFmpegFiles.ErrorOccured)
        {
            console.DLAddConsole(CONSOLE_ERROR_SOFT_STRING, "FFMPEG Was not found, Error may occur when processing.");
            Arguments += " --no-part";
        } else Arguments += $" --ffmpeg-location \"{FFMPEG_Path}\" --no-part";

        console.Break("Gray");
        ConsoleLastDocument = console.SaveText();
        await TaskProcess.StartProcess.ProcessTask(Arguments, ConsoleLive.DownloadLiveOutputComment);
        TaskProcess.EndProcess.ProcessTaskEnded();
    }

    // FIXME: refactor this future me if possible
    private bool CheckFileExist(string FilePath, TypeOfButton Type)
    {
        var Existed = false;

        if(Type != TypeOfButton.CustomType)
        {
            if(Format is "auto" && File.Exists(FilePath.Replace("%(ext)s", ".*")))
                Existed = true;
            else
                if(File.Exists(FilePath)) Existed = true;
            
            return Existed;
        }

        // This is pain :<
        foreach(var Ext in FileExtensions)
            if(File.Exists(FilePath.Replace("%(ext)s", Ext)))
                Existed = true;
        
        return Existed;
    }
}