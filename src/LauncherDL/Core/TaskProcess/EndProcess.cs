namespace LauncherDL.Core.TaskProcess;

/// <summary>
/// Where Download or Convert Task ended
/// </summary>
abstract class EndProcess
{
    public static void ProcessTaskEnded()
    {
        comboBoxFormat.AddFormatList(TemporaryList);

        switch(ConsoleLive.SelectedError)
        {
            case 1: DownloadTaskEnded(); break;
            case 2: ConvertTaskEnded();  break;
        }

        if (!MainWindowStatic.IsActive)
            WindowsComponents.WindowTaskBarFlash();
        
        WindowsComponents.FreezeComponents();
    }
    static void ConvertTaskEnded() =>
        console.DLAddConsole(CONSOLE_YEY_STRING, $"File converted: \"{config.DefaultOutput}\\Convert\\{textBoxName.Text}.{comboBoxFormat.GetItemContent}\"");
    
    static void DownloadTaskEnded()
    {

    }
}