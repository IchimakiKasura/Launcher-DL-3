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
        // For Debug Purposes
        if(Console.OpenStandardInput(1) != Stream.Null)
        {
            // this.KeyDown += delegate (object s, KeyEventArgs e){
            //     if(e.Key == Key.P)
            //     {
            //         DebugOutput.Test_Debug();
            //     }
            // };
            DebugOutput.IsDebug = true;
            DebugOutput.StartUp();
        }

        InitializeComponent();
        MW = this;

        WindowStyle = WindowStyle.SingleBorderWindow;
        Window_VersionLabel.Text = Version;

        // hidden more like Patch/update notes
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
