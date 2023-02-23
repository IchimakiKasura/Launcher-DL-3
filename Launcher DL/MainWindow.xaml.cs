namespace Launcher_DL;

// TODO:
//	Finish making the UserControl for the ComboBox
//
//	Create Seperate Storyboard for when "EpicAnimation" is off
//	
//	
//
// TOFIX:
//	nothing, just clean the code idk.
//	Take more time. (what)

//=========================================================//
//   ██████╗██╗  ██╗██╗███████╗ █████╗ ████████╗ ██████╗   //
//  ██╔════╝██║  ██║██║██╔════╝██╔══██╗╚══██╔══╝██╔═══██╗  //
//  ██║     ███████║██║███████╗███████║   ██║   ██║   ██║  //
//  ██║     ██╔══██║██║╚════██║██╔══██║   ██║   ██║   ██║  //
//  ╚██████╗██║  ██║██║███████║██║  ██║   ██║   ╚██████╔╝  //
//   ╚═════╝╚═╝  ╚═╝╚═╝╚══════╝╚═╝  ╚═╝   ╚═╝    ╚═════╝   //
//=========================================================//
public partial class MainWindow : Window
{
    public MainWindow()
    {
		InitializeComponent();

		WindowStyle = WindowStyle.SingleBorderWindow;

		MainWindowStatic = this;
		config = Config.ReadConfigINI();

		InitiateStaticComponents();

		#if DEBUG
		ConsoleDebug.InitiateConsoleDebug();
		#endif

		OnStartUp.Initialize();
	}
}
