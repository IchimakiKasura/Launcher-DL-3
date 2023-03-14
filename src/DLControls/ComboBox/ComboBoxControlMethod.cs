using System.Net.Mime;
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

    public void ClearItems()                  => UserComboBox.Items.Clear();
    public void AddCustomTypeList()           => AutoAdd(0);
    public void AddAudioTypeList()            => AutoAdd(1);
    public void AddVideoTypeList()            => AutoAdd(2);
    public void AddConvertTypeList()          => AutoAdd(3);

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
        {
            UserComboBox.ItemContainerStyle = default;
            UserComboBox.SelectedIndex = 0;
        }
    }

    // WORK IN PROGRESS
    // CHECK THE TODO OM MAINWINDOW.XAML.CS FOR MORE INFO
    #if DEBUG
        public void AddFormatList()
        {
            dynamic TestCustom = new
            {
                Name="ass",
                ID="1",
                FORMAT="mp4",
                RESOLUTION="1920x1080",
                SIZE="200mb",
                BITRATE="20319kb",
                FPS="999",
            };
            dynamic TestCustoms = new
            {
                Name="wtf",
                ID="1",
                FORMAT="mp4",
                RESOLUTION="1920x1080",
                SIZE="200mb",
                BITRATE="20319kb",
                FPS="999",
            };
            
            DataTemplate DT = new();

            FrameworkElementFactory TB = new(typeof(TextBlock));
            TB.SetBinding(TextBlock.TextProperty, new System.Windows.Data.Binding("Name"));
            DT.VisualTree = TB;

            UserComboBox.ItemTemplate = DT;
            UserComboBox.ItemContainerStyle = (Style)UserComboBox.FindResource("FormatListType");
            UserComboBox.Items.Add(TestCustom);
            UserComboBox.Items.Add(TestCustoms);
        }
    #endif


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