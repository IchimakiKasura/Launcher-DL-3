namespace Launcher_DL.Lib.PostProcessOutput;

sealed class OutputComments : Global
{
    public static void DownloadOutputComments()
    {
        Input_Name.Text = Input_Name.Text.Trim();
        string Name = Input_Name.Text;
        string FileFormatName;

        // Check the ComboBox if any changes made to the File Format Text
        FileFormatName = Input_Format.Text;
        if (Input_Type.SelectedIndex == 0)
        {
            TemporarySelectedFileFormat = Input_Format.Text;
            if (Input_Format.SelectedIndex != -1)
                TemporarySelectedFileFormat = TemporaryFormatList[Input_Format.SelectedIndex];
        }

        if (string.IsNullOrEmpty(Input_Name.Text)) Name = "N/A";

        Output_text.Break("gray");
        Output_text.AddFormattedText($"<gray%11>[] Title:		 	 {CurrentLinkTitle}");
        Output_text.AddFormattedText($"<gray%11>[] Download Type:	 {Input_Type.Text}");
        Output_text.AddFormattedText($"<gray%11>[] Name:		 {Name}");
        Output_text.AddFormattedText($"<gray%11>[] Format:		 {FileFormatName}");
        Output_text.AddFormattedText($"<gray%11>[] Link:			 {Input_Link.Text}");
        Output_text.AddFormattedText($"<gray%11>[] Playlist?:		 {Config.EnablePlaylist}");
        Output_text.Break("gray");
        Output_text.AddFormattedText("<Yellow>[INFO] <>Downloading...");

        DebugOutput.Button_Output("download", new
        {
            DT = Input_Type.Text,
            Name = Name,
            Format = FileFormatName,
            Link = Input_Link.Text,
            Playlist = Config.EnablePlaylist
        });

    }

    public static void UpdateOutputComments()
    {
        Output_text.AddFormattedText("<Yellow>[INFO] <>Updating...");
        DebugOutput.Button_Output("update");
    }

    public static void FileFormatOutputComments()
    {
        Output_text.AddFormattedText("<Yellow>[INFO] <>Loading File Formats...");
        DebugOutput.Button_Output("format");
    }

    public static void DownloadOutputCommentsLive(MemoryStream DocumentTemp, string StringData)
    {

        Output_text.LoadText(DocumentTemp);

        string progress = RegexComp.progress.Match(StringData).Groups["percent"].ToString();
        string size = RegexComp.progress.Match(StringData).Groups["size"].ToString();
        string speed = RegexComp.progress.Match(StringData).Groups["speed"].ToString();
        string eta = RegexComp.progress.Match(StringData).Groups["time"].ToString();
        string TotalPlaylistDownloaded = string.Empty;


        // Playlist
        if (StringData.Contains("[download] Downloading video"))
        {
            TotalPlaylistDownloaded = Regex.Match(StringData, @"[0-9].*of.*").Value;
        }

        string color = "White";

        #region Change Foreground based on the speed.
        if (speed.Contains("K"))
        {
            double speeds = double.Parse(Regex.Replace(speed, @"[a-zA-Z\/]", "").ToString());
            if (speeds < 199.99) color = "#381900";
            else color = "Red";
        }
        if (speed.Contains("M"))
        {
            double speeds = double.Parse(Regex.Replace(speed, @"[a-zA-Z\/]", "").ToString());
            if (speeds < 0.99) color = "#fff154";
            else color = "#83fa57";
        }
        if (speed.Contains("G")) color = "Pink";
        #endregion

        if (TotalPlaylistDownloaded != string.Empty) Output_text.AddFormattedText($"<Cyan>[ Playlist  ] <>{TotalPlaylistDownloaded}");

        Output_text.AddFormattedText($"<Cyan>[ PROGRESS		] <>{progress.Trim()}%");
        Output_text.AddFormattedText($"<Cyan>[ SIZE			] <>{size}");
        Output_text.AddFormattedText($"<Cyan>[ SPEED			] <{color}>{speed}");
        Output_text.AddFormattedText($"<Cyan>[ TIME LEFT		] <>{eta}");

        if (progress != string.Empty)
            Window_ProgressBar.Value = int.Parse(Regex.Replace(progress.Trim(), @"\..*", "", RegexOptions.Compiled).ToString());

    }

}