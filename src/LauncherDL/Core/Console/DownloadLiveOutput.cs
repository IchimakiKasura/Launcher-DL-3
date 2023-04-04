namespace LauncherDL.Core.ConsoleDL;

internal partial class ConsoleLive
{
    static List<string> ProgressInfo;
    static string NetworkSpeedColor = "";

    public static void DownloadLiveOutputComment(object s, DataReceivedEventArgs e)
    {
        var StringData = e.Data;
        if(StringData.IsEmpty()) return;

        if(StringData.Contains("[ExtractAudio]") || StringData.Contains("[VideoConvertor]") || StringData.Contains("[Merger]"))
            DL_Dispatch.Invoke(()=>{
                console.DLAddConsole(CONSOLE_PROCESSING, PROCESSING_MESSAGE);
                progressBar.Value = 99;
            });

        ProgressInfo = new(7);
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
        switch(DownSpeedSTR)
        {
            case string str when str.Contains("K"):
                if (SpeedNumber > 199.99)
                    NetworkSpeedColor = DOWNSPEED_COLOR_KB_HIGH;
                else NetworkSpeedColor = DOWNSPEED_COLOR_KB_LOW;
            break;

            case string str when str.Contains("M"):
                if (SpeedNumber > 0.99)
                    NetworkSpeedColor = DOWNSPEED_COLOR_MB_HIGH;
                else NetworkSpeedColor = DOWNSPEED_COLOR_MB_LOW;
            break;

            case string str when str.Contains("G"):
                NetworkSpeedColor = DOWNSPEED_COLOR_GB;
            break;
        };
        #endregion

        DL_Dispatch.Invoke(()=>Download_Invoke(ref StringData, DefaultRegex != DownloadInfoARIA2C));
    }

    static void Download_Invoke(ref string StringData, bool IsFetchedFormat)
    {
        console.LoadText(ref ConsoleLastDocument);

        string
        _Progress   = IsFetchedFormat ? ProgressInfo[DOWNLOAD_FMT_PROGRESS] : ProgressInfo[DOWNLOAD_PROGRESS]   ,
        _Size       = IsFetchedFormat ? ProgressInfo[DOWNLOAD_FMT_SIZE]     : ProgressInfo[DOWNLOAD_SIZE]       ,
        _Speed      = IsFetchedFormat ? ProgressInfo[DOWNLOAD_FMT_SPEED]    : ProgressInfo[DOWNLOAD_SPEED]      ,
        _Time       = IsFetchedFormat ? "N/A"                               : ProgressInfo[DOWNLOAD_ETA]        ;

        var FormattedTextOutput = new StringBuilder();
        FormattedTextOutput.Append($"<Cyan>[ PROGRESS$tab$] <>{_Progress}%$nl$");
        FormattedTextOutput.Append($"<Cyan>[ SIZE$tab$$tab$] <>{_Size}$nl$");
        FormattedTextOutput.Append($"<Cyan>[ SPEED$tab$$tab$] <{NetworkSpeedColor}>{_Speed}/s$nl$");
        FormattedTextOutput.Append($"<Cyan>[ TIME (ETA)$tab$] <>{_Time}$nl$");

        console.AddFormattedText(FormattedTextOutput.ToString());
        
        double value = 0;
        double.TryParse(_Progress, out value);
        progressBar.Value = value;
            
        TaskbarProgressBar.ProgressValue = progressBar.Value / 100;
    }
}