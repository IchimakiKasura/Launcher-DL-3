namespace Launcher_DL.Lib.TaskProcess;

sealed class LinkValidate : Global
{
	public bool IsValid { get; set; }
	public bool HasPlaylist { get; set; }
	public bool IsFetched { get; set; } = false;
	bool IsError = false;
	bool TempHasPlaylist;
	static string IsSameUrl;

	public async Task<LinkValidate> Validate(string url)
	{
		if (!string.IsNullOrEmpty(url))
		{
			if (IsSameUrl == url) return new()
			{
				IsValid = !IsError,
				HasPlaylist = TempHasPlaylist,
				IsFetched = true
			};

			IsSameUrl = url;
		}

		try
		{
			Uri Link = new(url);
			var UrlHost = RegexComp.URLname.Match(Link.Host).Groups["host"].Value;
			var UrlPath = Link.PathAndQuery;
			await GetFileName(Input_Link.Text);

			return new()
			{
				IsValid = !IsError,
				HasPlaylist = TempHasPlaylist
			};
		}
		catch //(Exception e)
		{
			// Console.WriteLine($"\x1b[31m{e}\x1b[0m");
			return new()
			{
				IsValid = false,
				HasPlaylist = false
			};
		}
	}
	private async Task GetFileName(string url)
	{
		Process Proc = new();
		Proc.StartInfo = new(YDL_link, new YTDL().YTDL_Validate())
		{
			UseShellExecute = false,
			RedirectStandardOutput = true,
			RedirectStandardError = true,
			StandardOutputEncoding = Encoding.UTF8,
			StandardErrorEncoding = Encoding.UTF8,
			CreateNoWindow = true
		};
		Proc.EnableRaisingEvents = true;

		Proc.OutputDataReceived += delegate (object s, DataReceivedEventArgs e)
		{
			if (!string.IsNullOrEmpty(e.Data))
				if(!Output_text.Dispatcher.CheckAccess())
					Output_text.Dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(()=>{
						CurrentLinkTitle = e.Data;
						Output_text.AddFormattedText($"<Green>[SUCCESS] <>{e.Data}");
					}));
		};

		Proc.ErrorDataReceived += delegate (object s, DataReceivedEventArgs e)
		{
			if (!string.IsNullOrEmpty(e.Data))
				if(!Output_text.Dispatcher.CheckAccess())
					Output_text.Dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(()=>
					{
						if (e.Data.Contains("ERROR") || e.Data.Contains("Traceback"))
						{
							TempHasPlaylist = false;
							if (e.Data.Contains("--no-playlist"))
								TempHasPlaylist = true;

							if (e.Data.Contains("cookies"))
								Output_text.AddFormattedText($"<Yellow>[INFO] <>If the link from facebook or other social media that is not public or needed an account, Please set the \"AllowCookies\" on the \"Config\"");

							IsError = true;
							DebugOutput.ERROR_Debug(e.Data);
						}
					}));
		};

		Proc.Start();
		Proc.BeginOutputReadLine();
		Proc.BeginErrorReadLine();
		await Proc.WaitForExitAsync();
	}

}