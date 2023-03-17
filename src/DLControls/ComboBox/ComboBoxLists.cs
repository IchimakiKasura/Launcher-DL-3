namespace DLControls;

public class FormatList
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
    string _ID,
           _FMT,
           _RES,
           _SIZE;

    public FormatName(string ID, string FMT, string RES, string SIZE)
    {
        _ID = ID;
        _FMT = FMT;
        _RES = RES;
        _SIZE = SIZE;
    }

    public string Name => $"[{_ID}]   {_FMT}   |   {_RES}   |   {_SIZE}";
}

public abstract class TypeList
{
    public const int CustomType  = 0,
                     VideoType   = 1,
                     AudioType   = 2,
                     ConvertType = 3,
                     QualityType = 4;
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
        new() { Content="auto" },
    };
    public static List<ComboBoxItem> ComboBoxVideoFormats = new()
    {
        new() { Content="mp4"  },
        new() { Content="mkv"  },
        new() { Content="webm" },
        new() { Content="flv"  },
        new() { Content="auto" },
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
        new() { Content="Highest"	,	Uid="-crf 0  -preset slow	                 " },
        new() { Content="High"		,	Uid="-crf 10 -preset slow      -profile main " },
        new() { Content="Medium"	,	Uid="-crf 17 -preset slow      -profile main " },
        new() { Content="Normal"	,	Uid="-crf 23 -preset medium    -profile main " },
        new() { Content="Low"		,	Uid="-crf 30 -preset fast      -profile main " },
        new() { Content="Lowest"	,	Uid="-crf 45 -preset veryfast  -profile main " },
        new() { Content="Potato"	,	Uid="-crf 50 -preset ultrafast -profile main " },
    };
}