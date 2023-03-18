namespace LauncherDL.Core.ConsoleDL;

internal partial class ConsoleLive
{
    
    public static void UpdateLiveOutputComment(object s, DataReceivedEventArgs e) =>
        DL_Dispatch.Invoke(()=>Update_Invoked(e.Data),e.Data);

    static void Update_Invoked(string StringData)
    {
        switch(StringData)
        {
            case string when StringData.Contains("yt-dlp is up to date"):
                console.DLAddConsole(CONSOLE_YEY_STRING, "<%14>File is up to date!");
            break;

            case string when StringData.Contains("yt-dlp to version"):
                console.DLAddConsole(CONSOLE_SYSTEM_STRING , $"<Gray%14>{StringData}");
                console.DLAddConsole(CONSOLE_YEY_STRING, "Updated!");
            break;
        }
    }
}