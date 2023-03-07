namespace Launcher_DL.Core.FFmpeg;

// ahaha
internal static partial class FFmpegFiles
{
    readonly static string FFmpegPath = "./LauncherDL_Data";
    static List<string> FileMissingOnly = new List<string>();
    static bool ErrorOccured = false;

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