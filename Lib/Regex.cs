namespace Launcher_DL_v6;

public static class LauncherDL_Regex
{
    // RichTextBox
    readonly public static Regex RTBregex = new(@"<(?<color>.*?)(?:%(?:(?<size>.*?)\|(?<weight>.*?))|%(?<sizeOnly>.*?)|)>(?<text>.*?)(?=<|$)", RegexOptions.Compiled);

    // Url
    readonly public static Regex URLTitle = new(@"<title>(?<title>.*?)</title>", RegexOptions.Compiled);
    readonly public static Regex URLname = new(@"\.(?<host>.*?)\.", RegexOptions.Compiled);

    // Output Console
    readonly public static Regex progress = new(@"\[.*\].*?(?<percent>.*?)% of (?<size>.*) at (?<speed>.*) ETA (?<time>.*)", RegexOptions.Compiled);

    // Fileformat
    readonly public static Regex Info = new(@"(?<id>.*?) .*(?<format>mp4.*?|webm.*?|3gp.*?|m4a.*?|mp3.*?).*(?:(?<fullResolution> [0-9]*x[0-9]*)|(?<audioOnly>audio only)).*?(?<fps>[0-9]*).\|.*?(?<size>.*)(?<Videobitrate>\D[0-9]*k).*?\|.*?", RegexOptions.Compiled);
    readonly public static Regex SelectedRes = new(@"\[.*\].*(?<name>(?:\D+.*p|audio only)).*-(?<size>.*?);", RegexOptions.Compiled);

    // kasu Extension
    readonly public static Regex KasuExtension = new("BackgroundName:*.\"(?<BackgroundName>.*)\"|BackgroundColor:*.\"(?<BackgroundColor>.*)\"|GlowColor:*.\"(?<GlowColor>.*)\"|DefaultFileTypeOnStartUp:*.\"(?<DefaultFileTypeOnStartUp>.*)\"|AlwayDownloadInMP3:*.\"(?<AlwayDownloadInMP3>.*)\"|ShowSystemOutput:*.\"(?<ShowSystemOutput>.*)\"|EnablePlaylist:*.\"(?<EnablePlaylist>.*)\"", RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Multiline);

}