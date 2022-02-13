namespace Launcher_DL_v6;

public class OutputComments : MainWindow
{
	public static void DownloadOutputComments()
	{
		string Name = string.Empty;
		if (MW.Input_Name.Text == "Unavailable") Name = "N/A";

		MW.Output_text.Break("gray");
		MW.Output_text.AddFormattedText($"<gray>[] Download Type: {MW.Input_Type.Text}");
		MW.Output_text.AddFormattedText($"<gray>[] Name:			 {Name}");
		MW.Output_text.AddFormattedText($"<gray>[] Format:		 {MW.Input_Format.Text}");
		MW.Output_text.AddFormattedText($"<gray>[] Link:			 {MW.Input_Link.Text}");
		MW.Output_text.AddFormattedText($"<gray>[] Force MP3:		 {MW.Input_MpThreeFormat.IsChecked}");
		MW.Output_text.Break("gray");
		MW.Output_text.AddFormattedText("<Yellow>[INFO] <>Downloading...");
	}

	public static void UpdateOutputComments()
	{
		MW.Output_text.AddFormattedText("<Yellow>[INFO] <>Updating...");
	}

	public static void FileFormatOutputComments()
	{
		MW.Output_text.AddFormattedText("<Yellow>[INFO] <>Loading File Formats...");
	}

	public static void DownloadOutputCommentsLive()
	{

	}

}

