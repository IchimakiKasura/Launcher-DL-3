namespace LauncherDL.Core.Buttons;

public abstract class FileFormatButton : IButtonControls
{
    public static async void ButtonClicked(object s, RoutedEventArgs e)
    {
        e.Handled = true;

        if(!await BodyButton.CheckLinkValidation())
            return;

        console.DLAddConsole(CONSOLE_INFO_STRING, "<%14>Loading File Formats...");

        YDL YDLInfo = new(
            new()
            {
                Link = textBoxLink.Text
            }
        );
        
        YDLInfo.IsFileFormat = true;

        YDLInfo.FileFormatMethod();

        WindowsComponents.FreezeComponents();
    }
}