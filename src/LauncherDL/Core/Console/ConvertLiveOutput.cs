namespace LauncherDL.Core.ConsoleDL;

internal partial class ConsoleLive
{
    public static void ConvertLiveOutputComment(object s, DataReceivedEventArgs e) =>
        DL_Dispatch.Invoke(()=>Concert_Invoked(e.Data),e.Data);

    static void Concert_Invoked(string StringData)
    {
        
    }
}