namespace Launcher_DL_v6;

public partial class MainWindow
{
    private async Task StartProcess(YTDL_object YT)
    {
        DocumentTemp = Output_text.SaveText();

        if(YT.IsUpdate) await UpdateTask(YT);

		if (YT.IsFileFormat)
        {
            await FileFormatTask(YT);
            if (TemporaryFormatList.Count > 1)
            {
                Output_text.AddFormattedText($"<Pink>[YEY] Total formats: {TemporaryFormatList.Count}");
            }
            else
            {
                Output_text.AddFormattedText($"<Yellow>[INFO] Fetching format failed:\r" +
                "<Gray>1. Link is not supported?" +
                "<Gray%13>If link is not supported try downloading it using \"Video\" type\r or setting the Format option to \"best\"\r" +
                "<Gray>2. Slow internet might caused the problem.");
            }
        }

        if (YT.IsDownload)
        {
            await DownloadTask(YT);
            ProcessEnds(true);
            Output_text.AddFormattedText("<Pink>[YEY] Download Completed!");
        } else ProcessEnds(false);
    }

    private void ProcessEnds(bool IsDownload)
    {
        Window_Components(false);
        ProgressBarHide();
        Window_ProgressBar.Value = 0;

        if (IsDownload) Output_text.LoadText(DocumentTemp);

    }

    private void FormatAdder(dynamic options)
    {
        string format = options.format;

        // ye I kinda hate when its not aligned.
        if (options.format == "mp4") format = "mp4   ";
        if (options.format == "m4a") format = "m4a   ";
        if (options.format == "3gp") format = "3gp    ";

        TemporaryFormatNames.Add(options.data);
        TemporaryFormatList.Add(options.id);
        Input_Format.Items.Add($"[{format}]       {options.resolution}    -   {options.size};       {options.bitrate};      {options.fps}   ");
        Output_text.AddFormattedText($"<#a85192%14>[SYSTEM] <Gray%14>Added:{options.resolution};    {options.size}");
    }
}