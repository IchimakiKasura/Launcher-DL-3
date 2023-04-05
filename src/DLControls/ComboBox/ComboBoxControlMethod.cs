namespace DLControls;

public partial class ComboBoxControl
{    
    public void ClearItems()                  => UserComboBox.Items.Clear();
    public void AddCustomTypeList()           => AutoAdd(TypeList.CustomType );
    public void AddVideoTypeList()            => AutoAdd(TypeList.VideoType  );
    public void AddAudioTypeList()            => AutoAdd(TypeList.AudioType  );
    public void AddConvertTypeList()          => AutoAdd(TypeList.ConvertType);
    public void AddQualityTypeList()          => AutoAdd(TypeList.QualityType);
    public void AddFormatList(in List<FormatList> FormatListArgs)
    {
        foreach (var CBT in FormatListArgs)
            UserComboBox.Items.Add(CBT);
    }

    private void AutoAdd(TypeList x)
    {
        ClearItems();
        ImmutableList<ComboBoxItem> temp = ImmutableList<ComboBoxItem>.Empty;
        
        switch(x)
        {
            case TypeList.CustomType    : temp = ComboBoxList.ComboBoxTypes;           break;
            case TypeList.VideoType     : temp = ComboBoxList.ComboBoxVideoFormats;    break;
            case TypeList.AudioType     : temp = ComboBoxList.ComboBoxAudioFormats;    break;
            case TypeList.ConvertType   : temp = ComboBoxList.ComboBoxConvertFormats;  break;
            case TypeList.QualityType   : temp = ComboBoxList.ComboBoxFormatQuality;   break;
        }

        foreach (var CBT in temp)
            UserComboBox.Items.Add(CBT);

        UserComboBox.SelectedIndex = x switch
        {
            TypeList.QualityType => 3,
            _ => 0
        };
    }

    // Refresh the ComboBox content
    public void RefreshEditable()
    {
        if(!IsLoaded) return;

        MainText.Text = string.Empty;

        ComboBoxTemplateGRID.Remove(MainText);
        ComboBoxTemplateGRID.Remove(Placeholder);
        Contents.Visibility = Visibility.Visible;

        if (!TextEditable) return;
    
        ComboBoxTemplateGRID.Add(MainText);
        ComboBoxTemplateGRID.Add(Placeholder);
        Contents.Visibility = Visibility.Hidden;
    }

    public void SetFormatListStyle(in bool clear)
    {
        UserComboBox.ItemContainerStyle = (Style)UserComboBox.FindResource("FormatListType");
        if(!clear)UserComboBox.ItemContainerStyle = default;
    }

    public void ResetBox()
    {
        if(!TextEditable) return;

        MainText.Text = string.Empty;
        ItemIndex = -1;
        ClearItems();
    }
}