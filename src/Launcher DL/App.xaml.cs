namespace Launcher_DL
{
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
			PresentationTraceSources.DataBindingSource.Switch.Level = SourceLevels.Off;
			Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.BelowNormal;
			ContextMenuAdjust();

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
			#endif
		}

		// Fixes the drop menus going from right to left because i don't know what happened.
		// Some say its because of the Tablet but I don't use Tablet PC or even have one.
		private static void ContextMenuAdjust()
		{
			var menuDropAlignmentField = typeof(SystemParameters).GetField("_menuDropAlignment", BindingFlags.NonPublic | BindingFlags.Static);
			void setAlignmentValue()
			{
				if (SystemParameters.MenuDropAlignment && menuDropAlignmentField != null) menuDropAlignmentField.SetValue(null, false);
			}

			setAlignmentValue();

			SystemParameters.StaticPropertyChanged += (sender, e) =>
			{
				setAlignmentValue();
			};
		}

		private void AppDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
		{
			string errorMessage = $"It Appears the the application encounters an Error!\n\n{e.Exception.Message}";

			// Checks if the Unhandled exception has a custom message.
			if (e.Exception.InnerException != null)
				errorMessage = $"It Appears the the application encounters an Error!\n\n{e.Exception.InnerException.Message}";

			if (MessageBox.Show(MainWindow, errorMessage, "Error", MessageBoxButton.OK, MessageBoxImage.Error) == MessageBoxResult.OK)
				MainWindow.Close();

			e.Handled = true;
		}
	}
}
