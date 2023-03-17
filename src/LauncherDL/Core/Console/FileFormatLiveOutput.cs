using System.Collections;
namespace LauncherDL.Core.ConsoleDL;

internal partial class ConsoleLive
{
    /// <summary>
    /// 0 = Id          <br/>
    /// 1 = Format      <br/>
    /// 2 = Resolution  <br/>
    /// 3 = FPS         <br/>
    /// 4 = Size        <br/>
    /// 5 = Bitrate     <br/>
    /// 6 = Codec
    /// </summary>
    static List<string> FormatStrings = new();
    static string AudioOnlyID_M4A,
                  AudioOnlyID_WEBM;

    public static void FileFormatLiveOutputComment(object s, DataReceivedEventArgs e) =>
        DL_Dispatch.Invoke(()=>FileFormat_Invoked(e.Data),e.Data);

    static void FileFormat_Invoked(string StringData)
    {
        FormatStrings = new();
        bool HasAudio = false;
        string VID_AO = null;

        foreach(Group match in FileFormatInfo.Match(StringData).Groups)
            if(!match.Name.Contains("0") && !string.IsNullOrEmpty(match.Value))
                FormatStrings.Add(match.Value.Trim());

        // Avoid video that has no Codec. It can cause weird issue when
        // merging 2 formats together.
        if(FormatStrings.Count != 7) return;
        
        string NameFormat = 
            new FormatName(
                ID      :       FormatStrings[0],
                FMT     :       FormatStrings[1],
                RES     :       FormatStrings[2],
                SIZE    :       FormatStrings[4]
            ).Name;
        
        switch(FormatStrings[3].Length)
        {
            case 1: if(FormatStrings[3].Contains("2")) FormatStrings[3] = "Stereo";             break;
            case 2: FormatStrings[3] += " fps";                                                 break;
            case 4: FormatStrings[3] = FormatStrings[3].Replace("1","  fps");                   break;
            case 5: FormatStrings[3] = FormatStrings[3].Replace(" 2","fps"); HasAudio = true;   break;
        };

        if(FormatStrings[2].Contains("audio only"))
        {   
            // Takes the latest Audio format ID
            switch(FormatStrings[1])
            {
                case "m4a" : AudioOnlyID_M4A  = FormatStrings[0];                               break;
                case "webm": AudioOnlyID_WEBM = FormatStrings[0];                               break;
            }
        }
        else
        {
            // Puts the latest Audio format ID to the video that has no 
            // Audio
            if(HasAudio) return;
            
            switch(FormatStrings[1])
            {
                case "mp4" : VID_AO = $"{FormatStrings[0]}+{AudioOnlyID_M4A}";                  break;
                case "webm": VID_AO = $"{FormatStrings[0]}+{AudioOnlyID_WEBM}";                 break;
            }
        }

        TemporaryList.Add(new()
        {
            Name        =       NameFormat,
            ID          =       FormatStrings[0],
            FORMAT      =       FormatStrings[1],
            RESOLUTION  =       FormatStrings[2],
            FPS         =       FormatStrings[3],
            SIZE        =       FormatStrings[4],
            BITRATE     =       FormatStrings[5],
            VID_W_AUD   =       VID_AO
        });

        console.DLAddConsole(CONSOLE_SYSTEM_STRING, $@"<Gray%14>Added: {FormatStrings[2]}$tab$$vbar$    {FormatStrings[4]}");
    }
}