namespace Launcher_DL.Core.FFmpeg;

internal static class FFmpeg
{
    readonly static string FFmpegPath = "./LauncherDL_Data";

    public static void CheckFiles()
    {
        File.Exists(FFmpegPath);
    }
}