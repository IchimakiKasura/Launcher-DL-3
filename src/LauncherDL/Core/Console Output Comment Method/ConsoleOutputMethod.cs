namespace LauncherDL.Core.Console_Output_Comment_Method;

// They call me a madman
internal static class ConsoleOutputMethod
{
    /// <summary>
    /// extend ConsoleControl
    /// </summary>
    public static void DLAddConsole(this ConsoleControl console,string Type, string FormattedText, bool Italic = false, bool NoNL = false)
    {
        // Check if its a "SYSTEM" and systemoutput is enabled
        if(Type.Contains(CONSOLE_SYSTEM_STRING) && config.ShowSystemOutput)
            console.AddFormattedText($"{Type} {FormattedText}", Italic, NoNL);
        
        if(!Type.Contains(CONSOLE_SYSTEM_STRING))
            console.AddFormattedText($"{Type} {FormattedText}", Italic, NoNL);
    }

    public static void          StartUpOutputComments()
    {
        console.AddFormattedText                    (CONSOLE_START);
        console.Break                               ("Gray");

        console.AddFormattedText                    ("<>welcome, <#ff4747%20|ExtraBlack>Hutao <>here!");

        // we do a little troll
        #if !DEBUG
            InitiateTheWindow.InitiateMePlease      = "Initiate";
        #endif
    }

    public async static void    ConfigOutputComment(int IsSuccess, string error = default, string Name = default)
    {
        await WindowsComponents.WindowAwaitLoad     (console.IsLoaded);
        
        switch(IsSuccess)
        {
            case 0: console.DLAddConsole            (CONSOLE_SYSTEM_STRING, "<Green%14>SUCCESS <Gray%14>Config loaded");
            break;

            case 1:
                console.DLAddConsole                (CONSOLE_SYSTEM_STRING, $"<Red%14>FAILED <Gray%14>ERROR: loading [ {Name} ]");
                console.AddFormattedText            ($"<DimGray%12>ERROR: {error}", true);
            break;

            case 2: console.DLAddConsole            (CONSOLE_SYSTEM_STRING, "<Red%14>FAILED <Gray%14>Default Config loaded");
            break;
        }
    }

    public async static void    FFmpegOutputComment(int IsSuccess, string Filename = default)
    {
        await WindowsComponents.WindowAwaitLoad     (console.IsLoaded);

        switch(IsSuccess)
        {
            case 0: console.DLAddConsole            (CONSOLE_SYSTEM_STRING, "<Green%14>SUCCESS <Gray%14>FFmpeg is Available");
            break;

            case 1:
                console.DLAddConsole                (CONSOLE_SYSTEM_STRING, $"<Red%14>FAILED <Gray%14>ERROR: Some files are missing!");
                console.AddFormattedText            ($"<DimGray%12>ERROR: {Filename}", true);
            break;

            case 2: console.DLAddConsole            (CONSOLE_SYSTEM_STRING, "<Red%14>FAILED <Gray%14>FFmpeg is Unavailable");
            break;
        }
    }

    public static void          TypeChangedOutputComment() =>
        console.DLAddConsole                       (CONSOLE_SYSTEM_STRING, $"<Gray%14>Changed TYPE to {comboBoxType.GetItemContent}");
    
    public static void          NoLinkOutputComment() =>
        console.DLAddConsole                       (CONSOLE_ERROR_SOFT_STRING, "<%14>No Link provided or Link is invalid");


}
