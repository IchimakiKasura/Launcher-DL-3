namespace Launcher_DL_v6;

public partial class MainWindow
{
	private async Task ProcessStart(YTDL_object YT, DataReceivedEventHandler output)
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
		Proc.ErrorDataReceived += ErrorOutput;
		Proc.Start();
		Proc.BeginOutputReadLine();
		Proc.BeginErrorReadLine();
		await Proc.WaitForExitAsync();
	}

	private async Task UpdateTask(YTDL_object YT)
	{
		await ProcessStart(YT, UpdateOutput);
	}

	private async Task DownloadTask(YTDL_object YT)
	{
		YT.Arguments = YT.uhh;
		await ProcessStart(YT, DownloadOutput);
	}

	private  async Task FileFormatTask(YTDL_object YT)
	{
		YT.Arguments = YT.uhh;
		await ProcessStart(YT, FileFormatOutput);
	}
}