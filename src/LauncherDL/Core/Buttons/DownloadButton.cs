namespace LauncherDL.Core.Buttons;

public class DownloadButton : ConvertButton
{
    public static async void ButtonClicked(object s, RoutedEventArgs e)
    {
        e.Handled = true;

        // Checks if the button is set to Convert
        if(comboBoxType.ItemIndex is 3) 
        {
            ButtonConvertClicked();
            return;
        }
        
        if(!await BodyButton.CheckLinkValidation())
            return;

        // Checks if "-o" on format exist because its an output argument on ytdlp
		if (comboBoxFormat.Text.Contains("-o"))
		{
			MessageBox.Show("The \"-o\" is reserved, Instead change the \"output\" on the Config.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
			console.DLAddConsole(CONSOLE_ERROR_SOFT_STRING, "The \"-o\" is reserved, Instead change the \"output\" on the Config.");
			return;
		}

        // Check if Format text has been changed after selecting an item
        // or File format was fired and haven't selected an item yet.
        if(comboBoxFormat.HasItems && comboBoxFormat.ItemIndex > 0)
        {
            if(TemporaryList[comboBoxFormat.ItemIndex].Name == comboBoxFormat.Text)
                Console.WriteLine("Match");
            else Console.WriteLine("Not Match");
        }

        // Gets the info before downloading
        #region Info Setup
        var _format = comboBoxFormat.Text ?? comboBoxFormat.GetItemContent; 
        TypeOfButton _type = TypeOfButton.CustomType;

        if(_format.IsEmpty()) _format = "Best";

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