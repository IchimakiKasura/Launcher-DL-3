namespace LauncherDL.Core.ConsoleDL;

internal partial class ConsoleLive
{
    static List<string> ProgressInfo;
    static string NetworkSpeedColor = string.Empty;
    static Regex DefaultRegex;

    public static void DownloadLiveOutputComment(object s, DataReceivedEventArgs e)
    {
        var StringData = e.Data;
        ProgressInfo = new(7);
        NetworkSpeedColor = string.Empty;

        if(StringData.IsEmpty()) return;

        if(Regex.IsMatch(StringData, PROCESSING_REGEX))
            DL_Dispatch.Invoke(ProcessMessage);

        DL_Dispatch.Invoke(DownloaderRegexChanged);

        if(FetchMatchedRegex(StringData))
            return;

        ForegroundSpeedColor();

        DL_Dispatch.Invoke(()=>Download_Invoke(DefaultRegex != DownloadInfoARIA2C));
    }

    static void Download_Invoke(bool IsFetchedFormat)
    {
        console.LoadText(ConsoleLastDocument);

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
        
        if(double.TryParse(_Progress, out Double value))
            progressBar.Value = value;
            
        TaskbarProgressBar.ProgressValue = progressBar.Value / 100;
    }

    static bool FetchMatchedRegex(string StringData)
    {
        List<Group> RegexMatchedStrings = DefaultRegex.Match(StringData).Groups.Cast<Group>().Skip(1).ToList();

        foreach (Group match in CollectionsMarshal.AsSpan(RegexMatchedStrings))
            if(!match.Value.IsEmpty())
                ProgressInfo.Add(match.Value.Trim());

        return ProgressInfo.Count <= 1 ? false : true;
    }

    static void ForegroundSpeedColor()
    {
       var DownSpeedSTR = 
            DefaultRegex == DownloadInfoARIA2C ?
                ProgressInfo[DOWNLOAD_SPEED] : ProgressInfo[DOWNLOAD_FMT_SPEED];

        if(double.TryParse(Regex.Replace(DownSpeedSTR, DOWNSPEED_REGEX, string.Empty),out Double SpeedNumber))
            switch(DownSpeedSTR)
            {
                case string str when str.Contains("K"):
                    NetworkSpeedColor = (SpeedNumber > DOWNSPEED_KB_LIMIT)
                    ? DOWNSPEED_COLOR_KB_HIGH
                    : DOWNSPEED_COLOR_KB_LOW;
                break;

                case string str when str.Contains("M"):
                    NetworkSpeedColor = (SpeedNumber > DOWNSPEED_MB_LIMIT)
                    ? DOWNSPEED_COLOR_MB_HIGH
                    : DOWNSPEED_COLOR_MB_LOW;
                break;

                case string str when str.Contains("G"):
                    NetworkSpeedColor = DOWNSPEED_COLOR_GB;
                break;
            };
    }

    static void ProcessMessage()
    {
        console.DLAddConsole(CONSOLE_PROCESSING, PROCESSING_MESSAGE);
        progressBar.Value = 99;
    }

    static void DownloaderRegexChanged()
    {
        DefaultRegex = DownloadInfoARIA2C;

        if (comboBoxType.ItemIndex is 0 && comboBoxFormat.HasItems && comboBoxFormat.ItemIndex > -1)
            DefaultRegex = DownloadInfoARIA2CFetchedFormat; 
    }
}