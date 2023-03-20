namespace LauncherDL.Core.TaskProcess;

abstract class StartProcess
{
    public static async Task ProcessTask(string Args, DataReceivedEventHandler e)
    {;
        ProcessTaskVariable = new();

        bool isConvert = ConsoleLive.SelectedError is 2;

        ProcessTaskVariable.StartInfo =
            new(isConvert ? FFMPEG_Path : YDL_Path, Args)
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