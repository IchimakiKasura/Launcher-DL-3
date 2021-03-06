namespace Launcher_DL.Lib;

public static class RegexComp
{
	// Url
	readonly public static Regex URLTitle = new(@"<title>(?<title>.*?)</title>", RegexOptions.Compiled);
	readonly public static Regex URLname = new(@"\.(?<host>.*?)\.", RegexOptions.Compiled);

	// Output Console
	readonly public static Regex progress = new(@"\[.*\].*?(?<percent>.*?)% of (?<size>.*) at (?<speed>.*) ETA (?<time>.*)", RegexOptions.Compiled);

	// Fileformat
	readonly public static Regex Info = new(@"(?<id>.*?) .*(?<format>mp4.*?|webm.*?|3gp.*?|m4a.*?|mp3.*?).*(?:(?<fullResolution> [0-9]*x[0-9]*)|(?<audioOnly>audio only)).*?(?<fps>[0-9]*).\|.*?(?<size>.*)(?<Videobitrate>\D[0-9]*k).*?\|.(?<Vcodec>(?:mp4v.*?|(?:avc1.*?|(?:vp9.*?|(?:audio only|)))))", RegexOptions.Compiled);
	readonly public static Regex SelectedRes = new(@"\[.*\].*(?<name>(?:\D+.*p|audio only)).*-(?<size>.*?);", RegexOptions.Compiled);

	// kasu Extension
	readonly public static Regex KasuExtension = new("BackgroundName:.*\"(?<BackgroundName>.*)\"|GlowColor:.*\"(?<GlowColor>.*)\"|DefaultFileTypeOnStartUp:.*\"(?<DefaultFileTypeOnStartUp>.*)\"|AlwayDownloadInMP3:.*\"(?<AlwayDownloadInMP3>.*)\"|ShowSystemOutput:.*\"(?<ShowSystemOutput>.*)\"|EnablePlaylist:.*\"(?<EnablePlaylist>.*)\"|Language:.*\"(?<Language>.*)\"|DefaultOutput:.*\"(?<DefaultOutput>.*)\"|BackgroundColor:.*\"(?<BackgroundColor>.*)\"|AllowCookies:.*\"(?<AllowCookies>.*)\"|EpicAnimations:.*\"(?<EpicAnimations>.*)\"|BrowserCookie:.*\"(?<BrowserCookie>.*)\"", RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Multiline);

	// Conversion
	readonly public static Regex C_Current = new(@"time=(?<CurrentTime>[\d\w:]{8})");
	readonly public static Regex C_Total = new(@"Duration:.*?(?<TotalTime>[\d\w:]{8})");

}