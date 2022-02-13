namespace Launcher_DL_v6;

public class YTDL_object
{
	public string Link { get; set; }
	public string Arguments { get; set; }
	public bool IsUpdate { get; set; }
	public bool IsDownload { get; set; }
}


public partial class MainWindow
{
	private string processStartString = string.Empty;

	public YTDL_object YTDL_Update()
	{
		return new YTDL_object()
		{
			Link = Input_Link.Text,
			Arguments = "-U",
			IsUpdate = true,
			IsDownload = false
		};
	}

	public void YTDL_FileFormat()
	{

	}

	public void YTDL_Download()
	{

	}
}