namespace Launcher_DL.Lib.TaskProcess;

sealed class ConvertProcess : Global
{
    public async static Task ConvertFileType(string Command)
    {
        Proc = new();
        Proc.StartInfo = new($"{Ffmpeg}\\ffmpeg.exe", Command)
        {
            UseShellExecute = false,
            RedirectStandardError = true,
            CreateNoWindow = true
        };

        Output_text.AddFormattedText("<#83fa57>[PROCESSING] <>Please wait until the conversion is finished.");

        Proc.EnableRaisingEvents = true;
        Proc.ErrorDataReceived += ConsoleOutputHandler.ConvertOutput;
        Proc.Start();
        Proc.BeginErrorReadLine();
        await Proc.WaitForExitAsync();
    }
}