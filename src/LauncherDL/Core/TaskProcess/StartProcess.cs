namespace LauncherDL.Core.TaskProcess;

abstract class StartProcess
{
    public static async Task ProcessTask(string Args, DataReceivedEventHandler e)
    {;
        // UI freezes when starting up like wth
        await Task.Run(async()=>{
            ProcessTaskVariable = new();

            var StartInfo = new ProcessStartInfo();
            var FileName = YDL_Path;
            var isConvert = ConsoleLive.SelectedError == 2;

            if(isConvert)
                FileName = FFMPEG_Path;

            StartInfo.FileName = FileName;
            StartInfo.Arguments = Args;
            StartInfo.RedirectStandardOutput = true;
            StartInfo.RedirectStandardError = true;
            StartInfo.CreateNoWindow = false;

            ProcessTaskVariable.StartInfo = StartInfo;

            ProcessTaskVariable.ErrorDataReceived += e;
            if(!isConvert)
            {
                ProcessTaskVariable.ErrorDataReceived -= e;
                ProcessTaskVariable.ErrorDataReceived += ConsoleLive.ErrorOutputComment;
                ProcessTaskVariable.OutputDataReceived += e;
            }
            ProcessTaskVariable.Start();
            ProcessTaskVariable.BeginOutputReadLine();
            ProcessTaskVariable.BeginErrorReadLine();

            await ProcessTaskVariable.WaitForExitAsync();
        });
    }
}