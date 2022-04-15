namespace Launcher_DL;

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
        if (Console.OpenStandardInput(1) != Stream.Null)
        {
            DebugOutput.IsDebug = true;
            DebugOutput.StartUp();
        }

        InitializeComponent();
        StaticSetup();
        Global.MainWindowStatic = this;

        // Setups an Event for taskbar flashing
        WindowsComp.WindowFlash();

        Window_VersionLabel.Text = Global.AppVersion;

        // hidden more like Patch/update notes
        Window_Hidden.MouseDown += delegate
        {
            MessageBox.Show(Global.HiddenButtonText, "huzuaah!", MessageBoxButton.OK, MessageBoxImage.Asterisk);
        };

        // Configures the Top Buttons Events
        TopButtons.InitializeTopButtons();

        // Configures the rest of the Components Events
        InitialStartUp.Initialize();
    }
}