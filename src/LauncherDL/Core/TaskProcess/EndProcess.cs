namespace LauncherDL.Core.TaskProcess;

abstract class EndProcess
{
    public static void ProcessTaskEnded()
    {
        comboBoxFormat.AddFormatList(TemporaryList);

        switch(ConsoleLive.SelectedError)
        {
            case 2:
                console.DLAddConsole(CONSOLE_YEY_STRING, $"<%14>File converted: \"{config.DefaultOutput}\\Convert\\{textBoxName.Text}.{comboBoxFormat.GetItemContent}\"");
            break;
        }

        WindowsComponents.FreezeComponents();
    }
}