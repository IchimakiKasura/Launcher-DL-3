namespace LauncherDL.Core.YTDLP;

sealed partial class YDL
{
    string Link;
    string Format;
    TypeOfButton Type;

    public bool IsFileFormat { get; set; } = false;
    public bool IsUpdate { get; set; } = false;

    public YDL(YDLArguments args)
    {
        Link = args.Link;
        Format = args.Format;
        Type = args.Type;
    }
}

