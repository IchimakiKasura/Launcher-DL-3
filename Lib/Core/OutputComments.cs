namespace Launcher_DL_v6;

public class OutputComments : MainWindow
{
	public static void DownloadOutputComments()
	{
		MW.Input_Name.Text = MW.Input_Name.Text.Trim();
		string Name = MW.Input_Name.Text;
		string FileFormatName;

		// Check the ComboBox if any changes made to the File Format Text
		FileFormatName = MW.Input_Format.Text;
		if(MW.Input_Type.SelectedIndex == 0)
		{
			MW.TemporarySelectedFileFormat = MW.Input_Format.Text;
			if (MW.Input_Format.SelectedIndex != -1)
				MW.TemporarySelectedFileFormat = MW.TemporaryFormatList[MW.Input_Format.SelectedIndex];
		}


		if (string.IsNullOrEmpty(MW.Input_Name.Text)) Name = "N/A";

		MW.Output_text.Break("gray");
		MW.Output_text.AddFormattedText($"<gray%12>[] Download Type:	 {MW.Input_Type.Text}");
		MW.Output_text.AddFormattedText($"<gray%12>[] Name:		 {Name}");
		MW.Output_text.AddFormattedText($"<gray%12>[] Format:		 {FileFormatName}");
		MW.Output_text.AddFormattedText($"<gray%12>[] Link:			 {MW.Input_Link.Text}");
		MW.Output_text.AddFormattedText($"<gray%12>[] Playlist?:		 {MW.Config.EnablePlaylist}");
		MW.Output_text.Break("gray");
		MW.Output_text.AddFormattedText("<Yellow>[INFO] <>Downloading...");

		DebugOutput.Button_Output("download", new{
			DT = MW.Input_Type.Text,
			Name = Name,
			Format = FileFormatName,
			Link = MW.Input_Link.Text,
			Playlist = MW.Config.EnablePlaylist
		});

	}

	public static void UpdateOutputComments()
	{
		MW.Output_text.AddFormattedText("<Yellow>[INFO] <>Updating...");
		DebugOutput.Button_Output("update");
	}

	public static void FileFormatOutputComments()
	{
		MW.Output_text.AddFormattedText("<Yellow>[INFO] <>Loading File Formats...");
		DebugOutput.Button_Output("format");
	}

	public static void DownloadOutputCommentsLive(MemoryStream DocumentTemp, string StringData)
	{

		MW.Output_text.LoadText(DocumentTemp);

		string progress = LauncherDL_Regex.progress.Match(StringData).Groups["percent"].ToString();
		string size = LauncherDL_Regex.progress.Match(StringData).Groups["size"].ToString();
		string speed = LauncherDL_Regex.progress.Match(StringData).Groups["speed"].ToString();
		string eta = LauncherDL_Regex.progress.Match(StringData).Groups["time"].ToString();
		string TotalPlaylistDownloaded = string.Empty;


		// Playlist
		if (StringData.Contains("[download] Downloading video"))
		{
			TotalPlaylistDownloaded = Regex.Match(StringData, @"[0-9].*of.*").Value;
		}

		string color = "White";

		#region Change Foreground based on the speed.
		if (speed.Contains("K"))
		{
			double speeds = double.Parse(Regex.Replace(speed, @"[a-zA-Z\/]", "").ToString());
			if (speeds < 199.99) color = "#381900";
			else color = "Red";
		}
		if (speed.Contains("M"))
		{
			double speeds = double.Parse(Regex.Replace(speed, @"[a-zA-Z\/]", "").ToString());
			if (speeds < 0.99) color = "#fff154";
			else color = "#83fa57";
		}
		if (speed.Contains("G")) color = "Pink";
		#endregion

		if (TotalPlaylistDownloaded != string.Empty) MW.Output_text.AddFormattedText($"<Cyan>[ Playlist  ] <>{TotalPlaylistDownloaded}");

		MW.Output_text.AddFormattedText($"<Cyan>[ PROGRESS		] <>{progress.Trim()}%");
		MW.Output_text.AddFormattedText($"<Cyan>[ SIZE			] <>{size}");
		MW.Output_text.AddFormattedText($"<Cyan>[ SPEED			] <{color}>{speed}");
		MW.Output_text.AddFormattedText($"<Cyan>[ TIME LEFT		] <>{eta}");

		if (progress != string.Empty)
			MW.Window_ProgressBar.Value = int.Parse(Regex.Replace(progress.Trim(), @"\..*", "", RegexOptions.Compiled).ToString());

	}

}

