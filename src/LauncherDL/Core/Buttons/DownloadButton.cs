namespace LauncherDL.Core.Buttons;

public class DownloadButton : ConvertButton
{
    public static void ButtonClicked(object s, RoutedEventArgs e)
    {
        e.Handled = true;

        // Checks if the button is set to Convert
        if(comboBoxType.ItemIndex is not 3) 
        {
            ButtonConvertClicked();
            return;
        }
        
        if(!BodyButton.CheckLinkValidation(true))
            return;

        // Checks if "-o" on format exist because its an output argument on ytdlp
		if (comboBoxFormat.MainText.Text.Contains("-o"))
		{
			MessageBox.Show("The \"-o\" is reserved, Instead change the \"output\" on the Config.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
			console.DLAddConsole(CONSOLE_ERROR_SOFT_STRING, "The \"-o\" is reserved, Instead change the \"output\" on the Config.");
			return;
		}

        // To be removed
        #if DEBUG
            if(comboBoxFormat.ItemIndex > -1)
            {
                if(TemporaryList[comboBoxFormat.ItemIndex].VID_W_AUD != null)
                    ConsoleDebug.Log($"SELECTED ID: "+TemporaryList[comboBoxFormat.ItemIndex].VID_W_AUD);
                else ConsoleDebug.Log($"SELECTED ID (AUDIO ONLY): "+TemporaryList[comboBoxFormat.ItemIndex].ID);
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
}