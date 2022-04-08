namespace Launcher_DL_v6;

public partial class MainWindow
{
    public async void FileFormat(object s, RoutedEventArgs e)
    {
        
        DebugOutput.Button_Clicked("format");

        Input_Format.Items.Clear();
        TemporaryFormatList.Clear();
        TemporaryFormatNames.Clear();
        TemporarySelectedFileFormat = Input_Format.Text = "Best";
        
        Window_Components(true);

        Output_text.AddFormattedText("<Yellow>[INFO] <>Validating Link:");
        Output_text.AddFormattedText($"<Gray%13>[LINK]	 {Input_Link.Text.Replace("<","$lt$").Replace(">","$gt$")}");

        ValidateLink ValidLink = await new ValidateLink().Validate(Input_Link.Text);

        if (ValidLink.IsValid == false)
        {
            Output_text.AddFormattedText("<Red>[ERROR] <>Link is not Valid!");
            Window_Components(false);
            return;
        }

        OutputComments.FileFormatOutputComments();
        ProgressBarShow();
        await StartProcess(YTDL_FileFormat());
    }

    public async void Download(object s, RoutedEventArgs e)
    {
        DebugOutput.Button_Clicked("download");
        IsDownloading = true;

        if (!string.IsNullOrEmpty(Input_Name.Text))
        {
            string UnwantedChars = "\\/*:?\"<>|";
            char[] arr = UnwantedChars.ToCharArray();

            foreach(char ch in arr)
            {
                if(Input_Name.Text.Contains(ch))
                {
                    MessageBox.Show("File name cannot contain the following characters:\n                             \\ / * : ? \" < > |", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    IsDownloading = false;
                    return;
                }
            }

        }

        Window_Components(true);

        Output_text.AddFormattedText("<Yellow>[INFO] <>Validating Link:");
        Output_text.AddFormattedText($"<Gray%13>[LINK]	 {Input_Link.Text.Replace("<", "$lt$").Replace(">", "$gt$")}");

        ValidateLink ValidLink = await new ValidateLink().Validate(Input_Link.Text);

        if (ValidLink.IsValid == false)
        {
            Output_text.AddFormattedText("<Red>[ERROR] <>Link is not Valid!");
            IsDownloading = false;
            Window_Components(false);
            return;
        }

        if (ValidLink.HasPlaylist)
        {
            Output_text.AddFormattedText("<Yellow>[INFO] <>The Link is a Playlist...");
        }

        OutputComments.DownloadOutputComments();
        ProgressBarShow();
        await StartProcess(YTDL_Download());
    }

    // This is kinda messy
    public async void ConvertFile(object s, RoutedEventArgs e)
	{        
        if(string.IsNullOrEmpty(Input_Link.Text))
        {
            Output_text.AddFormattedText("<Red>[ERROR] <>No file selected!");
            return;
        }

        if(string.IsNullOrEmpty(Input_Name.Text))
        {
            Output_text.AddFormattedText("<Red>[ERROR] <>Name is Required!");
            return;
        }

        if(!File.Exists(Input_Link.Text))
        {
            Output_text.AddFormattedText("<Red>[ERROR] <>No file selected!");
            return;
        }


        ProgressBarShow();
        IsDownloading = true;
        Window_Components(true);

        if(!Directory.Exists($"{Config.DefaultOutput}\\Convert"))
            Directory.CreateDirectory($"{Config.DefaultOutput}\\Convert");

        string Command = $"-i \"{Input_Link.Text}\" -q 0 \"{Config.DefaultOutput}\\Convert\\{Input_Name.Text}.{Input_Format.Text}\"";
        
        
        Proc = new();
        Proc.StartInfo = new($"{Ffmpeg}\\ffmpeg.exe", Command)
        {
            UseShellExecute = false,
            RedirectStandardError = true,
            CreateNoWindow = true
        };
        
        Output_text.AddFormattedText("<#83fa57>[PROCESSING] <>Please wait until the conversion is finished.");
       
        Proc.EnableRaisingEvents = true;
        Proc.ErrorDataReceived += ConvertOutput;
        Proc.Start();
        Proc.BeginErrorReadLine();
        await Proc.WaitForExitAsync();
        
        Output_text.AddFormattedText($"<Pink>[YEY] <>File converted: \"{Config.DefaultOutput}\\Convert\\{Input_Name.Text}.{Input_Format.Text}\"");
        
        if (IsActive) TaskBarThingy.ProgressValue = 0;
        Window_ProgressBar.Value = 0;
        
        WindowFlash();
        ProgressBarHide();
        Window_Components(false);
        IsDownloading = false;
    }

    public void OpenFile(object s, RoutedEventArgs e)
    {
        OpenFileDialog openFile = new();
        openFile.Filter = "All Media Files|*.wav;*.aac;*.wma;*.wmv;*.avi;*.mpg;*.mpeg;*.m1v;*.mp2;*.mp3;*.mpa;*.mpe;*.m3u;*.mp4;*.mov;*.3g2;*.3gp2;*.3gp;*.3gpp;*.m4a;*.cda;*.aif;*.aifc;*.aiff;*.mid;*.midi;*.rmi;*.mkv;*.WAV;*.AAC;*.WMA;*.WMV;*.AVI;*.MPG;*.MPEG;*.M1V;*.MP2;*.MP3;*.MPA;*.MPE;*.M3U;*.MP4;*.MOV;*.3G2;*.3GP2;*.3GP;*.3GPP;*.M4A;*.CDA;*.AIF;*.AIFC;*.AIFF;*.MID;*.MIDI;*.RMI;*.MKV;*.flv;*.FLV";;
        if (openFile.ShowDialog() == true)
        {
            Output_text.AddFormattedText($"<Yellow>[INFO] <>Selected file: \"{Path.GetFileName(openFile.FileName)}\"");
            Input_Link.Text = openFile.FileName;
        }
    }

    public async void Update(object s, RoutedEventArgs e)
    {
        DebugOutput.Button_Clicked("update");
        Window_Components(true);
        OutputComments.UpdateOutputComments();
        await StartProcess(YTDL_Update());
    }

    public void OpenFolder(string output)
    {
        bool IsExist;

        if (Config.DefaultOutput == "output")
        {
            IsExist = Directory.Exists($"{Directory.GetCurrentDirectory()}\\{output}");
        }
        else
        {
            IsExist = Directory.Exists(output);
        }

        if (!IsExist)
        {
            output = Directory.GetCurrentDirectory();
        }

        Process.Start(new ProcessStartInfo
        {
            Arguments = output,
            FileName = "explorer.exe"
        });
    }
}