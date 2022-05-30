namespace Launcher_DL.Lib.Windows;

sealed class TopButtons : Global
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