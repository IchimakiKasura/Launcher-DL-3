namespace LauncherDL.Core.ConsoleDL;

internal partial class ConsoleLive
{
    public static void DownloadLiveOutputComment(object s, DataReceivedEventArgs e) =>
        DL_Dispatch.Invoke(()=>Download_Invoke(e.Data),e.Data);

    static void Download_Invoke(string StringData)
    {

    }
}