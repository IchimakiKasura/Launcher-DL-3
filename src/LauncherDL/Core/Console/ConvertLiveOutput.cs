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

        if (!TotalTime.IsEmpty())
            TotalDuration = (int)TimeSpan.Parse(TotalTime).TotalSeconds;

        if (!CurrentTime.IsEmpty())
        {
            CurrentTimeInt = (int)TimeSpan.Parse(CurrentTime).TotalSeconds;
            double ProgressValue = (double)((decimal)CurrentTimeInt / (decimal)TotalDuration) * 100;
            TaskbarProgressBar.ProgressValue = ProgressValue;
            progressBar.Value = ProgressValue;
        }

        if(StringData.Contains("error"))
            Error_Invoked();
    }
}