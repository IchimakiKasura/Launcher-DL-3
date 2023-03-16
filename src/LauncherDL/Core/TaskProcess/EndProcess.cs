namespace LauncherDL.Core.TaskProcess;

abstract class EndProcess
{
    public static void ProcessTaskEnded()
    {
        comboBoxFormat.AddFormatList(TemporaryList);
        WindowsComponents.FreezeComponents();
    }
}