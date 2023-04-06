namespace LauncherDL.Core.Buttons;

public interface IButtonControls
{
    abstract static void ButtonClicked(object s, RoutedEventArgs e);
}

public interface ITopBarButtons
{
    abstract static void CloseWindow(object s, RoutedEventArgs e);
    abstract static void MinimizeWindow(object s, RoutedEventArgs e);
}