namespace DLControls;

public partial class ComboBoxControl
{
    public List<ComboBoxItem> ComboBoxTypes = new List<ComboBoxItem>() { new(),new(),new(),new() };
    
    #region Format ComboBox List
    public List<ComboBoxItem> ComboBoxAudioFormats = new List<ComboBoxItem>()
    {
        new() { Content="mp3" },
        new() { Content="m4a" },
        new() { Content="mp4" },
        new() { Content="wav" },
        new() { Content="auto"},
    };
    public List<ComboBoxItem> ComboBoxVideoFormats = new List<ComboBoxItem>()
    {
        new() { Content="mp4" },
        new() { Content="mkv" },
        new() { Content="webm"},
        new() { Content="flv" },
        new() { Content="auto"},
    };
    public List<ComboBoxItem> ComboBoxConvertFormats = new List<ComboBoxItem>()
    {
        new() { Content="mp4" },
        new() { Content="mp3" },
        new() { Content="flv" },
        new() { Content="webm"},
        new() { Content="m4a" },
        new() { Content="avi" },
        new() { Content="wmv" },
        new() { Content="wma" },
        new() { Content="ogg" },
        new() { Content="aac" },
        new() { Content="wav" },
    };
    #endregion

    public void ClearItems()                  => UserComboBox.Items.Clear();
    public void AddCustomTypeList()           => AutoAdd(0);
    public void AddAudioTypeList()            => AutoAdd(1);
    public void AddVideoTypeList()            => AutoAdd(2);
    public void AddConvertTypeList()          => AutoAdd(3);
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
            case 0: temp = ComboBoxTypes;           break;
            case 1: temp = ComboBoxAudioFormats;    break;
            case 2: temp = ComboBoxVideoFormats;    break;
            case 3: temp = ComboBoxConvertFormats;  break;
        }

        foreach (var CBT in temp)
            UserComboBox.Items.Add(CBT);

        if(x != 0)
            UserComboBox.SelectedIndex = 0;
    }

    // Refresh the ComboBox content
    public void RefreshEditable()
    {
        if(!IsLoaded) return;

        MainText.Text = "";

        comboBoxGRID.Children.Remove(MainText);
        comboBoxGRID.Children.Remove(Placeholder);
        Contents.Visibility = Visibility.Visible;

        if (!TextEditable) return;
    
        comboBoxGRID.Children.Add(MainText);
        comboBoxGRID.Children.Add(Placeholder);
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