namespace LauncherDL.Core.Buttons;

public class DownloadButton
{
    public static void ButtonClicked(object s, RoutedEventArgs e)
    {
        e.Handled = true;

        // Checks if the button is set to Convert
        if(comboBoxType.ItemIndex == 3) 
        {
            ButtonConvertClicked();
            return;
        }
            
        var IsSuccess = BodyButton.CheckLinkValidation();
        if(!IsSuccess) return;

        // To be removed
        #if DEBUG
            if(comboBoxFormat.ItemIndex > -1)
            {
                if(TemporaryList[comboBoxFormat.ItemIndex].VID_W_AUD != null)
                    Console.WriteLine($"SELECTED ID: "+TemporaryList[comboBoxFormat.ItemIndex].VID_W_AUD);
                else Console.WriteLine($"SELECTED ID (AUDIO ONLY): "+TemporaryList[comboBoxFormat.ItemIndex].ID);
            }
        #endif

        // Gets the info before downloading
        #region Info Setup
        var _format = comboBoxFormat.MainText.Text ?? comboBoxFormat.GetItemContent; 
        TypeOfButton _type = TypeOfButton.CustomType;

        if(string.IsNullOrEmpty(_format)) _format = "Best";

        switch(comboBoxType.ItemIndex)
        {
            case 1: _type=TypeOfButton.AudioType; break;
            case 2: _type=TypeOfButton.VideoType; break;
        }
        #endregion

        YDLArguments Info = new()
        {
            Link = textBoxLink.Text,
            Format = _format,
            Type = _type
        };

        WindowsComponents.FreezeComponents();
    }

    public static void ButtonConvertClicked()
    {
        WindowsComponents.FreezeComponents();
    }
}