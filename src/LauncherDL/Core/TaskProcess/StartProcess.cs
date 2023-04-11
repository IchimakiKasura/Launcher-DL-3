namespace LauncherDL.Core.TaskProcess;

sealed class StartProcess
{
    public static async Task ProcessTask(string Args, DataReceivedEventHandler e)
    {
        IsInProcess = true;

        ProcessTaskVariable = new();

        bool isConvert = ConsoleLive.SelectedError is 3;

        ProcessTaskVariable.StartInfo =
            new(isConvert ? FFMPEG_Path : YDL_Path, Args)
            {
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                StandardOutputEncoding = Encoding.UTF8,
                StandardErrorEncoding = Encoding.UTF8,
                CreateNoWindow = true
            };

        ProcessTaskVariable.ErrorDataReceived += e;

        if(!isConvert)
        {
            ProcessTaskVariable.ErrorDataReceived -= e;
            ProcessTaskVariable.ErrorDataReceived += ConsoleLive.ErrorOutputComment;
            ProcessTaskVariable.OutputDataReceived += e;

            #if DEBUG
                ProcessTaskVariable.ErrorDataReceived += (s,e) => Console.WriteLine($"ERROR: {e.Data}");
                ProcessTaskVariable.OutputDataReceived += (s,e) => Console.WriteLine($"NORMAL: {e.Data}");
            #endif
        }

        // UI freezes when starting up like wth
        await ProcessTaskVariable.StartAsync();
        
        ProcessTaskVariable.BeginOutputReadLine();
        ProcessTaskVariable.BeginErrorReadLine();

        await ProcessTaskVariable.WaitForExitAsync();
    }
}