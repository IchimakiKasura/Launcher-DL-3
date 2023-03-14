namespace LauncherDL.Core.TaskProcess;

abstract class StartProcess
{
    public static async Task ProcessTask(string Args, DataReceivedEventHandler e)
    {;
        // UI freezes when starting up like wth
        await Task.Run(async()=>{
            ProcessTaskVariable = new();

            ProcessTaskVariable.StartInfo = new(YDL_Path, Args)
            {
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                CreateNoWindow = false
            };

            ProcessTaskVariable.OutputDataReceived += e;
            ProcessTaskVariable.ErrorDataReceived += ConsoleLive.ErrorOutputComment;
            ProcessTaskVariable.Start();
            ProcessTaskVariable.BeginOutputReadLine();
            ProcessTaskVariable.BeginErrorReadLine();

            await ProcessTaskVariable.WaitForExitAsync();
        });
    }
}