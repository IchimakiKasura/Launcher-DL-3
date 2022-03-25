namespace Launcher_DL_v6;

public class YTDL_object
{
	public string uhh { get; set; } // dont
	public string Link { get; set; }
	public string Arguments { get; set; }
	public bool IsUpdate { get; set; } = false;
	public bool IsDownload { get; set; } = false;
	public bool IsFileFormat { get; set; } = false;

}


public partial class MainWindow
{
	public YTDL_object YTDL_Update()
	{
		return new ()
		{
			Link = Input_Link.Text,
			Arguments = "-U",
			IsUpdate = true
		};
	}

	public YTDL_object YTDL_FileFormat()
	{
		return new()
		{
			uhh = $"-F {Input_Link.Text}",
			IsFileFormat = true
		};

	}

	public YTDL_object YTDL_Download()
	{
		string arguments = string.Empty;
		string name = string.Empty;

		if(Input_Name.Text != string.Empty && Input_Name.Text != "Unavailable")
		{
			TemporaryEncodedName = name = Convert.ToBase64String(Encoding.UTF8.GetBytes(Input_Name.Text));
		}

		// Custom
		if(Input_Type.SelectedIndex == 0)
		{
			arguments = $"-f \"{TemporarySelectedFileFormat}\" {Input_Link.Text} -o {Config.DefaultOutput}/formatted/%(ext)s/%(title)s.%(ext)s --ffmpeg-location \"{Ffmpeg}\" --no-part";
			if (Input_Name.Text != string.Empty && Input_Name.Text != "Unavailable")
				arguments = $"-f \"{TemporarySelectedFileFormat}\" {Input_Link.Text} -o {Config.DefaultOutput}/formatted/%(ext)s/{name}.%(ext)s --ffmpeg-location \"{Ffmpeg}\" --no-part";

			if (TemporarySelectedFileFormat.Contains("Best"))
			{
				arguments = $"-f b {Input_Link.Text} -o {Config.DefaultOutput}/formatted/%(ext)s/%(title)s.%(ext)s --ffmpeg-location \"{Ffmpeg}\" --no-part";
				if (Input_Name.Text != string.Empty && Input_Name.Text != "Unavailable")
					arguments = $"-f b {Input_Link.Text} -o {Config.DefaultOutput}/formatted/%(ext)s/{name}.%(ext)s --ffmpeg-location \"{Ffmpeg}\" --no-part";
			}

		}

		// Video
		if (Input_Type.SelectedIndex == 1)
		{
			arguments = $"-f b {Input_Link.Text} -o {Config.DefaultOutput}/Video/%(title)s.%(ext)s --no-part";
			if(Input_Name.Text != string.Empty && Input_Name.Text != "Unavailable")
				arguments = $"-f b {Input_Link.Text} -o {Config.DefaultOutput}/Video/{name}.%(ext)s --no-part";
		}


		// Audio
		if (Input_Type.SelectedIndex == 2)
		{
			arguments = $"-f bestaudio {Input_Link.Text}/Audio/%(title)s.%(ext)s";
			if (Input_Name.Text != string.Empty && Input_Name.Text != "Unavailable")
				arguments = $"-f bestaudio {Input_Link.Text}/Audio/{name}.%(ext)s";

			if (Input_MpThreeFormat.IsChecked.Value)
			{
				arguments = $"-x --audio-format mp3 {Input_Link.Text}/Audio/%(title)s.%(ext)s --ffmpeg-location \"{Ffmpeg}\" --no-part";
				if (Input_Name.Text != string.Empty && Input_Name.Text != "Unavailable")
					arguments = $"-x --audio-format mp3 {Input_Link.Text}/Audio/{name}.%(ext)s --ffmpeg-location \"{Ffmpeg}\" --no-part";
			}
		}

		return new()
		{
			uhh = arguments,
			IsDownload = true
		};
	}
}