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

		if(!string.IsNullOrEmpty(Input_Name.Text))
		{
			TemporaryEncodedName = name = Convert.ToBase64String(Encoding.UTF8.GetBytes(Input_Name.Text));
		}

		switch(Input_Type.SelectedIndex)
		{
			// Custom
			case 0:

				arguments = $"-f \"{TemporarySelectedFileFormat}\" {Input_Link.Text} -o {Config.DefaultOutput}/formatted/%(ext)s/%(title)s.%(ext)s";

				if (TemporarySelectedFileFormat.Contains("Best") || TemporarySelectedFileFormat.Contains("best"))
					arguments = $"-f b {Input_Link.Text} -o {Config.DefaultOutput}/formatted/%(ext)s/%(title)s.%(ext)s";
				
				if(string.IsNullOrEmpty(Input_Format.Text))
					arguments = $"{Input_Link.Text} -o {Config.DefaultOutput}/formatted/%(ext)s/%(title)s.%(ext)s";

				if (!string.IsNullOrEmpty(Input_Name.Text))
					arguments = arguments.Replace("%(title)s", name);

			break;

			// Video
			case 1:

				arguments = "--recode-video";
				switch(Input_Format.SelectedIndex)
				{
					case 0: arguments += " mp4"; break;
					case 1: arguments += " mkv"; break;
					case 2: arguments += " webm"; break;
					case 3: arguments += " flv"; break;
					case 4: arguments = "-f b"; break;
				};

				if (!string.IsNullOrEmpty(Input_Name.Text))
					arguments += $" {Input_Link.Text} -o {Config.DefaultOutput}/Video/{name}.%(ext)s";
				else arguments += $" {Input_Link.Text} -o {Config.DefaultOutput}/Video/%(title)s.%(ext)s";

			break;

			// Audio
			case 2:

				arguments = "-x --audio-format";
				switch(Input_Format.SelectedIndex)
				{
					case 0: arguments += $" mp3"; break;
					case 1: arguments += $" webm"; break;
					case 2: arguments += $" m4a"; break;
					case 3: arguments += $" mp4"; break;
					case 4: arguments = $"-f bestaudio"; break;
				};

				if (!string.IsNullOrEmpty(Input_Name.Text))
					arguments += $" {Input_Link.Text} -o {Config.DefaultOutput}/Audio/{name}.%(ext)s";
				else arguments += $" {Input_Link.Text} -o {Config.DefaultOutput}/Audio/%(title)s.%(ext)s";

			break;
		}

		if(!Config.EnablePlaylist) arguments += " --no-playlist";
		arguments += $" --ffmpeg-location \"{Ffmpeg}\" --no-part";
		
		return new()
		{
			Arguments = arguments,
			IsDownload = true
		};
	}
}