namespace Launcher_DL;

// TODO:
//
//  Implement the YDL.cs based on the old script from v6	
//
//  After implementing YDL, please just don't over use the TASK method again
//  to avoid that "Cannot re-enter paragraph" error Try using background task.
//
// wa:
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

		InitiateStaticComponents(this);

		#if DEBUG
			ConsoleDebug.InitiateConsoleDebug();
		#endif

		config = Config.ReadConfigINI();
		OnStartUp.Initialize();

		buttonFileFormat.Click += delegate
		{
			WindowsComponents.WindowProgressBar(ProgressBarState.Show);
		};

		buttonDownload.Click += delegate
		{
			WindowsComponents.WindowProgressBar(ProgressBarState.Hide);
		};

		buttonUpdate.Click += delegate
		{
			WindowsComponents.FreezeComponents(true);
		};

		buttonOpenFile.Click += delegate
		{
			WindowsComponents.FreezeComponents(false);
			console.AddFormattedText("<%20>UNFREEZE!");
		};
	}
}