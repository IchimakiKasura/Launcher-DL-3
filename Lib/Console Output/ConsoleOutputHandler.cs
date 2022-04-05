namespace Launcher_DL_v6;

public partial class MainWindow
{
    string AudioOnly;
    public void FileFormatOutput(object s, DataReceivedEventArgs e)
    {
        string StringData = e.Data;
        if (!string.IsNullOrEmpty(e.Data))
        {
            Dispatcher.Invoke(DispatcherPriority.Normal, (Action)delegate
            {
                ProgressBarShow();

                TaskBarThingy.ProgressValue = Window_ProgressBar.Value / 100;

                if (StringData.Contains("https | unknown")) return;

                // ProgressBar lmao
                if (StringData.Contains("["))
                {
                    Window_ProgressBar.Value += 25;

                    if (StringData.Contains("[info] Available formats"))
                    {
                        Window_ProgressBar.Value += 100;
                    }
                    else
                    {
                        if (Window_ProgressBar.Value >= 90)
                        {
                            Window_ProgressBar.Value = 75;
                        }
                    }
                }

                // Auto cancels if the given link is a playlist
                if (StringData.Contains("Downloading playlist"))
                {
                    Output_text.AddFormattedText($"<Yellow>[INFO] <>Playlist is not supported on FileFormat");
                    Output_text.AddFormattedText($"<Yellow>[INFO] <>You can only download them.");
                    Output_text.AddFormattedText($"<Yellow>[INFO] <>Please Disable the playlist on the \"Config.kasu\" If you keep seeing this.");
                    Proc.Close();
                    ProcessEnds(false);
                }


                string id = LauncherDL_Regex.Info.Match(StringData).Groups["id"].Value.Trim(); ;
                string resolution = LauncherDL_Regex.Info.Match(StringData).Groups["fullResolution"].Value.Trim();
                string size = LauncherDL_Regex.Info.Match(StringData).Groups["size"].Value.Trim();
                string bitrate = LauncherDL_Regex.Info.Match(StringData).Groups["Videobitrate"].Value.Trim();
                string fps = LauncherDL_Regex.Info.Match(StringData).Groups["fps"].Value.Trim();
                string format = LauncherDL_Regex.Info.Match(StringData).Groups["format"].Value.Trim();
                string vcodec = LauncherDL_Regex.Info.Match(StringData).Groups["Vcodec"].Value.Trim();

                if (resolution == string.Empty)
                {
                    resolution = LauncherDL_Regex.Info.Match(StringData).Groups["audioOnly"].Value.Trim();
                    if (format == "m4a") AudioOnly = id;
                }

                if (size.Contains("~")) size.Replace("~ ", "~");

                
                if (Regex.IsMatch(resolution, @".*x.*", RegexOptions.Compiled))
                {
                    resolution = Regex.Replace(resolution, @".*x", "", RegexOptions.Compiled) + "p";
                    switch (format)
                    {
                        case "mp4":
                            if(!string.IsNullOrEmpty(AudioOnly))
                                id += $"+{AudioOnly}";
                            break;
                        case "webm":
                            id += "+bestaudio";
                            break;
                    }
                }

                // avoids a codec that are unsupported by few players.
                if (!string.IsNullOrEmpty(vcodec))
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

                        if (StringData == string.Empty)
                        {
                            temp = StringData;
                            if (resolution != string.Empty)
                            {
                                FormatAdder(obj);
                            }
                        }
                        else
                        {
                            if (temp != StringData)
                            {
                                temp = StringData;
                                if (resolution != string.Empty)
                                {
                                    FormatAdder(obj);
                                }
                            }
                            else temp = string.Empty;
                        }
                    }
            });
        }
    }

    public void DownloadOutput(object s, DataReceivedEventArgs e)
    {
        string StringData = e.Data;
        if (!string.IsNullOrEmpty(StringData))
        {
            Dispatcher.Invoke(DispatcherPriority.Normal, (Action)delegate
            {
                ProgressBarShow();

                TaskBarThingy.ProgressValue = Window_ProgressBar.Value / 100;

                if (StringData.Contains("[download]"))
                {
                    OutputComments.DownloadOutputCommentsLive(DocumentTemp, StringData);
                }

                if (StringData.Contains("has already been downloaded"))
                {
                    Proc.Close();
                    ProcessEnds(true);
                    Output_text.AddFormattedText($"<Yellow>[INFO] <>File is Already been downloaded");
                }

                //FFmpeg converting
                if (StringData.Contains("[ExtractAudio]"))
                {
                    Output_text.LoadText(DocumentTemp);
                    Output_text.AddFormattedText("<#83fa57>[FFMPEG] <>Processing フォマっと...");
                }

            });
        }
    }

    public void UpdateOutput(object s, DataReceivedEventArgs e)
    {
        string StringData = e.Data;
        if (!string.IsNullOrEmpty(StringData))
        {
            Dispatcher.Invoke(DispatcherPriority.Normal, (Action)delegate
            {
                if (StringData.Contains("yt-dlp is up to date"))
                {
                    Output_text.AddFormattedText($"<Pink>[YEY?] <>File is up to date!");
                    return;
                }

                if (!StringData.Contains("yt-dlp to version"))
                {
                    if (Config.ShowSystemOutput) Output_text.AddFormattedText($"<#a85192%14>[SYSTEM] <Gray%14>{StringData}");
                }
                else
                    Output_text.AddFormattedText($"<Pink>[YEY] Updated!");

            });
        }
    }

    public void ErrorOutput(object s, DataReceivedEventArgs e)
    {
        string StringData = e.Data;
        if (!string.IsNullOrEmpty(StringData))
        {
            Dispatcher.Invoke(DispatcherPriority.Normal, (Action)delegate
            {
                if (StringData.Contains("ERROR") || StringData.Contains("Traceback"))
                {
                    DebugOutput.ERROR_Debug(StringData);
                    Output_text.AddFormattedText($"<Red>[ERROR] <>The link given is not Supported or Unavailable");
                    Proc.Close();
                    ProcessEnds(false);
                }
            });
        }
    }

}