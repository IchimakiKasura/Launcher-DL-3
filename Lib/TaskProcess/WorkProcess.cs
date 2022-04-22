﻿namespace Launcher_DL.Lib.TaskProcess;

sealed class WorkProcess : Global
{
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
                Output_text.AddFormattedText($"<Red>[ERROR] <>Fetching format failed:\n" +
                "<Gray>1. Link is not supported?\n" +
                "<Gray%13>If link is not supported try downloading it using \"Video\" type\n or setting the Format option to \"best\"\n" +
                "<Gray>2. Slow internet might caused the problem.");
            }
        }

        if (YT.IsDownload)
        {
            if (!IsAppUsed) IsAppUsed = true;
            await TaskProcessComp.DownloadTask(YT);
            ProcessEnds(true);
            Output_text.AddFormattedText("<Pink>[YEY] Download Completed!");
        }
        else ProcessEnds(false);
    }

    public static void ProcessEnds(bool IsDownload)
    {
        IsDownloading = false;
        WindowsComp.Window_Components(false);
        ProgressBarAnim.ProgressBarHide();
        OpenFolderCheck.OpenFolderChecks();
        Window_ProgressBar.Value = 0;

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

        if (MainWindowStatic.IsActive) TaskBarThingy.ProgressValue = 0;

        WindowsComp.WindowFlash();

        // DEBUG //
        //foreach (var item in TemporaryFormatList)
        //{
        //    Console.WriteLine(item);
        //}

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
        Input_Format.Items.Add(new
        {
            Name = $"[{options.format}] {options.resolution}; {options.size}",
            Id = $"[{Regex.Replace(options.id, "\\+.*", "")}]",
            Format = format,
            Resolution = options.resolution,
            Size = options.size,
            Bitrate = options.bitrate,
            Fps = options.fps
        });
        Output_text.AddFormattedText($"<#a85192%14>[SYSTEM] <Gray%14>Added:{options.resolution};    {options.size}");

        DebugOutput.FormatAdderDebug(options);
    }

}