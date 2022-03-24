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

		if(Input_Type.SelectedIndex == 0)
		{
			arguments = $"-f \"{TemporarySelectedFileFormat}\" {Input_Link.Text}";
			if(TemporarySelectedFileFormat.Contains("Best"))
				arguments = $"-f b {Input_Link.Text}";
		}

		if (Input_Type.SelectedIndex == 1)
		{
			arguments = $"-f b {Input_Link.Text}";
		}

		return new()
		{
			uhh = arguments,
			IsDownload = true
		};
	}
}