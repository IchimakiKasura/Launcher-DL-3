namespace LauncherDL.Core.ConsoleDL;

internal partial class ConsoleLive
{
    public static void ConvertLiveOutputComment(object s, DataReceivedEventArgs e)
    {
        string StringData = e.Data;
        if (string.IsNullOrEmpty(StringData)) return;

        DL_Dispatch.Invoke(()=>Concert_Invoked(StringData));
    }

    static void Concert_Invoked(string StringData)
    {
        
    }
}