namespace LauncherDL.Core.ConsoleDL;

internal partial class ConsoleLive
{
    public static void DownloadLiveOutputComment(object s, DataReceivedEventArgs e)
    {
        string StringData = e.Data;
        if (string.IsNullOrEmpty(StringData)) return;

        DL_Dispatch.Invoke(()=>Download_Invoke(StringData));
    }

    static void Download_Invoke(string StringData)
    {

    }
}