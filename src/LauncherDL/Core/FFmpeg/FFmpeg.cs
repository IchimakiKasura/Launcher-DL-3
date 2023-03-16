namespace LauncherDL.Core.FFmpeg;

// ahaha
internal static partial class FFmpegFiles
{
    readonly static string FFmpegPath = "./LauncherDL_Data";
    static List<string> FileMissingOnly = new List<string>();
    public static bool ErrorOccured = false;
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

    public static void CheckFiles()
    {
        foreach(var Files in FileNames)
        {
            if(File.Exists($"{FFmpegPath}/{Files}"))
            {
                #if DEBUG
                    ConsoleDebug.LoadingFFmpeg(true, Files);
                #endif
            }
            else
            {
                FileMissingOnly.Add($"[{Files}], ");
                ErrorOccured = true;
                
                #if DEBUG
                    ConsoleDebug.LoadingFFmpeg(false, Files);
                #endif
            }
        }

        if(ErrorOccured)
        {
            var Filenames = "";

            foreach(var names in FileMissingOnly)
            {
                Filenames += $"{names}";
            }

            ConsoleOutputMethod.FFmpegOutputComment(1, Filenames);
            ConsoleOutputMethod.FFmpegOutputComment(2);
        } else ConsoleOutputMethod.FFmpegOutputComment(0);
    }
}