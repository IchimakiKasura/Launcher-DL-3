namespace LauncherDL.Core.ComboBoxDL;

public class TypeComboBox
{
    public static void ItemChanged(object s, RoutedEventArgs e)
    {
        ConsoleOutputMethod.TypeChangedOutputComment();
        
        comboBoxFormat.ClearItems();

        if(comboBoxType.ItemIndex == 0)
        {
            buttonFileFormat.IsEnabled = true;
            if(TemporaryList.Count > 0)
                comboBoxFormat.AddFormatList(TemporaryList);
            comboBoxFormatText(true);
        }
        else
        {
            buttonFileFormat.IsEnabled = false;
            comboBoxFormatText(false);
        }

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
        textBlockLink.Text                  = Language.Label_Link;

        if(!x) return;
        
        buttonOpenFile.IsEnabled        = true;
        buttonDownload.Text             = Language.Button_Convert;
        textBoxLink.TextPlaceholder     = Language.Placeholder_File;
        textBlockLink.Text              = Language.Label_File;
    }

    private static void comboBoxFormatText(bool Editable)
    {
        comboBoxFormat.TextEditable         = Editable;
        comboBoxFormat.RefreshEditable();
        comboBoxFormat.SetFormatListStyle(!Editable);
    }
};