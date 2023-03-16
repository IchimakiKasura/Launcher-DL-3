namespace LauncherDL.Core.Buttons;

public abstract class FileFormatButton
{
    public static void ButtonClicked(object s, RoutedEventArgs e)
    {
        e.Handled = true;

        var IsSuccess = BodyButton.CheckLinkValidation();
        if(!IsSuccess) return;

        console.DLAddConsole(CONSOLE_INFO_STRING, "<%14>Loading File Formats...");

        YDL YDLInfo = new(
            new()
            {
                Link = textBoxLink.Text
            }
        );
        
        YDLInfo.IsFileFormat = true;

        YDLInfo.FileFormatMethod();
    }

}