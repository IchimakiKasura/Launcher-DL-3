namespace LauncherDL.Core.Buttons;

class TopButtons : ITopBarButtons
{
    public static void CloseWindow(object sender, RoutedEventArgs handler)    =>
        MainWindowStatic.Close();
    public static void MinimizeWindow(object sender, RoutedEventArgs handler) =>
        MainWindowStatic.WindowState = WindowState.Minimized;
}

