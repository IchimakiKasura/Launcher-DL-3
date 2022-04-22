namespace Launcher_DL.Lib.Windows;

sealed class Buttons : Global
{
    public static async void FileFormat(object s, RoutedEventArgs e)
    {
        
        DebugOutput.Button_Clicked("format");
        
        if (string.IsNullOrEmpty(Input_Link.Text)) 
        {
            Output_text.AddFormattedText("<Yellow>[INFO] <>No Link");
            return;
        }

        WindowsComp.Window_Components(true);

        Output_text.AddFormattedText("<Yellow>[INFO] <>Validating Link:");
        Output_text.AddFormattedText($"<Gray%13>[LINK]	 {Input_Link.Text.Replace("<", "$lt$").Replace(">", "$gt$")}");

        LinkValidate ValidLink = await new LinkValidate().Validate(Input_Link.Text);

        if (ValidLink.IsFetched)
        {
            Output_text.AddFormattedText($"<Yellow>[INFO] <>Link is already fetched!");
            WindowsComp.Window_Components(false);
            return;
        }

        Input_Format.Items.Clear();
        TemporaryFormatList.Clear();
        TemporaryFormatNames.Clear();
        TemporarySelectedFileFormat = Input_Format.Text = "Best";

        if (ValidLink.IsValid == false)
        {
            Output_text.AddFormattedText("<Red>[ERROR] <>Link is not Valid!");
            WindowsComp.Window_Components(false);
            return;
        }

        OutputComments.FileFormatOutputComments();
        ProgressBarAnim.ProgressBarShow();
        await WorkProcess.StartProcess(new YTDL().YTDL_FileFormat());
    }

    public static async void Download(object s, RoutedEventArgs e)
    {
        DebugOutput.Button_Clicked("download");
                
        if (string.IsNullOrEmpty(Input_Link.Text)) 
        {
            Output_text.AddFormattedText("<Yellow>[INFO] <>No Link");
            return;
        }

        IsDownloading = true;

        if (!string.IsNullOrEmpty(Input_Name.Text))
        {
            string UnwantedChars = "\\/*:?\"<>|";
            char[] arr = UnwantedChars.ToCharArray();

            foreach (char ch in arr)
            {
                if (Input_Name.Text.Contains(ch))
                {
                    MessageBox.Show("File name cannot contain the following characters:\n                             \\ / * : ? \" < > |", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    IsDownloading = false;
                    return;
                }
            }

        }

        if (Input_Format.Text.Contains("-o")) 
        {
            MessageBox.Show("The \"-o\" is reserved, Instead change the \"output\" on the Config.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            Output_text.AddFormattedText("<Yellow>[INFO] <>The \"-o\" is reserved, Instead change the \"output\" on the Config.");
            IsDownloading = false;
            return;
        }

        WindowsComp.Window_Components(true);

        Output_text.AddFormattedText("<Yellow>[INFO] <>Validating Link:");
        Output_text.AddFormattedText($"<Gray%13>[LINK]	 {Input_Link.Text.Replace("<", "$lt$").Replace(">", "$gt$")}");

        LinkValidate ValidLink = await new LinkValidate().Validate(Input_Link.Text);

        if (ValidLink.IsValid == false)
        {
            Output_text.AddFormattedText("<Red>[ERROR] <>Link is not Valid!");
            IsDownloading = false;
            WindowsComp.Window_Components(false);
            return;
        }

        if (ValidLink.HasPlaylist)
            Output_text.AddFormattedText("<Yellow>[INFO] <>The Link is a Playlist...");

        OutputComments.DownloadOutputComments();
        ProgressBarAnim.ProgressBarShow();
        await WorkProcess.StartProcess(new YTDL().YTDL_Download());
    }

    public static async void ConvertFile(object s, RoutedEventArgs e)
    {
        if (string.IsNullOrEmpty(Input_Link.Text))
        {
            Output_text.AddFormattedText("<Red>[ERROR] <>No file selected!");
            return;
        }

        if (string.IsNullOrEmpty(Input_Name.Text))
        {
            Output_text.AddFormattedText("<Red>[ERROR] <>Name is Required!");
            return;
        }

        if (!File.Exists(Input_Link.Text))
        {
            Output_text.AddFormattedText("<Red>[ERROR] <>No file selected!");
            return;
        }


        ProgressBarAnim.ProgressBarShow();
        IsDownloading = true;
        WindowsComp.Window_Components(true);

        if (!Directory.Exists($"{Config.DefaultOutput}\\Convert"))
            Directory.CreateDirectory($"{Config.DefaultOutput}\\Convert");

        string Command = $"-i \"{Input_Link.Text}\" -q 0 \"{Config.DefaultOutput}\\Convert\\{Input_Name.Text}.{Input_Format.Text}\"";

        await ConvertProcess.ConvertFileType(Command);

        Output_text.AddFormattedText($"<Pink>[YEY] <>File converted: \"{Config.DefaultOutput}\\Convert\\{Input_Name.Text}.{Input_Format.Text}\"");

        if (MainWindowStatic.IsActive) TaskBarThingy.ProgressValue = 0;
        Window_ProgressBar.Value = 0;

        WindowsComp.WindowFlash();
        ProgressBarAnim.ProgressBarHide();
        WindowsComp.Window_Components(false);
        IsDownloading = false;
    }

    public static void OpenFile(object s, RoutedEventArgs e)
    {
        OpenFileDialog openFile = new();
        openFile.Filter = "All Media Files|*.wav;*.aac;*.wma;*.wmv;*.avi;*.mpg;*.mpeg;*.m1v;*.mp2;*.mp3;*.mpa;*.mpe;*.m3u;*.mp4;*.mov;*.3g2;*.3gp2;*.3gp;*.3gpp;*.m4a;*.cda;*.aif;*.aifc;*.aiff;*.mid;*.midi;*.rmi;*.mkv;*.WAV;*.AAC;*.WMA;*.WMV;*.AVI;*.MPG;*.MPEG;*.M1V;*.MP2;*.MP3;*.MPA;*.MPE;*.M3U;*.MP4;*.MOV;*.3G2;*.3GP2;*.3GP;*.3GPP;*.M4A;*.CDA;*.AIF;*.AIFC;*.AIFF;*.MID;*.MIDI;*.RMI;*.MKV;*.flv;*.FLV;*.ogg;*.OGG"; ;
        if (openFile.ShowDialog() == true)
        {
            Output_text.AddFormattedText($"<Yellow>[INFO] <>Selected file: \"{Path.GetFileName(openFile.FileName)}\"");
            Input_Link.Text = openFile.FileName;
        }
    }

    public static async void Update(object s, RoutedEventArgs e)
    {
        DebugOutput.Button_Clicked("update");
        WindowsComp.Window_Components(true);
        OutputComments.UpdateOutputComments();
        await WorkProcess.StartProcess(new YTDL().YTDL_Update());
    }

    public static void OpenFolder(string output)
    {
        bool IsExist = Directory.Exists($"{Directory.GetCurrentDirectory()}\\{output}");

        if (Config.DefaultOutput != "output")
            IsExist = Directory.Exists(output);

        if (!IsExist)
            output = Directory.GetCurrentDirectory();

        Process.Start(new ProcessStartInfo
        {
            Arguments = output,
            FileName = "explorer.exe"
        });
    }
}