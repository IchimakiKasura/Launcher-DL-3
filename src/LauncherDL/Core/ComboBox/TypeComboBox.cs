namespace LauncherDL.Core.ComboBoxDL;

public class TypeComboBox
{
    public static void ItemChanged(object s, RoutedEventArgs e)
    {
        ConsoleOutputMethod.TypeChangedOutputComment();
        
        comboBoxFormat.ClearItems();

        if(comboBoxType.ItemIndex == 0)
            comboBoxFormatText(true);
        else  comboBoxFormatText(false);

        DownloadToConvert(comboBoxType.ItemIndex == 3);
        
        switch(comboBoxType.ItemIndex)
        {
            case 1: comboBoxFormat.AddVideoTypeList();      break;
            case 2: comboBoxFormat.AddAudioTypeList();      break;
            case 3: comboBoxFormat.AddConvertTypeList();    break;
        };
        
    }

    private static void DownloadToConvert(bool x)
    {
        buttonOpenFile.IsEnabled            = false;
        buttonDownload.Text                 = Language.Button_Download;
        textBoxLink.TextPlaceholder         = Language.Placeholder_Link;

        if(x)
        {
            buttonOpenFile.IsEnabled        = true;
            buttonDownload.Text             = Language.Button_Convert;
            textBoxLink.TextPlaceholder     = Language.Placeholder_File;
        }
    }

    private static void comboBoxFormatText(bool Editable)
    {
        comboBoxFormat.TextEditable         = Editable;
        comboBoxFormat.RefreshEditable();
    }
};