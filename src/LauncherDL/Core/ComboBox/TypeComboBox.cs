namespace LauncherDL.Core.ComboBoxDL;

public sealed class TypeComboBox : IComboBoxControl
{
    public static void ItemChanged(object s, RoutedEventArgs e)
    {
        ConsoleOutputMethod.ComboBoxChangedOutputComment(ConsoleOutputMethodSelection.TYPE);
        
        comboBoxFormat.ClearItems();
        buttonMetadata.IsEnabled = true;

        if(comboBoxType.ItemIndex is 0)
        {
            buttonFileFormat.IsEnabled = true;

            if(TemporaryList.Count > 0)
                comboBoxFormat.AddFormatList(TemporaryList);

            comboBoxFormatText(true);

            buttonDownload.UICanvas.MouseMove += (s,e) => ToolTipTextsAttribute.Follow(s,e, "Download");
        }
        else
        {
            buttonFileFormat.IsEnabled = false;
            comboBoxFormatText(false);
        }

        // Resets cbf width
        comboBoxFormat.Width = 440;
        windowCanvas.Remove(comboBoxQuality);

        DownloadToConvert(comboBoxType.ItemIndex is 3);

        switch (comboBoxType.ItemIndex)
        {
            case 1: comboBoxFormat.AddVideoTypeList();      break;
            case 2: comboBoxFormat.AddAudioTypeList();      break;
            case 3:
                //adjust cbf width for quality cb
                comboBoxFormat.Width = 228;
                windowCanvas.Add(comboBoxQuality);
                comboBoxFormat.AddConvertTypeList();
                buttonDownload.UICanvas.MouseMove += (s,e) => ToolTipTextsAttribute.Follow(s,e, "Convert");
                buttonMetadata.IsEnabled = false;
            break;
        };
        
    }

    private static void DownloadToConvert(bool x)
    {
        buttonOpenFile.IsEnabled            = false;
        buttonDownload.Text                 = Language.Button_Download;
        textBoxLink.TextPlaceholder         = Language.Placeholder_Link;
        textBlockLink.Text                  = Language.Label_Link;

        if(!x) return;
        
        buttonOpenFile.IsEnabled            = true;
        buttonDownload.Text                 = Language.Button_Convert;
        textBoxLink.TextPlaceholder         = Language.Placeholder_File;
        textBlockLink.Text                  = Language.Label_File;
    }

    private static void comboBoxFormatText(bool Editable)
    {
        comboBoxFormat.TextEditable         = Editable;
        comboBoxFormat.RefreshEditable();
        comboBoxFormat.SetFormatListStyle(Editable);
    }
};