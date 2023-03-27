namespace LauncherDL.Core.Buttons;

internal class UpdateButton : IButtonControls
{
    public static void ButtonClicked(object s, RoutedEventArgs e)
    {
        e.Handled = true;

        console.DLAddConsole(CONSOLE_INFO_STRING, "Updating...");

        var YDLInfo = new YDL(new());
        YDLInfo.IsUpdate = true;

        YDLInfo.UpdateMethod();

        WindowsComponents.FreezeComponents();
    }
}