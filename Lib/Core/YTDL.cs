namespace Launcher_DL.Lib.Core;

/// <summary>YTDL objects</summary>
sealed class YTDL_object
{
	public string Link { get; set; }
	public string Arguments { get; set; }
	public bool IsUpdate { get; set; } = false;
	public bool IsDownload { get; set; } = false;
	public bool IsFileFormat { get; set; } = false;

}

/// <summary>Youtube DLP arguments generator?</summary>
sealed class YTDL : Global
{
	/// <summary>Validatation</summary>
	/// <returns><see langword="ytdlp validate argument"/> --get-filename</returns>
	public string YTDL_Validate()
	{
		string arg = $"--get-filename -o '%(title)s' {Input_Link.Text} --verbose --no-playlist --encoding utf8";
		if (Config.AllowCookies) arg += $" --cookies-from-browser {Config.BrowserCookie}";
		return arg;
	}

	/// <summary>Update</summary>
	/// <returns><see langword="ytdlp update argument"/> -U</returns>
	public YTDL_object YTDL_Update()
	{
		return new()
		{
			Link = Input_Link.Text,
			Arguments = "-U",
			IsUpdate = true
		};
	}

	/// <summary>FileFormat</summary>
	/// <returns><see langword="ytdlp update argument"/> -F</returns>
	public YTDL_object YTDL_FileFormat()
	{
		string Args = $"--compat-options format-sort -F {Input_Link.Text}";

		if (!Config.EnablePlaylist) Args += " --no-playlist";
		if (Config.AllowCookies) Args += $" --cookies-from-browser {Config.BrowserCookie}";

		return new()
		{
			Arguments = Args,
			IsFileFormat = true
		};

	}

	/// <summary>Download</summary>
	/// <returns><see langword="ytdl download argument"/> -f |--recode-video | -x</returns>
	public YTDL_object YTDL_Download()
	{
		string arguments = string.Empty;
		string name = string.Empty;

		if (!string.IsNullOrEmpty(Input_Name.Text))
			TemporaryEncodedName = name = Convert.ToBase64String(Encoding.UTF8.GetBytes(Input_Name.Text));

		if (Input_Link.Text.Contains("facebook") && string.IsNullOrEmpty(Input_Name.Text))
		{
			var TempName = $"Facebook [{Regex.Match(Input_Link.Text, @"\/(?<Name>[0-9]+)").Groups["Name"].Value}]";
			TemporaryEncodedName = name = Convert.ToBase64String(Encoding.UTF8.GetBytes(TempName));
		}

		switch (Input_Type.SelectedIndex)
		{
			// Custom
			case 0:

				arguments = $"-f \"{TemporarySelectedFileFormat}\" {Input_Link.Text} -o {Config.DefaultOutput}";

				if (TemporarySelectedFileFormat.Contains("Best") || TemporarySelectedFileFormat.Contains("best"))
					arguments = $"-f b {Input_Link.Text} -o {Config.DefaultOutput}";

				if (string.IsNullOrEmpty(Input_Format.Text))
					arguments = $"{Input_Link.Text} -o {Config.DefaultOutput}";

				if (Input_Format.Text.Contains("-"))
					arguments = $"{Input_Format.Text} {Input_Link.Text} -o {Config.DefaultOutput}";

				arguments += "/formatted/%(ext)s/%(title)s.%(ext)s";

				break;

			// Video
			case 1:

				arguments = "--recode-video";
				switch (Input_Format.SelectedIndex)
				{
					case 0: arguments += " mp4"; break;
					case 1: arguments += " mkv"; break;
					case 2: arguments += " webm"; break;
					case 3: arguments += " flv"; break;
					case 4: arguments = "-f b"; break;
				};

				arguments += $" {Input_Link.Text} -o {Config.DefaultOutput}/Video/%(title)s.%(ext)s";
				break;

			// Audio
			case 2:

				arguments = "-x --audio-format";
				switch (Input_Format.SelectedIndex)
				{
					case 0: arguments += $" mp3"; break;
					case 1: arguments += $" webm"; break;
					case 2: arguments += $" m4a"; break;
					case 3: arguments += $" mp4"; break;
					case 4: arguments = $"-x -f b"; break;
				};

				arguments += $" {Input_Link.Text} -o {Config.DefaultOutput}/Audio/%(title)s.%(ext)s";
				break;
		}

		if (!Config.EnablePlaylist) arguments += " --no-playlist";
		if (Config.AllowCookies) arguments += $" --cookies-from-browser {Config.BrowserCookie}";
		arguments += $" --ffmpeg-location \"{Ffmpeg}\" --no-part";

		if (!string.IsNullOrEmpty(name))
			arguments = arguments.Replace("%(title)s", name);

		return new()
		{
			Arguments = arguments,
			IsDownload = true
		};
	}
}