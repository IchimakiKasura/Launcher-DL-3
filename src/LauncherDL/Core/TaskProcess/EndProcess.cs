namespace LauncherDL.Core.TaskProcess;

/// <summary>
/// Where Download or Convert Task ended
/// </summary>
abstract class EndProcess
{
    public static void ProcessTaskEnded()
    {
        switch(ConsoleLive.SelectedError)
        {
            case 0: FileFormatTaskEnded(); break;
            case 1: DownloadTaskEnded();   break;
            case 3: ConvertTaskEnded();    break;
        }

        if (!MainWindowStatic.IsActive)
            WindowsComponents.WindowTaskBarFlash();

        ConsoleLive.SingleErrorInstance = false;

        WindowsComponents.FreezeComponents();

        IsInProcess = false;
        progressBar.Value = 0;
        TaskbarProgressBar.ProgressValue = 0;

        if(Directory.Exists(FolderButton.FolderDirectory()))
            windowCanvas.Add(ButtonOpenFolder);

    }

    // File Format method after fetching
    static void FileFormatTaskEnded() =>
        comboBoxFormat.AddFormatList(TemporaryList);

    // Convert method after conversion
    static void ConvertTaskEnded() =>
        console.DLAddConsole(CONSOLE_YEY_STRING, $"File converted: \"{config.DefaultOutput}\\Convert\\{textBoxName.Text}.{comboBoxFormat.GetItemContent}\"");
    
    // Download method after download
    static void DownloadTaskEnded()
    {
        if(!ConsoleLive.SingleErrorInstance)
            console.LoadText(ConsoleLastDocument);
        else return;

        // Sets the metadata
        if(MetadataWindowStatic != null && MetadataWindowStatic.IsTextChanged && !FFmpegFiles.ErrorOccured)
        {
            console.DLAddConsole(CONSOLE_INFO_STRING, "Metadata has been applied.");
            MetadataWindow.ApplyMetadataOnFile();
        }
        else if(MetadataWindowStatic != null && MetadataWindowStatic.IsTextChanged && FFmpegFiles.ErrorOccured)
            console.DLAddConsole(CONSOLE_ERROR_STRING, "Metadata cannot be applied! FFMPEG is missing!");
        
        
        console.DLAddConsole(CONSOLE_YEY_STRING, "Downloaded!");
    }
}