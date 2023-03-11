namespace LauncherDL
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
		private static System.Threading.Mutex _mutex = null;
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

		protected override void OnStartup(StartupEventArgs e)
		{
			string appName = Assembly.GetExecutingAssembly().GetName().Name;
			bool createdNew;

			_mutex = new(true, appName, out createdNew);

			if (!createdNew)
				if (MessageBox.Show("Only one instance at a time!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning) == MessageBoxResult.OK)
					Application.Current.Shutdown();		

			App_Startup(null,e);
		}    

		private void App_Startup(object s, StartupEventArgs e)
		{
			PresentationTraceSources.DataBindingSource.Switch.Level = SourceLevels.Off;
			Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.BelowNormal;
			ContextMenuAdjust();

			var Update = new Update.Updater();

			#if !DEBUG
				DispatcherUnhandledException += new DispatcherUnhandledExceptionEventHandler(AppDispatcherUnhandledException);
			#else
				AllocConsole();

				IntPtr consoleHandle = GetStdHandle(-10);
				DeleteMenu(GetSystemMenu(GetConsoleWindow(), false), 0xF060, 0x00000000);
				DeleteMenu(GetSystemMenu(GetConsoleWindow(), false), 0xF020, 0x00000000);
				DeleteMenu(GetSystemMenu(GetConsoleWindow(), false), 0xF030, 0x00000000);
				GetConsoleMode(consoleHandle, out uint consoleMode);
				consoleMode &= ~ENABLE_QUICK_EDIT;
				SetConsoleMode(consoleHandle, consoleMode);

				Console.WriteLine(
@$"============================
=   Version Update Check   =
============================
Current Version: {Update.CurrentVersion}
Latest Version: {Update.NewVersion}
				");
			#endif
		}

		// F̶i̶x̶e̶s̶ ̶t̶h̶e̶ ̶d̶r̶o̶p̶ ̶m̶e̶n̶u̶s̶ ̶g̶o̶i̶n̶g̶ ̶f̶r̶o̶m̶ ̶r̶i̶g̶h̶t̶ ̶t̶o̶ ̶l̶e̶f̶t̶ ̶b̶e̶c̶a̶u̶s̶e̶ ̶i̶ ̶d̶o̶n̶'̶t̶ ̶k̶n̶o̶w̶ ̶w̶h̶a̶t̶ ̶h̶a̶p̶p̶e̶n̶e̶d̶.̶
		// S̶o̶m̶e̶ ̶s̶a̶y̶ ̶i̶t̶s̶ ̶b̶e̶c̶a̶u̶s̶e̶ ̶o̶f̶ ̶t̶h̶e̶ ̶T̶a̶b̶l̶e̶t̶ ̶b̶u̶t̶ ̶I̶ ̶d̶o̶n̶'̶t̶ ̶u̶s̶e̶ ̶T̶a̶b̶l̶e̶t̶ ̶P̶C̶ ̶o̶r̶ ̶e̶v̶e̶n̶ ̶h̶a̶v̶e̶ ̶o̶n̶e̶.
		//
		// This context menu popup problem only occurs i think on Win11 because of the Pen Tablet thing.
		// Even though the Registry MenuDropDownAlignment is defaulted its still shows Right to Left on WPF apps
		// and this method fixes that problem on win11 users.
		//
		// see more on this issue: https://github.com/dotnet/wpf/issues/5944
		private static void ContextMenuAdjust()
		{
			var menuDropAlignmentField = typeof(SystemParameters).GetField("_menuDropAlignment", BindingFlags.NonPublic | BindingFlags.Static);
			
			void setAlignmentValue()
			{
				if (SystemParameters.MenuDropAlignment && menuDropAlignmentField != null) menuDropAlignmentField.SetValue(null, false);	
			}
			
			setAlignmentValue();

			SystemParameters.StaticPropertyChanged += (sender, e) => setAlignmentValue();
		}

		private void AppDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
		{
			var CurrentDate = DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss");
			File.WriteAllText(
				$"ErrorDumpTrace_{CurrentDate}.txt",
				$"{e.Exception.Message}\n\n\n===Custom Message===\n{e.Exception.InnerException.Message}"
			);

			string errorMessage = $"It Appears the the application encounters an Error!\n\n{e.Exception.Message}";

			// Checks if the Unhandled exception has a custom message.
			if (e.Exception.InnerException != null)
				errorMessage = $"It Appears the the application encounters an Error!\n\n{e.Exception.InnerException.Message}";			

			if (MessageBox.Show(MainWindow, errorMessage, "Error", MessageBoxButton.OK, MessageBoxImage.Error) == MessageBoxResult.OK)
				Application.Current.Shutdown();

			e.Handled = true;
		}
	}
}
