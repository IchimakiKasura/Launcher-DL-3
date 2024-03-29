namespace LauncherDL.Core.TaskProcess;

/// <summary>
/// Where Download or Convert Task ended
/// </summary>
sealed class EndProcess
{
    public static async void ProcessTaskEnded()
    {
        switch(ConsoleLive.SelectedError)
        {
            case 0: FileFormatTaskEnded(); break;
            case 1: DownloadTaskEnded();   break;
            case 3: ConvertTaskEnded();    break;
        }

        if (!MainWindowStatic.IsActive)
            WindowsComponents.WindowTaskBarFlash();
            
        if(ConsoleLive.SelectedError is not 9999 && !ConsoleLive.SingleErrorInstance
            || ConsoleLive.SelectedError is 0 && progressBar.Value is 99)
            {
                progressBar.Value = 100; // for Fileformat shit
                await progressBar.AwaitCompletionAsync();
            }

        WindowsComponents.FreezeComponents();

        IsInProcess = false;
        TaskbarProgressBar.ProgressValue = 0;
        ConsoleLive.SingleErrorInstance = false;

        if(Directory.Exists(FolderButton.FolderDirectory()))
            windowCanvas.Add(ButtonOpenFolder);
            
        OnStartUp.UpdateContexButtons();

        await progressBar.AwaitOpacityCompletionAsync(0);
        progressBar.Value = 0;
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

        if(MetadataWindowStatic is not null)
        {
            bool[] ConditionMet = {
                MetadataWindowStatic.IsTextChanged,
                !FFmpegFiles.ErrorOccured,
                comboBoxType.GetItemContent is "Video",
                comboBoxFormat.GetItemContent is "mp4"
            };

            // Sets the metadata
            // **read the comment on MetadataMethod.cs LN:41 for explanation idk**
            if(ConditionMet.All(x => x))
                MetadataWindow.ApplyMetadataOnFile();
        }
        
        console.DLAddConsole(CONSOLE_YEY_STRING, "Downloaded!");

        ConsoleLastDocument.Dispose();
    }
}