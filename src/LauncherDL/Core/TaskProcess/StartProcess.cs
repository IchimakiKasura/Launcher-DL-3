namespace LauncherDL.Core.TaskProcess;

abstract class StartProcess
{
    public static async Task ProcessTask(string Args, DataReceivedEventHandler e)
    {;
        ProcessTaskVariable = new();

        bool isConvert = ConsoleLive.SelectedError == 2;

        ProcessTaskVariable.StartInfo = new(isConvert ? FFMPEG_Path : YDL_Path, Args)
        {
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            CreateNoWindow = true
        };

        ProcessTaskVariable.ErrorDataReceived += e;

        if(!isConvert)
        {
            ProcessTaskVariable.ErrorDataReceived -= e;
            ProcessTaskVariable.ErrorDataReceived += ConsoleLive.ErrorOutputComment;
            ProcessTaskVariable.OutputDataReceived += e;
        }

        // UI freezes when starting up like wth
        await ProcessTaskVariable.StartAsync();
        
        ProcessTaskVariable.BeginOutputReadLine();
        ProcessTaskVariable.BeginErrorReadLine();

        await ProcessTaskVariable.WaitForExitAsync();
    }
}

public static class ExtendProcess
{
    public static async Task StartAsync(this Process _proc) =>
        await Task.Run(()=>_proc.Start());
}