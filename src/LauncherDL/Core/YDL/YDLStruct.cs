namespace LauncherDL.Core.YTDLP;

ref struct YDLArguments
{
    public string Link { get; }
    public string Format { get; }
    public TypeOfButton Type { get; }

    public YDLArguments(string _Link = default, string _Format = default, TypeOfButton _Type = default)
    {
        Link = _Link;
        Format = _Format;
        Type = _Type;
    }
}