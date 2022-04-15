namespace Launcher_DL.Lib.ConsoleOutput;

sealed class ConsoleOutputHandler : Global
{
    static string AudioOnly;
    static int TotalDuration;
    public static void FileFormatOutput(object s, DataReceivedEventArgs e)
    {
        string StringData = e.Data;
        if (!string.IsNullOrEmpty(e.Data))
            MainWindowStatic.Dispatcher.Invoke(DispatcherPriority.Normal, (Action)delegate
            {

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
                    WorkProcess.ProcessEnds(false);
                }


                string id = RegexComp.Info.Match(StringData).Groups["id"].Value.Trim(); ;
                string resolution = RegexComp.Info.Match(StringData).Groups["fullResolution"].Value.Trim();
                string size = RegexComp.Info.Match(StringData).Groups["size"].Value.Trim();
                string bitrate = RegexComp.Info.Match(StringData).Groups["Videobitrate"].Value.Trim();
                string fps = RegexComp.Info.Match(StringData).Groups["fps"].Value.Trim();
                string format = RegexComp.Info.Match(StringData).Groups["format"].Value.Trim();
                string vcodec = RegexComp.Info.Match(StringData).Groups["Vcodec"].Value.Trim();

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
                            if (!string.IsNullOrEmpty(AudioOnly))
                                id += $"+{AudioOnly}";
                            break;
                        case "webm":
                            id += "+bestaudio";
                            break;
                    }
                }

                // voids a codec that are unsupported by few players.
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
                                WorkProcess.FormatAdder(obj);
                            }
                        }
                        else
                        {
                            if (temp != StringData)
                            {
                                temp = StringData;
                                if (resolution != string.Empty)
                                {
                                    WorkProcess.FormatAdder(obj);
                                }
                            }
                            else temp = string.Empty;
                        }
                    }
            });
    }

    public static void DownloadOutput(object s, DataReceivedEventArgs e)
    {
        string StringData = e.Data;
        if (!string.IsNullOrEmpty(StringData))
            MainWindowStatic.Dispatcher.Invoke(DispatcherPriority.Normal, (Action)delegate
            {

                TaskBarThingy.ProgressValue = Window_ProgressBar.Value / 100;

                if (StringData.Contains("[download]"))
                {
                    OutputComments.DownloadOutputCommentsLive(DocumentTemp, StringData);
                }

                if (StringData.Contains("has already been downloaded"))
                {
                    Proc.Close();
                    WorkProcess.ProcessEnds(true);
                    Output_text.AddFormattedText($"<Yellow>[INFO] <>File is Already been downloaded");
                }

                //FFmpeg converting
                if (StringData.Contains("[ExtractAudio]") || StringData.Contains("[VideoConvertor]"))
                {
                    Output_text.LoadText(DocumentTemp);
                    Output_text.AddFormattedText("<#83fa57>[PROCESSING] <>Processing / Converting フォマっと...");
                }
            });
    }

    public static void UpdateOutput(object s, DataReceivedEventArgs e)
    {
        string StringData = e.Data;
        if (!string.IsNullOrEmpty(StringData))
            Output_text.Dispatcher.Invoke(DispatcherPriority.Normal, (Action)delegate
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

    public static void ConvertOutput(object s, DataReceivedEventArgs e)
    {
        // frame= 7290 fps=263 q=-1.0 Lsize=   22360kB time=00:04:03.05 bitrate= 753.6kbits/s speed=8.78x
        string StringData = e.Data;
        if (!string.IsNullOrEmpty(StringData))
            MainWindowStatic.Dispatcher.Invoke(DispatcherPriority.Normal, (Action)delegate
            {
                TaskBarThingy.ProgressValue = Window_ProgressBar.Value / 100;

                string TotalTime = RegexComp.C_Total.Match(StringData).Groups["TotalTime"].Value.Trim();
                string CurrentTime = RegexComp.C_Current.Match(StringData).Groups["CurrentTime"].Value.Trim();
                int CurrentTimeInt;

                if (!string.IsNullOrEmpty(TotalTime))
                    TotalDuration = (int)TimeSpan.Parse(TotalTime).TotalSeconds;

                if (!string.IsNullOrEmpty(CurrentTime))
                {
                    CurrentTimeInt = (int)TimeSpan.Parse(CurrentTime).TotalSeconds;
                    Window_ProgressBar.Value = (double)((decimal)CurrentTimeInt / (decimal)TotalDuration) * 100;
                }

            });
    }

    public static void ErrorOutput(object s, DataReceivedEventArgs e)
    {
        string StringData = e.Data;
        if (!string.IsNullOrEmpty(StringData))
            MainWindowStatic.Dispatcher.Invoke(DispatcherPriority.Normal, (Action)delegate
            {
                if (StringData.Contains("ERROR") || StringData.Contains("Traceback"))
                {
                    DebugOutput.ERROR_Debug(StringData);
                    Output_text.AddFormattedText($"<Red>[ERROR] <>The link given is not Supported or Unavailable");
                    Proc.Close();
                    WorkProcess.ProcessEnds(false);
                }
            });

    }

}