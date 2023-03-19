namespace LauncherDL.Core.Console_Output_Comment_Method;

public enum ConsoleOutputCheck
{
    SUCCESS,
    FAILED_MESSAGE,
    FAILED
}

internal static class ConsoleOutputMethod
{
    public const int TYPE = 0, FORMAT = 1, QUALITY = 2;

    /// <summary>
    /// extend ConsoleControl
    /// </summary>
    public static void DLAddConsole(this ConsoleControl console,string TypeString, string FormattedText, bool Italic = false, bool NoNL = false)
    {
        switch(TypeString)
        {
            case string when TypeString.Contains(CONSOLE_SYSTEM_STRING) && config.ShowSystemOutput:
                console.AddFormattedText($"{TypeString} {FormattedText}", Italic, NoNL);
            break;

            case string when !TypeString.Contains(CONSOLE_SYSTEM_STRING):
                console.AddFormattedText($"{TypeString} {FormattedText}", Italic, NoNL);
            break;
        };
    }
    
    public static void StartUpOutputComments()
    {
        console.AddFormattedText(CONSOLE_START);
        console.Break("Gray");

        console.AddFormattedText("<>welcome, <#ff4747%20|ExtraBlack>Hutao <>here!");

        // we do a little troll
        #if !DEBUG
            //InitiateTheWindow.InitiateMePlease = "Initiate";
        #endif
    }

    public async static void ConfigOutputComment(ConsoleOutputCheck IsSuccess, string error = default, string Name = default)
    {
        await WindowsComponents.WindowAwaitLoad(console.IsLoaded);
        
        switch(IsSuccess)
        {
            case ConsoleOutputCheck.SUCCESS: console.DLAddConsole(CONSOLE_SYSTEM_STRING, "<Green%14>SUCCESS <Gray%14>Config loaded");
            break;

            case ConsoleOutputCheck.FAILED_MESSAGE:
                console.DLAddConsole(CONSOLE_SYSTEM_STRING, $"<Red%14>FAILED <Gray%14>ERROR: loading [ {Name} ]");
                console.AddFormattedText($"<DimGray%12>ERROR: {error}", true);
            break;

            case ConsoleOutputCheck.FAILED: console.DLAddConsole(CONSOLE_SYSTEM_STRING, "<Red%14>FAILED <Gray%14>Default Config loaded");
            break;
        }
    }

    public async static void FFmpegOutputComment(ConsoleOutputCheck IsSuccess, string Filename = default)
    {
        await WindowsComponents.WindowAwaitLoad(console.IsLoaded);

        switch(IsSuccess)
        {
            case ConsoleOutputCheck.SUCCESS: console.DLAddConsole(CONSOLE_SYSTEM_STRING, "<Green%14>SUCCESS <Gray%14>FFmpeg is Available");
            break;

            case ConsoleOutputCheck.FAILED_MESSAGE:
                console.DLAddConsole(CONSOLE_SYSTEM_STRING, $"<Red%14>FAILED <Gray%14>ERROR: Some files are missing!");
                console.AddFormattedText($"<DimGray%12>ERROR: {Filename}", true);
            break;

            case ConsoleOutputCheck.FAILED: console.DLAddConsole(CONSOLE_SYSTEM_STRING, "<Red%14>FAILED <Gray%14>FFmpeg is Unavailable");
            break;
        }
    }

    public static void NoLinkOutputComment() =>
        console.DLAddConsole(CONSOLE_ERROR_SOFT_STRING, "<%14>No Link provided or Link is invalid");

    public static void ComboBoxChangedOutputComment(int ComboBoxControlType) =>
        console.DLAddConsole(CONSOLE_SYSTEM_STRING, ComboBoxControlType switch
        {
            TYPE    => $"<Gray%14>Changed TYPE to {comboBoxType.GetItemContent}",
            FORMAT  => $"<Gray%14>Changed FORMAT to {comboBoxFormat.GetItemContent}",
            QUALITY => $"<Gray%14>Changed QUALITY to {comboBoxQuality.GetItemContent}",
            _       => null
        });

    public static void MetadataOutputComment()
    {
        if(Old_Title is null) return;
        console.DLAddConsole(CONSOLE_INFO_STRING, "<%14> Metadata has been set!");
        console.AddFormattedText("<Gray%12>"+
            $"{CONSOLE_METADATA_TITLE       }"  +  $"{Old_Title        ?? "N\\A"} $nl$"  +      
            $"{CONSOLE_METADATA_ALBUM       }"  +  $"{Old_Album        ?? "N\\A"} $nl$"  +
            $"{CONSOLE_METADATA_ALBUM_ARTIST}"  +  $"{Old_Album_Artist ?? "N\\A"} $nl$"  +
            $"{CONSOLE_METADATA_YEAR        }"  +  $"{Old_Year         ?? "N\\A"} $nl$"  +
            $"{CONSOLE_METADATA_GENRE       }"  +  $"{Old_Genre        ?? "N\\A"}"
        );
    }

}