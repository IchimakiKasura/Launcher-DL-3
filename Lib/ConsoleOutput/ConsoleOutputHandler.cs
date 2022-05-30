namespace Launcher_DL.Lib.ConsoleOutput;

sealed class ConsoleOutputHandler : Global
{
	static int TotalDuration;
	public static void FileFormatOutput(object s, DataReceivedEventArgs e)
	{
		string StringData = e.Data;
		if (string.IsNullOrEmpty(e.Data)) return;

		if (StringData.Contains("https | unknown")) return;

		if(!Output_text.Dispatcher.CheckAccess())
			Output_text.Dispatcher.Invoke(DispatcherPriority.Background, new Action(()=>
			{

				TaskBarThingy.Description = $"Lancher DL - Progress {Window_ProgressBar.Value}%";
				TaskBarThingy.ProgressValue = Window_ProgressBar.Value / 100;

				// ProgressBar lmao
				if (StringData.Contains("["))
				{
					Window_ProgressBar.Value += 25;

					if (Window_ProgressBar.Value >= 90)
						Window_ProgressBar.Value = 75;

					if (StringData.Contains("[info] Available formats"))
						Window_ProgressBar.Value += 100;
				}

				// Auto cancels if the given link is a playlist
				// if the EnablePlaylist is set to false
				if (StringData.Contains("Downloading playlist"))
				{
					Output_text.AddFormattedText($"<Yellow>[INFO] <>Playlist is not supported on FileFormat");
					Output_text.AddFormattedText($"<Yellow>[INFO] <>You can only download them.");
					Output_text.AddFormattedText($"<Yellow>[INFO] <>Please Disable the playlist on the \"Config.kasu\" If you keep seeing this.");
					Proc.Close();
					WorkProcess.ProcessEnds(false);
				}

			}));

		WorkProcess.FileFormatProcess(StringData);
	}

	public static void DownloadOutput(object s, DataReceivedEventArgs e)
	{
		string StringData = e.Data;

		if (string.IsNullOrEmpty(StringData)) return;

		if(!Output_text.Dispatcher.CheckAccess())
			Output_text.Dispatcher.Invoke(DispatcherPriority.Background, new Action(()=>
			{

				TaskBarThingy.Description = $"Lancher DL - Progress {Window_ProgressBar.Value}%";
				TaskBarThingy.ProgressValue = Window_ProgressBar.Value / 100;

				if (StringData.Contains("[download]"))
					OutputComments.DownloadOutputCommentsLive(DocumentTemp, StringData);

				if (StringData.Contains("has already been downloaded"))
				{
					Proc.Close();
					WorkProcess.ProcessEnds(true);
					Output_text.AddFormattedText($"<Yellow>[INFO] <>File is Already been downloaded");
				}

				//FFmpeg converting
				if (StringData.Contains("[ExtractAudio]") || StringData.Contains("[VideoConvertor]"))
				{
					Output_text.LoadText(DocumentTemp);
					Output_text.AddFormattedText("<#83fa57>[PROCESSING] <>Processing / Converting フォマっと...");
				}
			}));
	}

	public static void UpdateOutput(object s, DataReceivedEventArgs e)
	{
		string StringData = e.Data;

		if (string.IsNullOrEmpty(StringData)) return;

		MainWindowStatic.Dispatcher.Invoke(DispatcherPriority.Normal, (Action)delegate
		{
			if (StringData.Contains("yt-dlp is up to date"))
				Output_text.AddFormattedText($"<Pink>[YEY?] <>File is up to date!");

			if (!StringData.Contains("yt-dlp to version"))
			{
				if (Config.ShowSystemOutput) Output_text.AddFormattedText($"<#a85192%14>[SYSTEM] <Gray%14>{StringData}");
			}
			else Output_text.AddFormattedText($"<Pink>[YEY] Updated!");

		});

	}

	public static void ConvertOutput(object s, DataReceivedEventArgs e)
	{
		string StringData = e.Data;

		if (string.IsNullOrEmpty(StringData)) return;

		MainWindowStatic.Dispatcher.Invoke(DispatcherPriority.Normal, (Action)delegate
		{
			TaskBarThingy.Description = $"Lancher DL - Progress {Window_ProgressBar.Value}%";
			TaskBarThingy.ProgressValue = Window_ProgressBar.Value / 100;

			string TotalTime = RegexComp.C_Total.Match(StringData).Groups["TotalTime"].Value.Trim();
			string CurrentTime = RegexComp.C_Current.Match(StringData).Groups["CurrentTime"].Value.Trim();
			int CurrentTimeInt;

			if (!string.IsNullOrEmpty(TotalTime))
				TotalDuration = (int)TimeSpan.Parse(TotalTime).TotalSeconds;

			if (!string.IsNullOrEmpty(CurrentTime))
			{
				CurrentTimeInt = (int)TimeSpan.Parse(CurrentTime).TotalSeconds;
				Window_ProgressBar.Value = (double)((decimal)CurrentTimeInt / (decimal)TotalDuration) * 100;
			}

		});
	}

	public static void ErrorOutput(object s, DataReceivedEventArgs e)
	{
		string StringData = e.Data;

		if (string.IsNullOrEmpty(StringData)) return;

		MainWindowStatic.Dispatcher.Invoke(DispatcherPriority.Normal, (Action)delegate
		{
			if (StringData.Contains("ERROR") || StringData.Contains("Traceback"))
			{
				DebugOutput.ERROR_Debug(StringData);
				Output_text.AddFormattedText($"<Red>[ERROR] <>The link given is not Supported or Unavailable");
				Proc.Close();
				WorkProcess.ProcessEnds(false);
			}
		});

	}

}