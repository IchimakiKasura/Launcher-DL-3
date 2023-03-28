namespace LauncherDL.Core.ConsoleDL;

internal partial class ConsoleLive
{
    #region Constants STR
    const int ID            = 0,
              FORMAT        = 1,
              RESOLUTION    = 2,
              FPS           = 3,
              SIZE          = 4,
              BITRATE       = 5;
    #endregion

    static List<string> FormatNames = new();
    static string AudioOnlyID_M4A, AudioOnlyID_WEBM;

    public static void FileFormatLiveOutputComment(object s, DataReceivedEventArgs e)
    {
        var StringData = e.Data;

        if(StringData.IsEmpty()) return;

        FormatNames     = new();
        bool HasAudio   = false;
        string VID_AO   = null;

        foreach(Group match in FileFormatInfo.Match(StringData).Groups)
            if(!match.Name.Contains("0") && !match.Value.IsEmpty())
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
            switch(FormatNames[FORMAT])
            {
                case "m4a" : AudioOnlyID_M4A  = FormatNames[ID];                                break;
                case "webm": AudioOnlyID_WEBM = FormatNames[ID];                                break;
            }
        else
        {
            if(HasAudio) return;
        
            // Puts the latest Audio format ID to the video that has no Audio
            VID_AO = FormatNames[FORMAT] switch
            {
                _ when FormatNames[FORMAT].Contains("mp4") =>
                    $"{FormatNames[ID]}+{AudioOnlyID_M4A}",
                _ when FormatNames[FORMAT].Contains("webm")=>
                    $"{FormatNames[ID]}+{AudioOnlyID_WEBM}",
                _ => null
            };
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

        DL_Dispatch.Invoke(()=>FileFormat_Invoked(StringData));
    }

    static void FileFormat_Invoked(string StringData)
    {
        //// [3/27/2023] This code is straight up from v6 :D
        // ProgressBar lmao 
        progressBar.Value += 25;

        if (progressBar.Value >= 90)
            progressBar.Value += 75;
        ////

        console.DLAddConsole(CONSOLE_SYSTEM_STRING, $@"<Gray%14>Added: {FormatNames[RESOLUTION]}$tab$$tab$$vbar$ {FormatNames[SIZE]}$tab$$vbar$ {FormatNames[FORMAT]}");
    }
    
}