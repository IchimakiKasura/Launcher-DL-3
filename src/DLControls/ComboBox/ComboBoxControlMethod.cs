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
        new() { Content="auto" },
    };
	public List<ComboBoxItem> ComboBoxVideoFormats = new List<ComboBoxItem>()
    {
        new() { Content="mp4" },
        new() { Content="mkv" },
        new() { Content="webm" },
        new() { Content="flv" },
        new() { Content="auto" },
    };
	public List<ComboBoxItem> ComboBoxConvertFormats = new List<ComboBoxItem>()
    {
        new() { Content="mp4" },
        new() { Content="mp3" },
        new() { Content="flv" },
        new() { Content="webm" },
        new() { Content="m4a" },
        new() { Content="avi" },
        new() { Content="wmv" },
        new() { Content="wma" },
        new() { Content="ogg" },
        new() { Content="aac" },
        new() { Content="wav" },
    };
    #endregion

    public void ClearItems() => UserComboBox.Items.Clear();

    // Adds Items to the ComboBoxList
	public void ItemsAdd()
	{
        ClearItems();

		foreach (var CBT in ComboBoxTypes)
		{
			CBT.Style = (Style)UserComboBox.FindResource("DownloadType");
			UserComboBox.Items.Add(CBT);
		}
	}


    public void AddAudioTypeList()      => AutoAdd(0);
    public void AddVideoTypeList()      => AutoAdd(1);
    public void AddConvertTypeList()    => AutoAdd(2);

    private void AutoAdd(int x)
    {
        ClearItems();
        var temp = new List<ComboBoxItem>();

        switch(x)
        {
            case 0: temp = ComboBoxAudioFormats;    break;
            case 1: temp = ComboBoxVideoFormats;    break;
            case 2: temp = ComboBoxConvertFormats;  break;
        }

        foreach (var CBT in temp)
			UserComboBox.Items.Add(CBT);

        UserComboBox.SelectedIndex = 0;
        Contents.HorizontalAlignment = HorizontalAlignment.Left;
        Contents.Content = UserComboBox.SelectionBoxItem;
    }

    // Refresh the ComboBox content
	public void RefreshEditable()
	{
		if(!IsLoaded) return;

        AddChildGRID(comboBoxGRID, true);
		Contents.Visibility = Visibility.Hidden;

		if (!TextEditable)
		{
			AddChildGRID(comboBoxGRID, false);
			Contents.Visibility = Visibility.Visible;
		}
	}
}