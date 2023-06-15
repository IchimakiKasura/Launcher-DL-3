namespace LauncherDL.Core.Buttons;

internal sealed class DownloadButton : IButtonControls
{
    public static async void ButtonClicked(object s, RoutedEventArgs e)
    {
        e.Handled = true;

        // Checks if the button is set to Convert
        if(comboBoxType.ItemIndex is 3) 
        {
            ConvertButton.ButtonClicked(s,e);
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
            case string when comboBoxType.ItemIndex is 0 && comboBoxFormat.HasItems && comboBoxFormat.ItemIndex > -1:

                var SelectedFormat = TemporaryList[comboBoxFormat.ItemIndex];
                _format = SelectedFormat.VID_W_AUD ?? SelectedFormat.ID;
                _FormatOutputComment = SelectedFormat.Name;

                // Checks if format text is changed by the user manually
                if(comboBoxFormat.Text != SelectedFormat.Name)
                    _FormatOutputComment =
                    _format = comboBoxFormat.Text;
            break;

            // If its not on Custom Type
            case string when comboBoxType.ItemIndex is not 0:
                _FormatOutputComment =
                _format = comboBoxFormat.GetItemContent;
            break;
        };
        
        var _type = comboBoxType.ItemIndex switch
        {
            1 => TypeOfButton.VideoType,
            2 => TypeOfButton.AudioType,
            _ => TypeOfButton.CustomType,
        };

        #endregion
        // yeah i don't know either that I put N/A on some that is "un-unassignable" ☠️
        console.Break("Gray");
        ConsoleOutputMethod.DownloadInfoOutputComment(new()
        {
            Title = BodyButton.ValidationActualTitle ?? "N/A",
            Type = comboBoxType.GetItemContent ?? "N/A",
            Name = textBoxName.Text ?? "N/A",
            Format = _FormatOutputComment.Replace("|", "$vbar$") ?? "N/A",
            Link = textBoxLink.Text ?? "N/A",
        });
        console.Break("Gray");

        YDL YDLInfo = new(
            new(
                Link: textBoxLink.Text,
                Format: _format,
                Type: _type
            )
        );

        YDLInfo.DownloadMethod();

        WindowsComponents.FreezeComponents();
    }
}