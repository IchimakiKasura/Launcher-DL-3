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
        Output_text.AddFormattedText($"<Gray%13>[LINK]	 {Input_Link.Text}");

        ValidateLink ValidLink = await new ValidateLink().Validate(Input_Link.Text);

        if (ValidLink.IsValid == false)
        {
            Output_text.AddFormattedText("<Red>[ERROR] <>Link is not Valid!");
            Window_Components(false);
            return;
        }

        OutputComments.FileFormatOutputComments();

        await StartProcess(YTDL_FileFormat());
    }

    public async void Download(object s, RoutedEventArgs e)
    {
        DebugOutput.Button_Clicked("download");
        IsDownloading = true;

        if (Input_Name.Text == "Unavailable")
        {
            MessageBox.Show("This specific Text is reserved!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            IsDownloading = false;
            return;
        }

        Window_Components(true);

        if (string.IsNullOrEmpty(Input_Name.Text)) Input_Name.Text = "Unavailable";

        Output_text.AddFormattedText("<Yellow>[INFO] <>Validating Link:");
        Output_text.AddFormattedText($"<Gray%13>[LINK]	 {Input_Link.Text}");

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

        if (Input_Type.SelectedIndex != 2) Input_MpThreeFormat.IsChecked = false;

        OutputComments.DownloadOutputComments();

        await StartProcess(YTDL_Download());
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