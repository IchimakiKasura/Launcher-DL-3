namespace LauncherDL.Core.Console_Output_Comment_Method;

/// <summary>
/// Where string are repeatedly called so<br/>
/// made it into a class which a single call<br/>
/// can output multiple comment
/// </summary>
internal static class ConsoleOutputMethod
{
    public static void StartUpOutputComments()
    {
        console.AddFormattedText(CONSOLE_START);
        console.Break("Gray");

        console.AddFormattedText("<>welcome, <#ff4747%20|ExtraBlack>Hutao <>here!");

        // we do a little troll
        #if !DEBUG
            InitiateTheWindow.InitiateMePlease = "Initiate";
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
        console.DLAddConsole(CONSOLE_ERROR_SOFT_STRING, "No Link provided or Link is invalid");

    public static void ComboBoxChangedOutputComment(ConsoleOutputMethodSelection ComboBoxControlType) =>
        console.DLAddConsole(CONSOLE_SYSTEM_STRING, ComboBoxControlType switch
        {
            ConsoleOutputMethodSelection.TYPE    => $"<Gray%14>Changed TYPE to {comboBoxType.GetItemContent}",
            ConsoleOutputMethodSelection.FORMAT  => $"<Gray%14>Changed FORMAT to {comboBoxFormat.GetItemContent}",
            ConsoleOutputMethodSelection.QUALITY => $"<Gray%14>Changed QUALITY to {comboBoxQuality.GetItemContent}",
            _                                    => null
        });

    public static void DownloadInfoOutputComment(ObjectListNames Obj)
    {
        var OutputComment = new StringBuilder()
            .Append("Downloading Please wait$nl$")
            .Append($"<Gray%10>[] Title$tab$$tab$: {Obj.Title}$nl$")
            .Append($"<Gray%10>[] Download Type$tab$: {Obj.Type}$nl$")
            .Append($"<Gray%10>[] Name$tab$$tab$: {Obj.Name}$nl$")
            .Append($"<Gray%10>[] Format$tab$$tab$: {Obj.Format}$nl$")
            .Append($"<Gray%10>[] Link$tab$$tab$: {Obj.Link}$nl$")
            .ToString();

        console.DLAddConsole(CONSOLE_INFO_STRING,OutputComment);
    }

    public static void MetadataOutputComment()
    {
        console.DLAddConsole(CONSOLE_INFO_STRING, "Metadata has been set!");

        var MetadataOutputComment = new StringBuilder()
            .Append("<Gray%12>")
            .Append($"{CONSOLE_METADATA_TITLE       }"  +  $"{Old_Title        ?? "N\\A"}$nl$")
            .Append($"{CONSOLE_METADATA_ALBUM       }"  +  $"{Old_Album        ?? "N\\A"}$nl$")
            .Append($"{CONSOLE_METADATA_ALBUM_ARTIST}"  +  $"{Old_Album_Artist ?? "N\\A"}$nl$")
            .Append($"{CONSOLE_METADATA_YEAR        }"  +  $"{Old_Year         ?? "N\\A"}$nl$")
            .Append($"{CONSOLE_METADATA_GENRE       }"  +  $"{Old_Genre        ?? "N\\A"}")
            .ToString();

        console.AddFormattedText(MetadataOutputComment);
    }

}