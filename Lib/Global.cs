namespace Launcher_DL.Lib;

partial class Global
{
    /// <summary>
    /// MainWindow but in <see langword="static"/>
    /// </summary>
    public static MainWindow MainWindowStatic;

    /// <summary>App current Version</summary>
    public const string AppVersion = "Build Version:\nDevelopment Build";


    /// <summary><see langword="ydl.bin"/> Location</summary>
    public readonly static string YDL_link = $"{Directory.GetCurrentDirectory()}\\LauncherDL_Data\\ydl.bin";


    /// <summary><see langword="ffmpeg"/> Location</summary>
    public readonly static string Ffmpeg = $"{Directory.GetCurrentDirectory()}\\LauncherDL_Data";


    /// <summary><see langword="Config.kasu"/> Location</summary>
    public const string KasuConfigName = "Config.kasu";


    /// <summary><see langword="LanguagePack.kasu"/> Location</summary>
    public const string KasuLangName = "LanguagePack.kasu";

    #region File Formats
    /// <summary>for Renaming Process</summary>
    public static List<string> ext = new() { "mp4", "mkv", "webm", "mp3", "m4a", "3gp", "flv" };
    /// <summary>Video Type Formats</summary>
    public static List<string> VideoType = new() { "mp4", "mkv", "webm", "flv", "auto" };
    /// <summary>Audio Type Formats</summary>
    public static List<string> AudioType = new() { "mp3", "webm", "m4a", "mp4", "auto" };
    /// <summary>Convert Type Formats</summary>
    public static List<string> ConvertType = new() { "mp4", "mp3", "flv", "webm", "m4a", "mkv", "avi", "wmv", "wma", "ogg", "aac", "wav" };
    #endregion

    /// <summary>Hidden Button | Release notes</summary>
    public const string HiddenButtonText = "LauncherDL Development Build\n\n" +
        "[New Features]\n" +
        "- New \"Convert\" type! Now you can now\nConvert videos or audios into another format.\n" +
        "- Format option is fully redesigned/reworked.\n" +
        "- App will now open in a single instance.\n" +
        "- New Added Taskbar Flashing / Progress bar.\n" +
        "- Format ID/Code are now showing.\n" +
        "- Console outputs more info now and saves a Log on exit!\n\n" +
        "[Fixes]\n" +
        "- Choosing Audio Type will not download to its correct location.\n" +
        "- Fixed where closing the application will actually close even the\npop-up message stops you from closing it.\n" +
        "- Fixed where all the context menu are from right to left are now left to right.\n" +
        "- Textbox's focus are now fixed when clicking away from it." +
        "- Fixed where fonts doesn't actually renders even though its embedded to the resource.\n" +
        "Created by Kasura.";


    /// <summary>Config</summary>
    public static LauncherDefaultConfig Config = new();

    /// <summary>Download / Update / File Format / Convert</summary>
    public static Process Proc;


    /// <summary>Window focus animations</summary>
    public static DoubleAnimation Opac;
    public static ColorAnimation Anim;


    #region Temporary Vairables
    /// <summary>Temporary variables</summary>
    public static string TemporaryEncodedName = string.Empty;
    /// <summary>Temporary variables</summary>
    public static List<string> TemporaryFormatNames = new();
    /// <summary>Temporary variables</summary>
    public static string temp = string.Empty;
    /// <summary>Temporary variables</summary>
    public static string TemporarySelectedFileFormat = string.Empty;
    /// <summary>Temporary variables</summary>
    public static List<string> TemporaryFormatList = new();
    #endregion


    #region others
    /// <summary>Checks if the app is currently downloading</summary>
    public static bool IsDownloading = false;
    /// <summary><see langword="Output_text"/> temporary text place</summary>
    public static MemoryStream DocumentTemp;
    /// <summary>Checks if app is used to produce a Log file</summary>
    public static bool IsAppUsed = false;
    /// <summary>Cancel ongoing task</summary>
    public static CancellationTokenSource CancelWork;
    public static string CurrentLinkTitle;
    public static Func<string, Color> ClrConv = (string color) => (Color)ColorConverter.ConvertFromString(color);
    #endregion


    #region Window Flash
    [DllImport("user32.dll", CallingConvention = CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool FlashWindowEx(ref FLASHWINFO pwfi);
    public const uint FLASHW_ALL = 3;
    public const uint FLASHW_TIMERNOFG = 12;
    [StructLayout(LayoutKind.Sequential)]
    /// <summary>Window Flashing</summary>
    public struct FLASHWINFO
    {
        public uint cbSize;
        public IntPtr hwnd;
        public uint dwFlags;
        public uint uCount;
        public uint dwTimeout;
    }
    #endregion

    #region ContextMenuClearText
    public static bool IsLink;
    public static bool IsName;
    public static bool IsFormat;
    #endregion

}