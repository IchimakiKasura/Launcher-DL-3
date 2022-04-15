namespace Launcher_DL.Lib.TaskProcess;

sealed class TaskProcessComp : Global
{
    public static async Task ProcessStart(YTDL_object YT, DataReceivedEventHandler output)
    {

        Proc = new();

        Proc.StartInfo = new(YDL_link, YT.Arguments)
        {
            UseShellExecute = false,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            CreateNoWindow = true
        };
        Proc.EnableRaisingEvents = true;
        Proc.OutputDataReceived += output;
        Proc.ErrorDataReceived += ConsoleOutputHandler.ErrorOutput;
        Proc.Start();
        Proc.BeginOutputReadLine();
        Proc.BeginErrorReadLine();
        await Proc.WaitForExitAsync();
    }

    public static async Task UpdateTask(YTDL_object YT)
    {
        await ProcessStart(YT, ConsoleOutputHandler.UpdateOutput);
    }

    public static async Task DownloadTask(YTDL_object YT)
    {
        await ProcessStart(YT, ConsoleOutputHandler.DownloadOutput);
    }

    public static async Task FileFormatTask(YTDL_object YT)
    {
        await ProcessStart(YT, ConsoleOutputHandler.FileFormatOutput);
    }
}