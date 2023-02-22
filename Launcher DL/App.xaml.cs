namespace Launcher_DL
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
		private void App_Startup(object s, StartupEventArgs e)
		{
			PresentationTraceSources.DataBindingSource.Switch.Level = SourceLevels.Off;
			Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.BelowNormal;
			ContextMenuAdjust();

			#if !DEBUG
				DispatcherUnhandledException += new DispatcherUnhandledExceptionEventHandler(AppDispatcherUnhandledException);
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
