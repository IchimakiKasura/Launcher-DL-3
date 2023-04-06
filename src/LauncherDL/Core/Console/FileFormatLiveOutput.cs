namespace LauncherDL.Core.ConsoleDL;

internal partial class ConsoleLive
{
    static List<string> FormatNames;
    static string AudioOnlyID_M4A, AudioOnlyID_WEBM;

    public static void FileFormatLiveOutputComment(object s, DataReceivedEventArgs e)
    {
        var StringData = e.Data;
        FormatNames     = new();
        bool HasAudio   = false;
        string VID_AO   = null;

        if(StringData.IsEmpty())
            return;

        if(FetchFormats(StringData) is false)
            return;
        
        switch(FormatNames[FPS].Length)
        {
            case 1: if(FormatNames[FPS].Contains("2")) FormatNames[FPS] = "Stereo";
                    else if(FormatNames[FPS].Contains("1")) FormatNames[FPS] = "N/A";           break;
            case 2: FormatNames[FPS] += " fps";                                                 break;
            case 4: FormatNames[FPS] = FormatNames[FPS].Replace("1","  fps");                   break;
            case 5: FormatNames[FPS] = FormatNames[FPS].Replace(" 2","fps"); HasAudio = true;   break;
        };
        
        if(FormatNames[RESOLUTION].Contains("audio only"))
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
                _ when FormatNames[FORMAT].Contains("mp4")  &&
                    !AudioOnlyID_M4A.IsEmpty()  =>
                    $"{FormatNames[ID]}+{AudioOnlyID_M4A}",

                _ when FormatNames[FORMAT].Contains("webm") &&
                    !AudioOnlyID_WEBM.IsEmpty() =>
                    $"{FormatNames[ID]}+{AudioOnlyID_WEBM}",

                _ => null
            };
        }

        TemporaryList.Add(new()
        {
            Name        = new FormatName(
                                pID:            FormatNames[ID],
                                pFORMAT:        FormatNames[FORMAT],
                                pRESOLUTION:    FormatNames[RESOLUTION],
                                pSIZE:          FormatNames[SIZE]
                        ).Name,

            ID          = FormatNames[ID],
            FORMAT      = FormatNames[FORMAT],
            RESOLUTION  = FormatNames[RESOLUTION],
            FPS         = FormatNames[FPS],
            SIZE        = FormatNames[SIZE],
            BITRATE     = FormatNames[BITRATE],
            VID_W_AUD   = VID_AO
        });

        DL_Dispatch.Invoke(()=>FileFormat_Invoked());
    }

    static bool FetchFormats(in string StringData)
    {
       List<Group> FileFormatInfoMatches = FileFormatInfo.Match(StringData).Groups.Cast<Group>().Skip(1).ToList();

        foreach(Group match in CollectionsMarshal.AsSpan(FileFormatInfoMatches))
        {
            if(!match.Value.IsEmpty())
                FormatNames.Add(match.Value.Trim());

            if(match.Name is "FPS" && match.Value.IsEmpty())
                FormatNames.Add("1");

            // Avoid video that has no Codec. It can cause weird issue when
            // merging a codec that is avc0
            if(match.Name is "Codec" && match.Value.IsEmpty())
                return false;
        }

        return FormatNames.Count is 0 ? false : true;
    }

    static void FileFormat_Invoked()
    {
        progressBar.Value += 25;
        if (progressBar.Value >= 90) progressBar.Value += 75;
        
        console.DLAddConsole(CONSOLE_SYSTEM_STRING, $@"<Gray%14>Added: {FormatNames[RESOLUTION]}$tab$$tab$$vbar$ {FormatNames[SIZE]}$tab$$vbar$ {FormatNames[FORMAT]}");
    }
    
}