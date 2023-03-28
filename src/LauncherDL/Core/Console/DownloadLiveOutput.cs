namespace LauncherDL.Core.ConsoleDL;

internal partial class ConsoleLive
{
    #region Constants STR
    const int 
    DOWNLOAD_SIZE       = 0,
    DOWNLOAD_PROGRESS   = 1,
    DOWNLOAD_SPEED      = 2,
    DOWNLOAD_ETA        = 3;
    #endregion
    static List<string> ProgressInfo;
    static string NetworkSpeedColor = "";

    public static void DownloadLiveOutputComment(object s, DataReceivedEventArgs e)
    {
        var StringData = e.Data;
        if(StringData.IsEmpty()) return;

        if(StringData.Contains("[ExtractAudio]") || StringData.Contains("[VideoConvertor]"))
            DL_Dispatch.Invoke(()=>{
                console.DLAddConsole(CONSOLE_PROCESSING,"Please wait until its finished processing.");
                progressBar.Value = 99;
            });

        ProgressInfo = new();
        NetworkSpeedColor = "";

        foreach(Group match in DownloadInfoARIA2C.Match(StringData).Groups)
            if(!match.Name.Contains("0") && !match.Value.IsEmpty())
                ProgressInfo.Add(match.Value.Trim());
            
        if(ProgressInfo.Count <= 1) return;

        #region Change Foreground based on the speed.
        double SpeedNumber = 0;
        double.TryParse(Regex.Replace($"{ProgressInfo[DOWNLOAD_SPEED] ?? "0.0"}", @"[a-zA-Z\/]", "").Replace("~","").ToString(),out SpeedNumber);
        switch("")
        {
            case string when ProgressInfo[DOWNLOAD_SPEED].Contains("K"):
                if (SpeedNumber > 199.99) NetworkSpeedColor = "Red";
                else NetworkSpeedColor = "#381900";
            break;

            case string when ProgressInfo[DOWNLOAD_SPEED].Contains("M"):
                if (SpeedNumber > 0.99) NetworkSpeedColor = "#83fa57";
                else NetworkSpeedColor = "#fff154";
            break;

            case string when ProgressInfo[DOWNLOAD_SPEED].Contains("G"):
                NetworkSpeedColor = "Pink";
            break;
        };
        #endregion

        DL_Dispatch.Invoke(()=>Download_Invoke(StringData));
    }

    static void Download_Invoke(string StringData)
    {
        console.LoadText(ConsoleLastDocument);

        console.AddFormattedText(
            $"<Cyan>[ PROGRESS$tab$] <>{ProgressInfo[DOWNLOAD_PROGRESS]}%$nl$"+
            $"<Cyan>[ SIZE$tab$$tab$] <>{ProgressInfo[DOWNLOAD_SIZE]}$nl$"+
            $"<Cyan>[ SPEED$tab$$tab$] <{NetworkSpeedColor}>{ProgressInfo[DOWNLOAD_SPEED]}/s$nl$"+
            $"<Cyan>[ TIME (ETA)$tab$] <>{ProgressInfo[DOWNLOAD_ETA]}$nl$"
        );
        
        double value = 0;
        double.TryParse($"{ProgressInfo[DOWNLOAD_PROGRESS] ?? "0.0"}", out value);
        progressBar.Value = value;
            
        TaskbarProgressBar.ProgressValue = progressBar.Value / 100;
    }
}