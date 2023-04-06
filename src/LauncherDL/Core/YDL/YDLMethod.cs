namespace LauncherDL.Core.YTDLP;

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
        ConsoleLive.SelectedError = 9999;
        await TaskProcess.StartProcess.ProcessTask(Args, ConsoleLive.UpdateLiveOutputComment);
        TaskProcess.EndProcess.ProcessTaskEnded();
    }



    /// <summary>
    /// FileFormat Method
    /// </summary>
    public async void FileFormatMethod()
    {
        if (!IsFileFormat)
            throw new FileFormatMethodException();

        var Arguments = new StringBuilder();
        Arguments.Append($"--compat-options format-sort -F {Link} --no-playlist");

        if (config.AllowCookies) Arguments.Append($" --cookies-from-browser {config.BrowserCookie}");

        // Clear existing list on ComboBoxFormat and its Temporarylist
        TemporaryList.Clear();
        comboBoxFormat.ResetBox();
        
        // Clear metadata values
        MetadataWindow.MetadataClear();

        ConsoleLive.SelectedError = 0;
        await TaskProcess.StartProcess.ProcessTask(Arguments.ToString(), ConsoleLive.FileFormatLiveOutputComment);

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

        var FFMPEG_STRINGS = new StringBuilder();
        FFMPEG_STRINGS.Append("-metadata description=\"Converted on LauncherDL\" ");
        FFMPEG_STRINGS.Append("-metadata comment=\"Converted on LauncherDL\" ");

        var directoryPath = Path.Combine(config.DefaultOutput, "Convert");

        var Arguments = new StringBuilder()
        .Append("-i \"")
        .Append(Link)
        .Append("\" ")
        .Append(comboBoxQuality.GetItemUID)
        .Append(" ")
        .Append(FFMPEG_STRINGS.ToString())
        .Append(" \"")
        .Append(Path.Combine(config.DefaultOutput, "Convert", $"{textBoxName.Text}.{Format}\""))
        .ToString();

        ConsoleLive.SelectedError = 3;
        
        if (!Directory.Exists(directoryPath))
            Directory.CreateDirectory(directoryPath);

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

        var Arguments = new StringBuilder();

        string
        FolderType = "Formatted\\%(ext)s",
        ExtensionFormat = "N/A";

        ConsoleLive.SelectedError = 1;

        // To be change
        switch(Type)
        {
            case TypeOfButton.CustomType:
                Arguments.Append($"-f \"{Format}\"");
                ExtensionFormat = "%(ext)s";
            break;

            case TypeOfButton.VideoType:
                FolderType = "Video";
                
                Arguments.Append($"-f \"b [ext=mp4]\" --recode-video {Format}"); 
                ExtensionFormat = Format;
            break;

            case TypeOfButton.AudioType:
                FolderType = "Audio";

                Arguments.Append($"-x --audio-format {Format}");
                ExtensionFormat = Format;
            break;
        }

        var FILE_EXIST_PATH = Path.Combine(config.DefaultOutput, FolderType, $"{textBoxName.Text}.{ExtensionFormat}");

        if(CheckFileExist(FILE_EXIST_PATH, Type))
        {
            console.DLAddConsole(CONSOLE_ERROR_SOFT_STRING, ConvertButton.NAME___EXIST);
            WindowsComponents.FreezeComponents();
            return;
        }

        // Finalizing the arguments
        Arguments.Append($" \"{Link}\" -o \"{FILE_EXIST_PATH}\" --no-playlist");
        
        if (config.AllowCookies) Arguments.Append($" --cookies-from-browser {config.BrowserCookie}");
        
        // Warns the user that there's no FFMPEG in presence
        if(FFmpeg.FFmpegFiles.ErrorOccured)
        {
            console.DLAddConsole(CONSOLE_ERROR_SOFT_STRING, "FFMPEG Was not found, Error may occur when processing.");
            Arguments.Append($" --downloader \"{ARIA2C_Path}\" --no-part");
        }
        else 
        {
            Arguments.Append($" --ffmpeg-location \"{FFMPEG_Path}\" --downloader \"{ARIA2C_Path}\" --no-part");
            
            //Apply Metadata if exist
            MetadataWindow.ApplyMetadataOnFile(ref Arguments);
        }

        console.SaveText(ref ConsoleLastDocument);

        await TaskProcess.StartProcess.ProcessTask(Arguments.ToString(), ConsoleLive.DownloadLiveOutputComment);
        TaskProcess.EndProcess.ProcessTaskEnded();
    }

    private bool CheckFileExist(string FilePath, TypeOfButton Type)
    {
        if (Type is TypeOfButton.CustomType)
            foreach(var Extenstion in FileExtensions)
                if(File.Exists(FilePath.Replace("%(ext)s", Extenstion)))
                    return true;

        return File.Exists(FilePath) ? true : false;
    }
}