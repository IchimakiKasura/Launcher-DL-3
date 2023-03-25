namespace LauncherDL.Core.ConsoleDL;

public class DL_Dispatch
{
    public static async void Invoke(Action Method, string StringData)
    {
        if(StringData.IsEmpty()) return;
        if(!console.Dispatcher.CheckAccess())
            await console.Dispatcher.InvokeAsync(Method);
    }
}