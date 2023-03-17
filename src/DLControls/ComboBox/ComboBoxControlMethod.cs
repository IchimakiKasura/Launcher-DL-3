namespace DLControls;

public partial class ComboBoxControl
{
    public List<ComboBoxItem> ComboBoxTypes = new() { new(),new(),new(),new() };
    
    #region Format ComboBox List
    public List<ComboBoxItem> ComboBoxAudioFormats = new()
    {
        new() { Content="mp3"  },
        new() { Content="m4a"  },
        new() { Content="mp4"  },
        new() { Content="wav"  },
        new() { Content="auto" },
    };
    public List<ComboBoxItem> ComboBoxVideoFormats = new()
    {
        new() { Content="mp4"  },
        new() { Content="mkv"  },
        new() { Content="webm" },
        new() { Content="flv"  },
        new() { Content="auto" },
    };
    public List<ComboBoxItem> ComboBoxConvertFormats = new()
    {
        new() { Content="mp4"  },
        new() { Content="mp3"  },
        new() { Content="flv"  },
        new() { Content="webm" },
        new() { Content="m4a"  },
        new() { Content="avi"  },
        new() { Content="wmv"  },
        new() { Content="wma"  },
        new() { Content="ogg"  },
        new() { Content="aac"  },
        new() { Content="wav"  },
    };
    public List<ComboBoxItem> ComboBoxFormatQuality = new()
    {
        new() { Content="Highest"	,	Uid="-crf 0  -preset slow	                 " },
        new() { Content="High"		,	Uid="-crf 10 -preset slow      -profile main " },
        new() { Content="Medium"	,	Uid="-crf 17 -preset slow      -profile main " },
        new() { Content="Normal"	,	Uid="-crf 23 -preset medium    -profile main " },
        new() { Content="Low"		,	Uid="-crf 30 -preset fast      -profile main " },
        new() { Content="Lowest"	,	Uid="-crf 45 -preset veryfast  -profile main " },
        new() { Content="Potato"	,	Uid="-crf 50 -preset ultrafast -profile main " },
    };
    #endregion

    public void ClearItems()                  => UserComboBox.Items.Clear();
    public void AddCustomTypeList()           => AutoAdd(0);
    public void AddAudioTypeList()            => AutoAdd(1);
    public void AddVideoTypeList()            => AutoAdd(2);
    public void AddConvertTypeList()          => AutoAdd(3);
    public void AddQualityTypeList()          => AutoAdd(4);
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
            case 4: temp = ComboBoxFormatQuality;	break;
        }

        foreach (var CBT in temp)
            UserComboBox.Items.Add(CBT);

        UserComboBox.SelectedIndex = x switch
        {
            int when x != 0 => 0,
            int when x == 4 => 3,
            _ => 0
        };
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