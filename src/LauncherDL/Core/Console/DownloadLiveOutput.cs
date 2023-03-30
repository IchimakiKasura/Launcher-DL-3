namespace LauncherDL.Core.ConsoleDL;

internal partial class ConsoleLive
{
    #region Constants STR | Should I use Enum?
    const int 
    DOWNLOAD_SIZE           = 0,
    DOWNLOAD_PROGRESS       = 1,
    DOWNLOAD_SPEED          = 2,
    DOWNLOAD_ETA            = 3,
    DOWNLOAD_FMT_SPEED      = 0,
    DOWNLOAD_FMT_SIZE       = 1,
    DOWNLOAD_FMT_PROGRESS   = 2;
    #endregion

    static List<string> ProgressInfo;
    static string NetworkSpeedColor = "";

    public static void DownloadLiveOutputComment(object s, DataReceivedEventArgs e)
    {
        var StringData = e.Data;
        if(StringData.IsEmpty()) return;

        if(StringData.Contains("[ExtractAudio]") || StringData.Contains("[VideoConvertor]") || StringData.Contains("[Merger]"))
            DL_Dispatch.Invoke(()=>{
                console.DLAddConsole(CONSOLE_PROCESSING,"Please wait until its finished processing.");
                progressBar.Value = 99;
            });

        ProgressInfo = new();
        NetworkSpeedColor = "";

        var DefaultRegex = DownloadInfoARIA2C;

        DL_Dispatch.Invoke(()=>{
            if(comboBoxType.ItemIndex is 0 && comboBoxFormat.HasItems && comboBoxFormat.ItemIndex > -1)
                DefaultRegex = DownloadInfoARIA2CFetchedFormat; 
        });

        foreach(Group match in DefaultRegex.Match(StringData).Groups)
            if(!match.Name.Contains("0") && !match.Value.IsEmpty())
                ProgressInfo.Add(match.Value.Trim());
            
        if(ProgressInfo.Count <= 1) return;

        #region Change Foreground based on the speed.
        double SpeedNumber = 0;

        var DownSpeedSTR = 
            DefaultRegex == DownloadInfoARIA2C ?
                ProgressInfo[DOWNLOAD_SPEED] : ProgressInfo[DOWNLOAD_FMT_SPEED];

        double.TryParse(Regex.Replace(DownSpeedSTR, @"~|[a-zA-Z\/]", ""),out SpeedNumber);
        switch("")
        {
            case string when DownSpeedSTR.Contains("K"):
                if (SpeedNumber > 199.99) NetworkSpeedColor = "Red";
                else NetworkSpeedColor = "#381900";
            break;

            case string when DownSpeedSTR.Contains("M"):
                if (SpeedNumber > 0.99) NetworkSpeedColor = "#83fa57";
                else NetworkSpeedColor = "#fff154";
            break;

            case string when DownSpeedSTR.Contains("G"):
                NetworkSpeedColor = "Pink";
            break;
        };
        #endregion

        DL_Dispatch.Invoke(()=>Download_Invoke(StringData, DefaultRegex != DownloadInfoARIA2C));
    }

    //FIXME: Refactor it? if possible future me;
    static void Download_Invoke(string StringData, bool IsFetchedFormat)
    {
        console.LoadText(ConsoleLastDocument);

        string
        _Progress   ,
        _Size       ,
        _Speed      ,
        _Time       = "N/A";

        if(IsFetchedFormat)
        {
            _Speed      = ProgressInfo[DOWNLOAD_FMT_SPEED];
            _Size       = ProgressInfo[DOWNLOAD_FMT_SIZE];
            _Progress   = ProgressInfo[DOWNLOAD_FMT_PROGRESS];
        }
        else
        {
            _Size       = ProgressInfo[DOWNLOAD_SIZE];
            _Progress   = ProgressInfo[DOWNLOAD_PROGRESS];
            _Speed      = ProgressInfo[DOWNLOAD_SPEED];
            _Time       = ProgressInfo[DOWNLOAD_ETA];
        }

        console.AddFormattedText(
            $"<Cyan>[ PROGRESS$tab$] <>{_Progress}%$nl$"+
            $"<Cyan>[ SIZE$tab$$tab$] <>{_Size}$nl$"+
            $"<Cyan>[ SPEED$tab$$tab$] <{NetworkSpeedColor}>{_Speed}/s$nl$"+
            $"<Cyan>[ TIME (ETA)$tab$] <>{_Time}$nl$"
        );
        
        double value = 0;
        double.TryParse(_Progress, out value);
        progressBar.Value = value;
            
        TaskbarProgressBar.ProgressValue = progressBar.Value / 100;
    }
}