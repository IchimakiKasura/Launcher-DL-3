namespace Launcher_DL.Core.Buttons;

public class UpdateButton
{
    public static void ButtonClicked(object s, RoutedEventArgs e)
    {
        e.Handled = true;
        
        WindowsComponents.FreezeComponents();
    }
}