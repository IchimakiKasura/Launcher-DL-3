namespace LauncherDL.Core.ConsoleDL;

internal partial class ConsoleLive
{
    static int TotalDuration;
    public static void ConvertLiveOutputComment(object s, DataReceivedEventArgs e) =>
        DL_Dispatch.Invoke(()=>Concert_Invoked(e.Data),e.Data);

    static void Concert_Invoked(string StringData)
    {
        string TotalTime = ConvertTotal.Match(StringData).Groups["TotalTime"].Value.Trim();
        string CurrentTime = ConvertCurrent.Match(StringData).Groups["CurrentTime"].Value.Trim();
        int CurrentTimeInt;

        if (!string.IsNullOrEmpty(TotalTime))
            TotalDuration = (int)TimeSpan.Parse(TotalTime).TotalSeconds;

        if (!string.IsNullOrEmpty(CurrentTime))
        {
            CurrentTimeInt = (int)TimeSpan.Parse(CurrentTime).TotalSeconds;
            progressBar.Value = (double)((decimal)CurrentTimeInt / (decimal)TotalDuration) * 100;
        }

        if(StringData.Contains("error"))
        {
            console.DLAddConsole(CONSOLE_ERROR_STRING, "<%14>Convert failed! please report it to the author");
        }
    }
}