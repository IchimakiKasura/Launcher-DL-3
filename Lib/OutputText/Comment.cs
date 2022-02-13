namespace Launcher_DL_v6;

public partial class MainWindow
{
	public void FileFormatOutput(object s, DataReceivedEventArgs e)
	{
		if (!string.IsNullOrEmpty(e.Data))
		{
			Dispatcher.Invoke(DispatcherPriority.Normal, (Action)delegate
			{

			});
		}
	}

	public void DownloadOutput(object s, DataReceivedEventArgs e)
	{
		if (!string.IsNullOrEmpty(e.Data))
		{
			Dispatcher.Invoke(DispatcherPriority.Normal, (Action)delegate
			{

			});
		}
	}

	public void UpdateOutput(object s, DataReceivedEventArgs e)
	{
		if (!string.IsNullOrEmpty(e.Data))
		{
			Dispatcher.Invoke(DispatcherPriority.Normal, (Action)delegate
			{
				Output_text.AddFormattedText($"<Yellow>[INFO] <>${e.Data}");
			});
		}
	}
}