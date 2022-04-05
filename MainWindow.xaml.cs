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

        if (Process.GetProcessesByName(Path.GetFileNameWithoutExtension(System.Reflection.Assembly.GetEntryAssembly().Location)).Length > 1)
        {
            MessageBox.Show("Only one instance at a time", "Yep", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            Environment.Exit(0);
        };

        // For Debug Purposes
        if (Console.OpenStandardInput(1) != Stream.Null)
        {
            DebugOutput.IsDebug = true;
            DebugOutput.StartUp();
        }

        Pre_Initialize();
        InitializeComponent();
        WindowFlash();
        MW = this;

        WindowStyle = WindowStyle.SingleBorderWindow;
        Window_VersionLabel.Text = Version;

        // hidden more like Patch/update notes
        Window_Hidden.MouseDown += delegate
        {
            Window_Components(false);
            MessageBox.Show(HiddenButtonText, "huzuaah!", MessageBoxButton.OK, MessageBoxImage.Asterisk);
        };

        InitializeTopButtons();
        Initialize();
    }
}
