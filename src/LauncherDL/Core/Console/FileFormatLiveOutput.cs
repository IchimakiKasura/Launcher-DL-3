namespace LauncherDL.Core.ConsoleDL;

internal partial class ConsoleLive
{
    #region Constants
    const int ID            = 0,
              FORMAT        = 1,
              RESOLUTION    = 2,
              FPS           = 3,
              SIZE          = 4,
              BITRATE       = 5;
    #endregion

    static List<string> FormatNames = new();
    static string AudioOnlyID_M4A, AudioOnlyID_WEBM;

    public static void FileFormatLiveOutputComment(object s, DataReceivedEventArgs e) =>
        DL_Dispatch.Invoke(()=>FileFormat_Invoked(e.Data),e.Data);

    static void FileFormat_Invoked(string StringData)
    {
        FormatNames     = new();
        bool HasAudio   = false;
        string VID_AO   = null;

        foreach(Group match in FileFormatInfo.Match(StringData).Groups)
            if(!match.Name.Contains("0") && !string.IsNullOrEmpty(match.Value))
                FormatNames.Add(match.Value.Trim());

        // Avoid video that has no Codec. It can cause weird issue when
        // merging 2 formats together.
        if(FormatNames.Count != 7) return;
        
        string NameFormat = 
            new FormatName(
                ID      :       FormatNames[ID],
                FMT     :       FormatNames[FORMAT],
                RES     :       FormatNames[RESOLUTION],
                SIZE    :       FormatNames[SIZE]
            ).Name;
        
        switch(FormatNames[FPS].Length)
        {
            case 1: if(FormatNames[FPS].Contains("2")) FormatNames[FPS] = "Stereo";             break;
            case 2: FormatNames[FPS] += " fps";                                                 break;
            case 4: FormatNames[FPS] = FormatNames[FPS].Replace("1","  fps");                   break;
            case 5: FormatNames[FPS] = FormatNames[FPS].Replace(" 2","fps"); HasAudio = true;   break;
        };

        if(FormatNames[RESOLUTION].Contains("audio only"))
            // Takes the latest Audio format ID
            switch(FormatNames[1])
            {
                case "m4a" : AudioOnlyID_M4A  = FormatNames[ID];                                break;
                case "webm": AudioOnlyID_WEBM = FormatNames[ID];                                break;
            }
        else
        {
            // Puts the latest Audio format ID to the video that has no Audio
            if(HasAudio) return;
            
            // New
            VID_AO = FormatNames[FORMAT] switch
            {
                string when FormatNames[FORMAT].Contains("mp4") =>
                    $"{FormatNames[ID]}+{AudioOnlyID_M4A}",
                string when FormatNames[FORMAT].Contains("webm")=>
                    $"{FormatNames[ID]}+{AudioOnlyID_WEBM}",
                _ => null
            };

            // Old
            // switch(FormatNames[FORMAT])
            // {
            //     case "mp4" : VID_AO = $"{FormatNames[ID]}+{AudioOnlyID_M4A}";                   break;
            //     case "webm": VID_AO = $"{FormatNames[ID]}+{AudioOnlyID_WEBM}";                  break;
            // }
        }

        TemporaryList.Add(new()
        {
            Name        =       NameFormat,
            ID          =       FormatNames[ID],
            FORMAT      =       FormatNames[FORMAT],
            RESOLUTION  =       FormatNames[RESOLUTION],
            FPS         =       FormatNames[FPS],
            SIZE        =       FormatNames[SIZE],
            BITRATE     =       FormatNames[BITRATE],
            VID_W_AUD   =       VID_AO
        });

        console.DLAddConsole(CONSOLE_SYSTEM_STRING, $@"<Gray%14>Added: {FormatNames[RESOLUTION]}$tab$$vbar$    {FormatNames[SIZE]}");
    }
}