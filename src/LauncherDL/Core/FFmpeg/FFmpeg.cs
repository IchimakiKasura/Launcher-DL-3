namespace LauncherDL.Core.FFmpeg;

// ahaha
internal static partial class FFmpegFiles
{
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