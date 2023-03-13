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

sealed class YDL
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

    public async void UpdateMethod()
    {
        if (!IsUpdate)
            throw new UpdateMethodException();

        var Args = "-U";

        await TaskProcess.StartProcess.ProcessTask(Args, ConsoleLive.UpdateLiveOutputComment);
        WindowsComponents.FreezeComponents();
    }

    public async void FileFormatMethod()
    {
        if (!IsFileFormat)
            throw new FileFormatMethodException();

        var Args = $"--compat-options format-sort -F {Link}";

        if (!config.EnablePlaylist) Args += " --no-playlist";
        if (config.AllowCookies) Args += $" --cookies-from-browser {config.BrowserCookie}";

        await TaskProcess.StartProcess.ProcessTask(Args, ConsoleLive.FileFormatLiveOutputComment);
    }

    public async void DownloadMethod()
    {
        if (IsUpdate || IsFileFormat)
            throw new DownloadMethodException();

        var Args = Format;

    }

    public async void ConvertMethod()
    {
        if (IsUpdate || IsFileFormat)
            throw new ConvertMethodException();

        var Args = Format;

    }
}

