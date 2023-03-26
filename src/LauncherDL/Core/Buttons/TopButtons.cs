namespace LauncherDL.Core.Buttons;

class TopButtons
{
    public static void CloseWindow(object sender, RoutedEventArgs handler)
    {
        if(!IsInProcess)
            MainWindowStatic.Close();
    }
    public static void MinimizeWindow(object sender, RoutedEventArgs handler) =>
        MainWindowStatic.WindowState = WindowState.Minimized;
    
}

