namespace LauncherDL.Core.ConsoleDL;

public class DL_Dispatch
{
    public static void Invoke(Action Method) =>
        MainWindowStatic.Dispatcher.Invoke(DispatcherPriority.Normal, ()=>Method);
}