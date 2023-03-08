namespace Launcher_DL.Core.Buttons;

public class DownloadButton
{
    public static void ButtonClicked(object s, RoutedEventArgs e)
    {
        WindowsComponents.FreezeComponents();
        BodyButton.CheckURL();
    }
}