namespace LauncherDL.Core.RegexComponent;

public partial class RegexComponentList
{
    [GeneratedRegex(@"(?<id>.*?) .*(?<format>mp4.*?|webm.*?|3gp.*?|m4a.*?|mp3.*?).*(?:(?<fullResolution> [0-9]*x[0-9]*)|(?<audioOnly>audio only)).*?(?:(?<fps>\d[0-9]?.*)).\|.*?(?<size>.*)(?<Videobitrate>\D[0-9]*k).*?\|.(?<Vcodec>(?:mp4v.*?|(?:avc1.*?|(?:vp9.*?|(?:audio only|)))))", RegexOptions.Compiled)]
    private static partial Regex _FileFormatInfo();
    [GeneratedRegex(@"\[.*\].*?(?<percent>.*?)% of (?<size>.*) at (?<speed>.*) ETA (?<time>.*)", RegexOptions.Compiled)]
    private static partial Regex _ProgressBarInfo();

    [GeneratedRegex(@"time=(?<CurrentTime>[\d\w:]{8})", RegexOptions.Compiled)]
    private static partial Regex _ConvertCurrent();
       [GeneratedRegex(@"Duration:.*?(?<TotalTime>[\d\w:]{8})", RegexOptions.Compiled)]
    private static partial Regex _ConvertTotal();


    readonly private static Regex FileFormatInfo = _FileFormatInfo();
    readonly private static Regex ProgressBarInfo = _ProgressBarInfo();
    readonly private static Regex ConvertCurrent = _ConvertCurrent();
    readonly private static Regex ConvertTotal = _ConvertTotal();
}