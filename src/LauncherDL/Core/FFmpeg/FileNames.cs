namespace LauncherDL.Core.FFmpeg;

internal static partial class FFmpegFiles
{
    readonly static string FFmpegPath = "./LauncherDL_Data";
    static List<string> FileMissingOnly = new List<string>();
    static bool ErrorOccured = false;
    
    readonly static string[] FileNames =
    {
        "avcodec-60.dll",
        "avdevice-60.dll",
        "avfilter-9.dll",
        "avformat-60.dll",
        "avutil-58.dll",
        "postproc-57.dll",
        "swresample-4.dll",
        "swscale-7.dll",
        "ffmpeg.exe",
        "ffprobe.exe"
    };
}