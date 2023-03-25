using System.Threading;
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
            case 2: ConvertTaskEnded();    break;
        }

        if (!MainWindowStatic.IsActive)
            WindowsComponents.WindowTaskBarFlash();

        ConsoleLive.SingleErrorInstance = false;
    
        WindowsComponents.FreezeComponents();
    }

    static void FileFormatTaskEnded() =>
        comboBoxFormat.AddFormatList(TemporaryList);

    static void ConvertTaskEnded() =>
        console.DLAddConsole(CONSOLE_YEY_STRING, $"File converted: \"{config.DefaultOutput}\\Convert\\{textBoxName.Text}.{comboBoxFormat.GetItemContent}\"");
    
    static void DownloadTaskEnded()
    {
        console.LoadText(ConsoleLastDocument);
        console.DLAddConsole(CONSOLE_YEY_STRING, $"Downloaded!");
    }
}