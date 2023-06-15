using static LauncherDL.Core.Console_Output_Comment_Method.ConsoleOutputCheck;
namespace LauncherDL.Core.FFmpeg;

// ahaha
internal sealed partial class FFmpegFiles
{
    readonly static string FFmpegPath = "./LauncherDL_Data";
    readonly static List<string> FileMissingOnly = new(9);
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

        #if DEBUG
            ConsoleDebug.LoadingFFmpegDone(!ErrorOccured);
        #endif
        
        if(ErrorOccured)
        {
            StringBuilder FilesMissing = new();

            foreach(var Names in FileMissingOnly)
                FilesMissing.Append($"{Names}");
            
            ConsoleOutputMethod.FFmpegOutputComment(FAILED_MESSAGE, FilesMissing.ToString());
            ConsoleOutputMethod.FFmpegOutputComment(FAILED);
        } else ConsoleOutputMethod.FFmpegOutputComment(SUCCESS);

        FileMissingOnly.Clear();
    }
}