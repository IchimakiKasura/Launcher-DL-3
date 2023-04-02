namespace LauncherDL.Core.TaskProcess;

/// <summary>
/// Where Download or Convert Task ended
/// </summary>
abstract class EndProcess
{
    // I'd like to express my anger/frustration in this Method.
    // 
    // The original code was the switch statement was on the top
    // has no `await progressar.AwaitCompletion()` and also the method
    // has no async.
    // 
    // It works fine until I did few adjustments on the progressbar control.
    // And it started a fucking annoying bug where the ComboBoxFormat keeps
    // throwing Thread related issue "Different thread owns it" and shit.
    // 
    // I did all i could to put invoke on some methods that has ComboBoxFormat on it
    // and didn't do it like its so ironic that most of the methods is not on the
    // Task type ITS ON A VOID, How can a fucking void create a different thread?
    //
    // Turns out the culprit was the "UserComboBox.Items.Add" on DLControl namespace
    // but that code was unchanged for few days or weeks because it works last time
    // but after adding the progressbar animations with async and changing few List
    // into ImmutableList thats where the bug happen.
    //
    // I commented out the await progressBar and the error still keeps showing.
    // I can't fucking find it and its gonna be hard to re-roll back to the commit 
    // where it still works because I made many changes.
    //
    // The current fix is putting the FreezeComponents first before calling the
    // Items.Add.
    //
    // I fucking hate this shit. Sorry for making a paragraph because this is
    // fucking shit and it somehow shows how terrible i am at coding.
    public static async void ProcessTaskEnded()
    {
        if(ConsoleLive.SelectedError is not 9999 && !ConsoleLive.SingleErrorInstance
            || ConsoleLive.SelectedError is 0 && progressBar.Value is 99)
            {
                progressBar.Value = 100; // for Fileformat shit
                await progressBar.AwaitCompletion();
            }

        WindowsComponents.FreezeComponents();

        switch(ConsoleLive.SelectedError)
        {
            case 0: FileFormatTaskEnded(); break;
            case 1: DownloadTaskEnded();   break;
            case 3: ConvertTaskEnded();    break;
        }

        if (!MainWindowStatic.IsActive)
            WindowsComponents.WindowTaskBarFlash();


        IsInProcess = false;
        TaskbarProgressBar.ProgressValue = 0;
        ConsoleLive.SingleErrorInstance = false;

        if(Directory.Exists(FolderButton.FolderDirectory()))
            windowCanvas.Add(ButtonOpenFolder);
            
        OnStartUp.UpdateContexButtons();

        await progressBar.AwaitOpacityCompletion(0);
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