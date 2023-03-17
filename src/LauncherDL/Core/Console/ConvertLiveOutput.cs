namespace LauncherDL.Core.ConsoleDL;

internal partial class ConsoleLive
{
    static int TotalDuration;
    public static void ConvertLiveOutputComment(object s, DataReceivedEventArgs e) =>
        DL_Dispatch.Invoke(()=>Convert_Invoked(e.Data),e.Data);

    static void Convert_Invoked(string StringData)
    {
        int CurrentTimeInt;
        string TotalTime = ConvertTotal.Match(StringData).Groups["TotalTime"].Value.Trim();
        string CurrentTime = ConvertCurrent.Match(StringData).Groups["CurrentTime"].Value.Trim();

        if (!string.IsNullOrEmpty(TotalTime))
            TotalDuration = (int)TimeSpan.Parse(TotalTime).TotalSeconds;

        if (!string.IsNullOrEmpty(CurrentTime))
        {
            CurrentTimeInt = (int)TimeSpan.Parse(CurrentTime).TotalSeconds;
            progressBar.Value = (double)((decimal)CurrentTimeInt / (decimal)TotalDuration) * 100;
        }

        if(StringData.Contains("error"))
            Error_Invoked();
    }
}