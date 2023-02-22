namespace Launcher_DL.Core.Buttons;

class TopButtons
{
	public static void InitializeTopButtons()
	{
		CloseButton.Click += CloseWindow;
		Minimize.Click += MinimizeWindow;
	}
	public static void CloseWindow(object sender, RoutedEventArgs handler)
	{
		MainWindowStatic.Close();
	}
	public static void MinimizeWindow(object sender, RoutedEventArgs handler)
	{
		MainWindowStatic.WindowState = WindowState.Minimized;
	}
}

