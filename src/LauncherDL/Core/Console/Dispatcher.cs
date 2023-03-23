namespace LauncherDL.Core.ConsoleDL;

public class DL_Dispatch
{
    public static void Invoke(Action Method, string StringData)
    {
        if(StringData.IsEmpty()) return;
        if(!MainWindowStatic.Dispatcher.CheckAccess())
            MainWindowStatic.Dispatcher.Invoke(DispatcherPriority.Normal, Method);
    }
}