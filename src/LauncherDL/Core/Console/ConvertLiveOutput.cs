namespace LauncherDL.Core.ConsoleDL;

internal partial class ConsoleLive
{
    static int TotalDuration;
    static double ProgressValue = 0;
    public static void ConvertLiveOutputComment(object s, DataReceivedEventArgs e)
    {
        var StringData = e.Data;
        
        if(StringData.IsEmpty()) return;
        
        ProgressValue = 0;
        int CurrentTimeInt;
        string TotalTime = ConvertTotal.Match(StringData).Groups[CONVERT_GROUP_TOTALTIME].Value.Trim();
        string CurrentTime = ConvertCurrent.Match(StringData).Groups[CONVERT_GROUP_CURRENTTIME].Value.Trim();

        if (!TotalTime.IsEmpty())
            TotalDuration = (int)TimeSpan.Parse(TotalTime).TotalSeconds;

        if (!CurrentTime.IsEmpty())
        {
            CurrentTimeInt = (int)TimeSpan.Parse(CurrentTime).TotalSeconds;
            double ProgressValue = (double)((decimal)CurrentTimeInt / (decimal)TotalDuration) * 100;
        }

        if(StringData.Contains("error"))
            Error_Invoked("error");

        DL_Dispatch.Invoke(Convert_Invoked);
    }
    static void Convert_Invoked()
    {
        TaskbarProgressBar.ProgressValue = ProgressValue / 100;
        progressBar.Value = ProgressValue;
    }
}