namespace Launcher_DL.Lib.TaskProcess;

sealed class WorkProcess : Global
{
	/// <summary>
	/// "StartProcess" <br/>
	/// It setups the OutputTexts Document <br/>
	/// and checks what process to start based on the passed parameter.
	/// </summary>
	/// <param name="YT">YT Object</param>
	/// <returns></returns>
	public static async Task StartProcess(YTDL_object YT)
	{
		DocumentTemp = Output_text.SaveText();

		if (YT.IsUpdate) await TaskProcessComp.UpdateTask(YT);

		if (YT.IsFileFormat)
		{
			if (!IsAppUsed) IsAppUsed = true;
			await TaskProcessComp.FileFormatTask(YT);
			if (TemporaryFormatList.Count > 1)
			{
				Output_text.AddFormattedText($"<Pink>[YEY] Total formats: {TemporaryFormatList.Count}");
			}
			else
			{
				Output_text.AddFormattedText($"<Red>[ERROR] <>Fetching format failed:\r" +
				"<Gray>1. Link is not supported?\r" +
				"<Gray%10>[ If link is not supported try downloading it using \"Video\" type\r or setting the Format option to \"best\" ]\r" +
				"<Gray>2. Slow internet might caused the problem.");
			}
		}

		if (!YT.IsDownload)
		{
			ProcessEnds(false);
			return;
		}

		if (!IsAppUsed) IsAppUsed = true;

		await TaskProcessComp.DownloadTask(YT);

		ProcessEnds(true);
		Output_text.AddFormattedText("<Pink>[YEY] Download Completed!");
	}

	/// <summary>
	/// 
	/// </summary>
	/// <param name="IsDownload"></param>
	public static void ProcessEnds(bool IsDownload)
	{
		IsDownloading = false;
		WindowsComp.Window_Components(false);
		ProgressBarAnim.ProgressBarHide();
		OpenFolderCheck.OpenFolderChecks();
		Window_ProgressBar.Value = 0;
		TaskBarThingy.Description = MainWindowStatic.Title;

		if (IsDownload) Output_text.LoadText(DocumentTemp);

		// Renaming process
		if (TemporaryEncodedName != string.Empty)
		{
			string DefaultName = Encoding.UTF8.GetString(Convert.FromBase64String(TemporaryEncodedName));
			switch (Input_Type.SelectedIndex)
			{
				case 0:
					foreach (string exts in ext)
					{
						foreach (string folder in ext)
						{
							try { File.Move($"{Config.DefaultOutput}\\formatted\\{folder}\\{TemporaryEncodedName}.{exts}", $"{Config.DefaultOutput}\\formatted\\{folder}\\{DefaultName}.{exts}"); } catch { }
						}
					}
					break;
				case 1:
					foreach (string s in ext)
					{
						try { File.Move($"{Config.DefaultOutput}\\Video\\{TemporaryEncodedName}.{s}", $"{Config.DefaultOutput}\\Video\\{DefaultName}.{s}"); } catch { }
					}
					break;
				case 2:
					foreach (string s in ext)
					{
						try { File.Move($"output\\Audio\\{TemporaryEncodedName}.{s}", $"output\\Audio\\{DefaultName}.{s}"); } catch { }
					}
					break;
			}
			TemporaryEncodedName = string.Empty;
		}

		if (Directory.Exists($"{Directory.GetCurrentDirectory()}\\{Config.DefaultOutput}")) Open_Folder.Visibility = Visibility.Visible;
		if (Config.DefaultOutput != "output" && Directory.Exists(Config.DefaultOutput)) Open_Folder.Visibility = Visibility.Visible;

		if (MainWindowStatic.IsActive)
		{
			TaskBarThingy.ProgressValue = 0;
			WindowsComp.WindowFlash();
		}


		//#if DEBUG
		//foreach (var item in TemporaryFormatList)
		//{
		//    Console.WriteLine(item);
		//}
		//#endif

	}

	public static void FileFormatProcess(string StringData)
	{
		string id = RegexComp.Info.Match(StringData).Groups["id"].Value.Trim(),
		resolution = RegexComp.Info.Match(StringData).Groups["fullResolution"].Value.Trim(),
		size = RegexComp.Info.Match(StringData).Groups["size"].Value.Trim(),
		bitrate = RegexComp.Info.Match(StringData).Groups["Videobitrate"].Value.Trim(),
		fps = RegexComp.Info.Match(StringData).Groups["fps"].Value.Trim(),
		format = RegexComp.Info.Match(StringData).Groups["format"].Value.Trim(),
		vcodec = RegexComp.Info.Match(StringData).Groups["Vcodec"].Value.Trim(),
		AudioOnly = string.Empty;

		if (resolution == string.Empty)
		{
			resolution = RegexComp.Info.Match(StringData).Groups["audioOnly"].Value.Trim();
			if (format == "m4a") AudioOnly = id;
		}

		if (size.Contains("~")) size.Replace("~ ", "~");

		if (Regex.IsMatch(resolution, @".*x.*", RegexOptions.Compiled))
		{
			resolution = Regex.Replace(resolution, @".*x", "", RegexOptions.Compiled) + "p";
			switch (format)
			{
				case "mp4":
					if (!string.IsNullOrEmpty(AudioOnly)) id += $"+{AudioOnly}";
					break;
				case "webm":
					id += "+bestaudio";
					break;
			}
		}

		// voids a codec that are unsupported by few players.
		if (string.IsNullOrEmpty(vcodec)) return;

		if (StringData != string.Empty && !StringData.Contains("["))
		{
			if (fps != string.Empty) fps += " fps";

			dynamic obj = new
			{
				data = StringData,
				id = id,
				resolution = resolution,
				size = size,
				bitrate = bitrate,
				fps = fps,
				format = format
			};

			if (StringData != string.Empty)
			{
				temp = StringData;
				if (resolution != string.Empty) FormatAdder(obj);
				return;
			}

			if (temp != StringData)
			{
				temp = StringData;
				if (resolution != string.Empty) FormatAdder(obj);
				return;
			}

			temp = string.Empty;
		}
	}

	public static void FormatAdder(dynamic options)
	{
		string format = options.format;

		// ye I kinda hate when its not aligned.
		// EDIT: on ver6 its still not align ffs.
		if (options.format == "mp4") format = "mp4    ";
		if (options.format == "m4a") format = "m4a    ";
		if (options.format == "3gp") format = "3gp     ";

		TemporaryFormatNames.Add(options.data);
		TemporaryFormatList.Add(options.id);

		dynamic Items = new
		{
			Name = $"[{options.format}] {options.resolution}; {options.size}",
			Id = $"[{Regex.Replace(options.id, "\\+.*", "")}]",
			Format = format,
			Resolution = options.resolution,
			Size = options.size,
			Bitrate = options.bitrate,
			Fps = options.fps
		};

		if(!Output_text.Dispatcher.CheckAccess())
			Output_text.Dispatcher.Invoke(DispatcherPriority.Background, new Action(()=>{

				Input_Format.Items.Add(Items);
				Output_text.AddFormattedText($"<#a85192%14>[SYSTEM] <Gray%14>Added:{options.resolution};    {options.size}");

				DebugOutput.FormatAdderDebug(options);

			}));
	}

}