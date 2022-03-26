namespace Launcher_DL_v6;

///==============================================================///
///            ████████╗██████╗░░█████╗░██████╗░░██████╗         ///
///            ╚══██╔══╝██╔══██╗██╔══██╗██╔══██╗██╔════╝         ///
///            ░░░██║░░░██████╔╝███████║██████╔╝╚█████╗░         ///
///            ░░░██║░░░██╔══██╗██╔══██║██╔═══╝░░╚═══██╗         ///
///            ░░░██║░░░██║░░██║██║░░██║██║░░░░░██████╔╝         /// 
/// I lov-like ░░░╚═╝░░░╚═╝░░╚═╝╚═╝░░╚═╝╚═╝░░░░░╚═════╝░ no homo*///
/// =============================================================///

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        MW = this;

        WindowStyle = WindowStyle.SingleBorderWindow;
        Window_VersionLabel.Text = Version;

        Window_Hidden.MouseDown += delegate
        {
            Window_Components(false);
            MessageBox.Show(HiddenButtonText, "huzuaah!", MessageBoxButton.OK, MessageBoxImage.Asterisk);
        };

        Input_MpThreeFormat.Click += delegate
        {
            Config.AlwayDownloadInMP3 = Input_MpThreeFormat.IsChecked.Value;
        };

        InitializeTopButtons();
        Initialize();
    }
}
