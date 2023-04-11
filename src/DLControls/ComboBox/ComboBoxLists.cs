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
    public FormatName(string pID, string pFORMAT, string pRESOLUTION, string pSIZE)
    {
        ID = pID;
        FORMAT = pFORMAT;
        RESOLUTION = pRESOLUTION;
        SIZE = pSIZE;
    }

    public string ID { get; }
    public string FORMAT { get; }
    public string RESOLUTION { get; }
    public string SIZE { get; }

    public string Name => $"[{ID}]   {FORMAT}   |   {RESOLUTION}   |   {SIZE}";
}

public enum TypeList
{
    CustomType ,
    VideoType  ,
    AudioType  ,
    ConvertType,
    QualityType
}

public sealed class ComboBoxList
{
    // I did ImmutableList instead of ComboBoxItem[] cuz ImmutableList said its thread safe
    // idk wtf am i doing.

    public readonly static ImmutableList<ComboBoxItem> ComboBoxTypes =
        ImmutableList.Create<ComboBoxItem>( new(),new(),new(),new() );

    public readonly static ImmutableList<ComboBoxItem> ComboBoxAudioFormats =
        ImmutableList.Create<ComboBoxItem>(
            new() { Content="mp3"  },
            new() { Content="m4a"  },
            new() { Content="mp4"  },
            new() { Content="wav"  }
        );

    public readonly static ImmutableList<ComboBoxItem> ComboBoxVideoFormats =
        ImmutableList.Create<ComboBoxItem>(
            new() { Content="mp4"  },
            new() { Content="mkv"  },
            new() { Content="webm" },
            new() { Content="flv"  }
        );

    public readonly static ImmutableList<ComboBoxItem> ComboBoxConvertFormats =
        ImmutableList.Create<ComboBoxItem>(
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
            new() { Content="wav"  }
        );

    public readonly static ImmutableList<ComboBoxItem> ComboBoxFormatQuality =
        ImmutableList.Create<ComboBoxItem>(
            new() { Content="Highest"   ,   Uid="-crf 0  -preset slow "         },
            new() { Content="High"      ,   Uid="-crf 10 -preset slow "         },
            new() { Content="Medium"    ,   Uid="-crf 17 -preset slow "         },
            new() { Content="Normal"    ,   Uid="-crf 23 -preset medium "       },
            new() { Content="Low"       ,   Uid="-crf 30 -preset fast "         },
            new() { Content="Lowest"    ,   Uid="-crf 45 -preset veryfast "     },
            new() { Content="Potato"    ,   Uid="-crf 50 -preset ultrafast "    }
        );
}