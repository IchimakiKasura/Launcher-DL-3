namespace LauncherDL.Core.RegexComponent;

public partial class RegexComponentList
{
    // File Format
    [GeneratedRegex(@"(?<id>.*?) .*(?<format>mp4.*?|webm.*?|3gp.*?|m4a.*?|mp3.*?).*(?:(?<Resolution> [0-9]*x[0-9]*|[0-9]*X[0-9]*)|(?<AO>audio only)).*?(?:(?<FPS>\d[0-9]?.*?|))\|.*?(?<Size>.*?)(?<Bitrate>\D[0-9]*k).*?\|.(?<Codec>(?:mp4v.*?|(?:avc1.*?|(?:vp9.*?|(?:vp09.*?|(?:audio only|))))))", RegexOptions.Compiled)]
    private static partial Regex _FileFormatInfo();

    [GeneratedRegex(@"\[.*\#[\d\w]*.?(?<size>.*)\/.*\((?<progress>.*)\%\) CN.*DL:(?<speed>.*)ETA:(?<time>.*)]", RegexOptions.Compiled)]
    private static partial Regex _DownloadInfoARIA2C();
    
    [GeneratedRegex(@"\[DL:(?<speed>.*?)\].*\[.?#[\d\w].*? (?<size>.*)\/.*?\((?<progress>.*)\%.*?\)", RegexOptions.Compiled)]
    private static partial Regex _DownloadInfoARIA2CFetchedFormat();

    // FFmpeg
    [GeneratedRegex(@"time=(?<CurrentTime>[\d\w:]{8})", RegexOptions.Compiled)]
    private static partial Regex _ConvertCurrent();
    [GeneratedRegex(@"Duration:.*?(?<TotalTime>[\d\w:]{8})", RegexOptions.Compiled)]
    private static partial Regex _ConvertTotal();

    // Validate
    [GeneratedRegex(@"<title>(?<title>.*?)</title>", RegexOptions.Compiled)]
    private static partial Regex _URLTitle();
    [GeneratedRegex(@"\.(?<host>.*?)\.", RegexOptions.Compiled)]
    private static partial Regex _URLname();

    /// <summary>
    /// Group Names in Order:<br/>
    /// id          <br/>
    /// format      <br/>
    /// Resolution  <br/>
    /// AO          <br/>
    /// FPS         <br/>
    /// Size        <br/>
    /// Bitrate     <br/>
    /// Codec
    /// </summary>
    readonly public static Regex FileFormatInfo = _FileFormatInfo();
    readonly public static Regex DownloadInfoARIA2C = _DownloadInfoARIA2C();
    readonly public static Regex DownloadInfoARIA2CFetchedFormat = _DownloadInfoARIA2CFetchedFormat();
    readonly public static Regex ConvertCurrent = _ConvertCurrent();
    readonly public static Regex ConvertTotal = _ConvertTotal();
    readonly public static Regex URLTitle = _URLTitle();
    readonly public static Regex URLname = _URLname();


    //Legacy
    // Download progress
    // [GeneratedRegex(@"\[.*\].*?(?<percent>.*?)% of (?<size>.*) at (?<speed>.*) ETA (?<time>.*)", RegexOptions.Compiled)]
    // private static partial Regex _DownloadInfo();
    // readonly public static Regex DownloadInfo = _DownloadInfo();
}