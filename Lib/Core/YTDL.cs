namespace Launcher_DL_v6;

public class YTDL_object
{
	public string Link { get; set; }
	public string Arguments { get; set; }
	public bool IsUpdate { get; set; } = false;
	public bool IsDownload { get; set; } = false;
	public bool IsFileFormat { get; set; } = false;

}


public partial class MainWindow
{
	public string YTDL_Validate()
	{
		return $"--get-filename -o '%(title)s' {Input_Link.Text}";
	}
	
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
		string Args = $"--compat-options format-sort -F {Input_Link.Text}";

		if(!Config.EnablePlaylist) Args += " --no-playlist";

		return new()
		{
			Arguments = Args,
			IsFileFormat = true
		};

	}

	public YTDL_object YTDL_Download()
	{
		string arguments = string.Empty;
		string name = string.Empty;

		if(Input_Name.Text != string.Empty && !string.IsNullOrEmpty(Input_Name.Text))
		{
			TemporaryEncodedName = name = Convert.ToBase64String(Encoding.UTF8.GetBytes(Input_Name.Text));
		}

		switch(Input_Type.SelectedIndex)
		{
			// Custom
			case 0:

				arguments = $"-f \"{TemporarySelectedFileFormat}\" {Input_Link.Text} -o {Config.DefaultOutput}/formatted/%(ext)s/%(title)s.%(ext)s --ffmpeg-location \"{Ffmpeg}\" --no-part";
				if (Input_Name.Text != string.Empty && !string.IsNullOrEmpty(Input_Name.Text))
					arguments = $"-f \"{TemporarySelectedFileFormat}\" {Input_Link.Text} -o {Config.DefaultOutput}/formatted/%(ext)s/{name}.%(ext)s --ffmpeg-location \"{Ffmpeg}\" --no-part";

				if (TemporarySelectedFileFormat.Contains("Best"))
				{
					arguments = $"-f b {Input_Link.Text} -o {Config.DefaultOutput}/formatted/%(ext)s/%(title)s.%(ext)s --ffmpeg-location \"{Ffmpeg}\" --no-part";
					if (Input_Name.Text != string.Empty && !string.IsNullOrEmpty(Input_Name.Text))
						arguments = $"-f b {Input_Link.Text} -o {Config.DefaultOutput}/formatted/%(ext)s/{name}.%(ext)s --ffmpeg-location \"{Ffmpeg}\" --no-part";
				}
				
				if (string.IsNullOrEmpty(Input_Format.Text))
				{
					arguments = $"{Input_Link.Text} -o {Config.DefaultOutput}/formatted/%(ext)s/%(title)s.%(ext)s --no-part";
						if (Input_Name.Text != string.Empty && !string.IsNullOrEmpty(Input_Name.Text))
							arguments = $"{Input_Link.Text} -o {Config.DefaultOutput}/formatted/%(ext)s/{name}.%(ext)s --no-part";
				}

			break;

			// Video
			case 1:

				arguments = $"-f b {Input_Link.Text} -o {Config.DefaultOutput}/Video/%(title)s.%(ext)s --no-part";
				if(Input_Name.Text != string.Empty && !string.IsNullOrEmpty(Input_Name.Text))
					arguments = $"-f b {Input_Link.Text} -o {Config.DefaultOutput}/Video/{name}.%(ext)s --no-part";

			break;

			// Audio
			case 2:

				arguments = $"-f bestaudio {Input_Link.Text} -o {Config.DefaultOutput}/Audio/%(title)s.%(ext)s";
				if (Input_Name.Text != string.Empty && !string.IsNullOrEmpty(Input_Name.Text))
					arguments = $"-f bestaudio {Input_Link.Text} -o {Config.DefaultOutput}/Audio/{name}.%(ext)s";

				if (Input_MpThreeFormat.IsChecked.Value)
				{
					arguments = $"-x --audio-format mp3 {Input_Link.Text} -o {Config.DefaultOutput}/Audio/%(title)s.%(ext)s --ffmpeg-location \"{Ffmpeg}\" --no-part";
					if (Input_Name.Text != string.Empty && !string.IsNullOrEmpty(Input_Name.Text))
						arguments = $"-x --audio-format mp3 {Input_Link.Text} -o {Config.DefaultOutput}/Audio/{name}.%(ext)s --ffmpeg-location \"{Ffmpeg}\" --no-part";
				}

			break;
		}

		if(!Config.EnablePlaylist) arguments += " --no-playlist";

		return new()
		{
			Arguments = arguments,
			IsDownload = true
		};
	}
}