namespace Launcher_DL;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{

	const uint ENABLE_QUICK_EDIT = 0x0040;
	#region DLL imports
	[DllImport("user32.dll")]
	private static extern int DeleteMenu(IntPtr hMenu, int nPosition, int wFlags);
	[DllImport("user32.dll")]
	private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);
	[DllImport("kernel32.dll", ExactSpelling = true)]
	private static extern IntPtr GetConsoleWindow();
	[DllImport("Kernel32")]
	private static extern void AllocConsole();
	[DllImport("kernel32.dll", SetLastError = true)]
	private static extern IntPtr GetStdHandle(int nStdHandle);

	[DllImport("kernel32.dll")]
	static extern bool GetConsoleMode(IntPtr hConsoleHandle, out uint lpMode);

	[DllImport("kernel32.dll")]
	static extern bool SetConsoleMode(IntPtr hConsoleHandle, uint dwMode);
	#endregion

	private void App_Startup(object s, StartupEventArgs e)
	{
		//idk
		PresentationTraceSources.DataBindingSource.Switch.Level = SourceLevels.Off;

		Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.High;

		#if DEBUG
			// none
		#else
			DispatcherUnhandledException += new DispatcherUnhandledExceptionEventHandler(AppDispatcherUnhandledException);
		#endif

		// Checks if there's new version of the Launcher DL
		Update.Updater Update = new();

		// Prevents opening another app.
		if (Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName).Length > 1)
		{
			MessageBox.Show("Only one instance at a time", "Launcher DL", MessageBoxButton.OK, MessageBoxImage.Exclamation);
			Environment.Exit(0);
		};

		ContextMenuAdjust();

		if (e.Args.Length == 1)
		{
			if (e.Args[0] != "--debug") return;
			AllocConsole();

			IntPtr consoleHandle = GetStdHandle(-10);
			DeleteMenu(GetSystemMenu(GetConsoleWindow(), false), 0xF060, 0x00000000);
			DeleteMenu(GetSystemMenu(GetConsoleWindow(), false), 0xF020, 0x00000000);
			DeleteMenu(GetSystemMenu(GetConsoleWindow(), false), 0xF030, 0x00000000);
			GetConsoleMode(consoleHandle, out uint consoleMode);
			consoleMode &= ~ENABLE_QUICK_EDIT;
			SetConsoleMode(consoleHandle, consoleMode);
		}
	}

	private void App_Exit(object s, ExitEventArgs e)
	{
		// To be used in future.
	}

	// Fixes the drop menus going from right to left because i don't know what happened.
	// Some say its because of the Tablet but I don't use Tablet PC or even have one.
	private void ContextMenuAdjust()
	{
		var menuDropAlignmentField = typeof(SystemParameters).GetField("_menuDropAlignment", BindingFlags.NonPublic | BindingFlags.Static);
		Action setAlignmentValue = () =>
		{
			if (SystemParameters.MenuDropAlignment && menuDropAlignmentField != null) menuDropAlignmentField.SetValue(null, false);
		};

		setAlignmentValue();

		SystemParameters.StaticPropertyChanged += (sender, e) =>
		{
			setAlignmentValue();
		};
	}

	private void AppDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
	{
		CancellationTokenSource oldSource = Interlocked.Exchange(ref Global.CancelWork, null);
		if (oldSource != null)
		{
			oldSource.Cancel();
			oldSource.Dispose();
		}

		Global.IsDownloading = false;
		string errorMessage = $"It Appears the the application encounters an Error!\n\n{e.Exception}";

		// Checks if the Unhandled exception has a custom message.
		try
		{
			if (e.Exception.InnerException != null)
				errorMessage = $"It Appears the the application encounters an Error!\n\n{e.Exception.InnerException.Message}";
		}
		catch { };

		if(Global.Output_text != null)
		{
			Global.IsAppUsed = true;
			Global.Output_text.Break("Red");
			Global.Output_text.AddText(errorMessage, "Red");
			Global.Output_text.Break("Red");
		}

		DebugOutput.UnhandledError(errorMessage);

		if (MessageBox.Show(MainWindow, errorMessage, "Error", MessageBoxButton.OK, MessageBoxImage.Error) == MessageBoxResult.OK)
			MainWindow.Close();

		e.Handled = true;
	}
}