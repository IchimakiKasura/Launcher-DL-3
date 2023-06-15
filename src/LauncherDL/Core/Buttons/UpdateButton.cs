namespace LauncherDL.Core.Buttons;

internal sealed class UpdateButton : IButtonControls
{
    public static void ButtonClicked(object s, RoutedEventArgs e)
    {
        e.Handled = true;

        console.DLAddConsole(CONSOLE_INFO_STRING, "Updating...");

        var YDLInfo = new YDL(new())
        {
            IsUpdate = true
        };

        YDLInfo.UpdateMethod();

        WindowsComponents.FreezeComponents();
    }
}