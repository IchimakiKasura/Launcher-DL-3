namespace LauncherDL.Core.Windows;

interface IWindowsComponents
{
    abstract static void WindowLoaded(object s, RoutedEventArgs e); 
    abstract static void WindowOnClose(object s, CancelEventArgs e); 
    abstract static void WindowFocusAnimation(); 
    abstract static void WindowDrag(object sender, MouseButtonEventArgs e); 
    abstract static bool WindowTaskBarFlash(); 
    abstract static void FreezeComponents(); 
}