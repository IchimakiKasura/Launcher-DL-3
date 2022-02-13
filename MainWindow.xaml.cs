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
            MessageBox.Show("LauncherDL buildver6.0\n\nOMG this is so Ｅ Ｐ Ｉ Ｃ!!\n\nNew GUI/Layout, Animations!?!\n\nThe OLD Button Hover Animation from ver3 is even back!??\n\n\nCreated by Kasura.", "huzuaah!", MessageBoxButton.OK, MessageBoxImage.Asterisk);
        };

        InitializeTopButtons();
        Initialize();
        LoadConfig();
    }
}
