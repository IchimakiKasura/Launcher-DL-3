namespace LauncherDL.Core.ConsoleDL;

internal sealed partial class ConsoleLive
{
    public static void UpdateLiveOutputComment(object s, DataReceivedEventArgs e) =>
        DL_Dispatch.Invoke(()=>Update_Invoked(e.Data));

    static void Update_Invoked(string StringData)
    {
        if(StringData.IsEmpty()) return;

        switch(StringData)
        {
            case string str when str.Contains("yt-dlp is up to date"):
                console.DLAddConsole(CONSOLE_YEY_STRING, UPDATE_UPDATED_MSG);
            break;

            case string str when str.Contains("yt-dlp to version"):
                console.DLAddConsole(CONSOLE_SYSTEM_STRING , $"<Gray%14>{str}");
                console.DLAddConsole(CONSOLE_YEY_STRING, UPDATE_SUCCESS_MSG);
            break;
        }
    }
}