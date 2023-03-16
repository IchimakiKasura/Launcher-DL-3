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
};

public class FormatName
{
    string _ID;
    string _FMT;
    string _RES;
    string _SIZE;

    public FormatName(string ID, string FMT, string RES, string SIZE)
    {
        _ID = ID;
        _FMT = FMT;
        _RES = RES;
        _SIZE = SIZE;
    }

    public string Name => $"[{_ID}]   {_FMT}   |   {_RES}   |   {_SIZE}";
}