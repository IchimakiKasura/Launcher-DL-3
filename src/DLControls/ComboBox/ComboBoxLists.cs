namespace DLControls;

public class FormatList : UIElement
{
    public string Name              { get; set; }
    public string ID                { get; set; }
    public string FORMAT            { get; set; }
    public string RESOLUTION        { get; set; }
    public string SIZE              { get; set; }
    public string BITRATE           { get; set; }
    public string FPS               { get; set; }
    public string VID_W_AUD         { get; set; }
}

public class FormatName
{
    public FormatName(string ID, string FMT, string RES, string SIZE)
    {
        Id = ID;
        Fmt = FMT;
        Res = RES;
        Size = SIZE;
    }

    public string Id { get; }
    public string Fmt { get; }
    public string Res { get; }
    public string Size { get; }

    public string Name => $"[{Id}]   {Fmt}   |   {Res}   |   {Size}";
}

public enum TypeList
{
    CustomType ,
    VideoType  ,
    AudioType  ,
    ConvertType,
    QualityType
}

public class ComboBoxList
{
    public static List<ComboBoxItem> ComboBoxTypes = new() { new(),new(),new(),new() };

    public static List<ComboBoxItem> ComboBoxAudioFormats = new()
    {
        new() { Content="mp3"  },
        new() { Content="m4a"  },
        new() { Content="mp4"  },
        new() { Content="wav"  },
    };
    public static List<ComboBoxItem> ComboBoxVideoFormats = new()
    {
        new() { Content="mp4"  },
        new() { Content="mkv"  },
        new() { Content="webm" },
        new() { Content="flv"  },
    };
    public static List<ComboBoxItem> ComboBoxConvertFormats = new()
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
    public static List<ComboBoxItem> ComboBoxFormatQuality = new()
    {
        new() { Content="Highest"	,	Uid="-crf 0  -preset slow "         },
        new() { Content="High"		,	Uid="-crf 10 -preset slow "         },
        new() { Content="Medium"	,	Uid="-crf 17 -preset slow "         },
        new() { Content="Normal"	,	Uid="-crf 23 -preset medium "       },
        new() { Content="Low"		,	Uid="-crf 30 -preset fast "         },
        new() { Content="Lowest"	,	Uid="-crf 45 -preset veryfast "     },
        new() { Content="Potato"	,	Uid="-crf 50 -preset ultrafast "    },
    };
}