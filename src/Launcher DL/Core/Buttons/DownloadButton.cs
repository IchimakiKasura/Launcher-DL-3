namespace Launcher_DL.Core.Buttons;

public class DownloadButton
{
    public static void ButtonClicked(object s, RoutedEventArgs e)
    {
        e.Handled = true;

        // Checks if the button is set to Convert
        if(comboBoxType.ItemIndex == 3) 
            ButtonConvertClicked();
            
        BodyButton.CheckLinkValidation();
    }

    public static void ButtonConvertClicked()
    {

    }
}