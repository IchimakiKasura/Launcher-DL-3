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
    string Version = "Build Version:\nDevelopment Build";

    public static MainWindow MW;
    DoubleAnimation Opac;
    ColorAnimation Anim;

    public MainWindow()
    {
        InitializeComponent();

        MW = this;

        WindowStyle = WindowStyle.SingleBorderWindow;
        Window_VersionLabel.Text = Version;
        Window_Hidden.MouseDown += delegate
        {
            MessageBox.Show("LauncherDL buildver6.0\n\nOMG this is so Ｅ Ｐ Ｉ Ｃ!!\n\nNew GUI/Layout, Animations!?!\n\nThe OLD Button Hover Animation from ver3 is even back!??\n\n\nCreated by Kasura.", "huzuaah!", MessageBoxButton.OK, MessageBoxImage.Asterisk);
        };

        InitializeTopButtons();
        Initialize();
        LoadConfig();
    }

    // hides the Window's Border so it will looks like the "WindowStyle: None"
    // so THAT IT HAS A MINIMIZE ANIMATION. not just when you minimize it just 
    // disappear.
    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
        var transparencyConverter = new WpfApplication2.TransparencyConverter(this);
        transparencyConverter.MakeTransparent();
    }

    // disable Tab navigation completely
    private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.Tab)
        {
            e.Handled = true;
        }
    }
}
