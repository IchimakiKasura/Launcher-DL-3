namespace Launcher_DL_v6;

public partial class MainWindow
{
    private void InitializeTopButtons()
    {
        CloseButton.Click += CloseWindow;
        Minimize.Click += MinimizeWindow;
    }
    private void WindowDrag(object sender, MouseButtonEventArgs e) { if (e.ChangedButton == MouseButton.Left) this.DragMove(); }

    private void CloseWindow(object sender, RoutedEventArgs handler)
    {
        Application.Current.Shutdown();
    }
    private void MinimizeWindow(object sender, RoutedEventArgs handler)
    {
        WindowState = WindowState.Minimized;
    }
}
