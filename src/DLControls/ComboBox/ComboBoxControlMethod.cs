namespace DLControls;

public partial class ComboBoxControl
{    
    public void ClearItems()                  => UserComboBox.Items.Clear();
    public void AddCustomTypeList()           => AutoAdd(TypeList.CustomType );
    public void AddVideoTypeList()            => AutoAdd(TypeList.VideoType  );
    public void AddAudioTypeList()            => AutoAdd(TypeList.AudioType  );
    public void AddConvertTypeList()          => AutoAdd(TypeList.ConvertType);
    public void AddQualityTypeList()          => AutoAdd(TypeList.QualityType);
    public void AddFormatList(List<FormatList> FormatListArgs)
    {
        if(!TextEditable) return;
        
        foreach (var CBT in FormatListArgs)
            UserComboBox.Items.Add(CBT);
    }

    private void AutoAdd(int x)
    {
        ClearItems();
        List<ComboBoxItem> temp = new();
        
        switch(x)
        {
            case 0: temp = ComboBoxList.ComboBoxTypes;           break;
            case 1: temp = ComboBoxList.ComboBoxVideoFormats;    break;
            case 2: temp = ComboBoxList.ComboBoxAudioFormats;    break;
            case 3: temp = ComboBoxList.ComboBoxConvertFormats;  break;
            case 4: temp = ComboBoxList.ComboBoxFormatQuality;	break;
        }

        foreach (var CBT in temp)
            UserComboBox.Items.Add(CBT);

        UserComboBox.SelectedIndex = x switch
        {
            // ☠️☠️
            int when x is not 0 => 0,
            int when x is     4 => 3,
            _ => 0
        };
    }

    // Refresh the ComboBox content
    public void RefreshEditable()
    {
        if(!IsLoaded) return;

        MainText.Text = "";

        ComboBoxTemplateGRID.Remove(MainText);
        ComboBoxTemplateGRID.Remove(Placeholder);
        Contents.Visibility = Visibility.Visible;

        if (!TextEditable) return;
    
        ComboBoxTemplateGRID.Add(MainText);
        ComboBoxTemplateGRID.Add(Placeholder);
        Contents.Visibility = Visibility.Hidden;
    }

    public void SetFormatListStyle(bool clear)
    {
        UserComboBox.ItemContainerStyle = (Style)UserComboBox.FindResource("FormatListType");
        if(clear)UserComboBox.ItemContainerStyle = default;
    }

    public void ResetBox()
    {
        if(!TextEditable) return;

        MainText.Text = "";
        ItemIndex = -1;
        ClearItems();
    }
}