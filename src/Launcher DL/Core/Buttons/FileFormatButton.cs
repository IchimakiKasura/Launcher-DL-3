namespace Launcher_DL.Core.Buttons;

public abstract class FileFormatButton
{
    public static void ButtonClicked(object s, RoutedEventArgs e)
    {
        e.Handled = true;

        BodyButton.CheckLinkValidation();
    }

}