namespace LauncherDL.Core.RegexComponent;

public partial class RegexComponentList
{
    [GeneratedRegex(@"(?<id>.*?) .*(?<format>mp4.*?|webm.*?|3gp.*?|m4a.*?|mp3.*?).*(?:(?<Resolution> [0-9]*x[0-9]*)|(?<AO>audio only)).*?(?:(?<FPS>\d[0-9]?.*)).\|.*?(?<Size>.*)(?<Bitrate>\D[0-9]*k).*?\|.(?<Codec>(?:mp4v.*?|(?:avc1.*?|(?:vp9.*?|(?:audio only|)))))", RegexOptions.Compiled)]
    private static partial Regex _FileFormatInfo();
    [GeneratedRegex(@"\[.*\].*?(?<percent>.*?)% of (?<size>.*) at (?<speed>.*) ETA (?<time>.*)", RegexOptions.Compiled)]
    private static partial Regex _ProgressBarInfo();

    [GeneratedRegex(@"time=(?<CurrentTime>[\d\w:]{8})", RegexOptions.Compiled)]
    private static partial Regex _ConvertCurrent();
    [GeneratedRegex(@"Duration:.*?(?<TotalTime>[\d\w:]{8})", RegexOptions.Compiled)]
    private static partial Regex _ConvertTotal();

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
    readonly public static Regex ProgressBarInfo = _ProgressBarInfo();
    readonly public static Regex ConvertCurrent = _ConvertCurrent();
    readonly public static Regex ConvertTotal = _ConvertTotal();
}