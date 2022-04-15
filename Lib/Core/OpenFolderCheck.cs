namespace Launcher_DL.Lib.Core;

sealed class OpenFolderCheck : Global
{
    public static void OpenFolderChecks()
    {
        if (Directory.Exists($"{Directory.GetCurrentDirectory()}\\{Config.DefaultOutput}")) Open_Folder.Visibility = Visibility.Visible;
        if (Config.DefaultOutput != "output" && Directory.Exists(Config.DefaultOutput)) Open_Folder.Visibility = Visibility.Visible;

        OpenDir_Audio.IsEnabled = FileExist("Audio");
        OpenDir_Video.IsEnabled = FileExist("Video");
        OpenDir_Convert.IsEnabled = FileExist("Convert");
        OpenDir_webm.IsEnabled = FileExist("formatted\\webm");
        OpenDir_mFourA.IsEnabled = FileExist("formatted\\m4a");
        OpenDir_mpFour.IsEnabled = FileExist("formatted\\mp4");
        OpenDir_mpThree.IsEnabled = FileExist("formatted\\mp3");
        OpenDir_threeGP.IsEnabled = FileExist("formatted\\3gp");
        OpenDir_flv.IsEnabled = FileExist("formatted\\flv");
        OpenDir_mkv.IsEnabled = FileExist("formatted\\mkv");

        OpenDir_Logs.IsEnabled = Directory.Exists("Logs");
    }

    private static bool FileExist(string dir)
    {
        return Directory.Exists($"{Config.DefaultOutput}\\{dir}");
    }
}