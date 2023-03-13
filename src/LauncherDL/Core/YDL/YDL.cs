namespace LauncherDL.Core.YTDLP;

enum TypeOfButton
{
    CustomType,
    AudioType,
    VideoType,
    ConvertType
}

sealed class YDLArguments
{
    public string Link { get; set; }
    public string Format { get; set; }
    public TypeOfButton Type { get; set; }
}

sealed partial class YDL
{
    string Link;
    string Format;
    TypeOfButton Type;

    public bool IsFileFormat = false;
    public bool IsUpdate = false;

    public YDL(YDLArguments args)
    {
        Link = args.Link;
        Format = args.Format;
        Type = args.Type;
    }

    public void ValidateLink()
    {

    }
}

