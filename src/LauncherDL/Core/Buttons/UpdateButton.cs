namespace LauncherDL.Core.Buttons;

public class UpdateButton
{
    public static void ButtonClicked(object s, RoutedEventArgs e)
    {
        e.Handled = true;
        
        WindowsComponents.FreezeComponents();

		console.DLAddConsole(CONSOLE_INFO_STRING, "<%14>Updating...");

        var YDLInfo = new YDL(new());
        YDLInfo.IsUpdate = true;

        YDLInfo.UpdateMethod();
    }
}