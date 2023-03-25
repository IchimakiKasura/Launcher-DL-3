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

        // Gets the info before downloading
        #region Info Setup

        string _format = "b"; // b as it Best
        string _FormatOutputComment  = "Best";

        switch(_format)
        {
            // Checks if has file format fetched
            case string when comboBoxType.ItemIndex is 0 && comboBoxFormat.HasItems && comboBoxFormat.ItemIndex > 0:
                _format = TemporaryList[comboBoxFormat.ItemIndex].VID_W_AUD ?? TemporaryList[comboBoxFormat.ItemIndex].ID;
                _FormatOutputComment = TemporaryList[comboBoxFormat.ItemIndex].Name;

                // Checks if format text is changed by the user manually
                if(comboBoxFormat.Text != TemporaryList[comboBoxFormat.ItemIndex].Name)
                    _FormatOutputComment =
                    _format = comboBoxFormat.Text;
            break;

            // If its not on Custom Type
            case string when comboBoxType.ItemIndex is not 0:
                _FormatOutputComment =
                _format = comboBoxFormat.GetItemContent;
            break;
        };

        TypeOfButton _type;

        switch(comboBoxType.ItemIndex)
        {
            default: _type=TypeOfButton.CustomType; break;
            case 1:  _type=TypeOfButton.VideoType;  break;
            case 2:  _type=TypeOfButton.AudioType;  break;
        }
        #endregion

        YDLArguments Info = new()
        {
            Link = textBoxLink.Text,
            Format = _format,
            Type = _type
        };

        // yeah i don't know either that I put N/A on some that is "un-unassignable" ☠️
        ConsoleOutputMethod.DownloadInfoOutputComment(new()
        {
            Title = textBoxName.Text ?? "N/A",
            Type = comboBoxType.GetItemContent ?? "N/A",
            Name = textBoxName.Text ?? "N/A",
            Format = _FormatOutputComment.Replace("|", "$vbar$") ?? "N/A",
            Link = textBoxLink.Text ?? "N/A",
            Playlist = config.EnablePlaylist.ToString() ?? "N/A"
        });

        YDL YDLInfo = new(Info);

        YDLInfo.DownloadMethod();
        
        WindowsComponents.FreezeComponents();
    }
}