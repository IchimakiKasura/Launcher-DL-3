namespace Launcher_DL_v6;

public partial class MainWindow
{
	Process Proc = new();
	private async Task ProcessStart(YTDL_object YT, DataReceivedEventHandler output)
	{
		Proc.StartInfo = new(YDL_link, YT.Arguments)
		{
			UseShellExecute = false,
			RedirectStandardOutput = true,
			CreateNoWindow = true
		};
		Proc.EnableRaisingEvents = true;
		Proc.OutputDataReceived += output;
		Proc.Start();
		Proc.BeginOutputReadLine();
		await Proc.WaitForExitAsync();
	}

	private async Task UpdateTask(YTDL_object YT)
	{
		await ProcessStart(YT, UpdateOutput);
	}

	private async Task DownloadTask(YTDL_object YT)
	{
		await ProcessStart(YT, DownloadOutput);
	}

	private  async Task FileFormatTask(YTDL_object YT)
	{
		await ProcessStart(YT, FileFormatOutput);
	}
}