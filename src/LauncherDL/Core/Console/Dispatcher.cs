namespace LauncherDL.Core.ConsoleDL;

public sealed class DL_Dispatch
{
    public static void Invoke(Action Invoked)
    {
        if(!console.Dispatcher.CheckAccess())
            console.Dispatcher.Invoke(DispatcherPriority.Background, Invoked);
    }
}