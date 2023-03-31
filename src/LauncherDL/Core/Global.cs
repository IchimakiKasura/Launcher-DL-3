namespace LauncherDL.Core;

/// <summary>
/// Here lies where single variable can be shared to all.<br/>
/// and also long arrays or list are also here because 
/// it eats up all the space from the method.
/// </summary>
public partial class Global
{
    // App version
    public const string APP_CURRENT_VERION = "7.1_DT0.0.0000";

    /// <summary>MainWindow but in <see langword="static"/></summary>
    [WindowStaticRef]
    public static MainWindow MainWindowStatic;
    /// <summary>MetadataWindow but in <see langword="static"/></summary>
    [WindowStaticRef]
    public static MetadataWindow MetadataWindowStatic;

    // Prevents app from closing when downloading
    public static bool IsInProcess = false;

    /// <summary>Config</summary>
    public static DefaultConfig config;

    /// shortcuts
    public static Color ClrConv(string color) => (Color)ColorConverter.ConvertFromString(color);
    public static Brush BrhConv(string color) => (Brush)new BrushConverter().ConvertFromString(color);
    public static void SetCanvas(UIElement Element, double Top, double Left)
    {
        Canvas.SetTop(Element, Top);
        Canvas.SetLeft(Element, Left);
    }

    /// <summary>Languages</summary>
    public static DLLanguages.Pick.LanguagePick Language;
    
    public static List<string> FileExtensions = new()
    {
        "mp4",
        "mkv",
        "webm",
        "mp3",
        "m4a",
        "3gp",
        "flv"
    };

    /// <summary>ComboBoxFormat Temporary list</summary>
    public static List<FormatList> TemporaryList = new();
    public static MemoryStream ConsoleLastDocument;

    /// <summary>Process Start</summary>
    public static Process ProcessTaskVariable;

    #region Path variables
    public readonly static string YDL_Path = $"{Directory.GetCurrentDirectory()}\\LauncherDL_Data\\ydl.bin"; 
    public readonly static string FFMPEG_Path = $"{Directory.GetCurrentDirectory()}\\LauncherDL_Data\\ffmpeg.exe";
    public readonly static string ARIA2C_Path = $"{Directory.GetCurrentDirectory()}\\LauncherDL_Data\\aria2c.exe";
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

    #region Metadata
    public static string
    Old_Title,
    Old_Album,
    Old_Album_Artist,
    Old_Year,
    Old_Genre;
    #endregion

    #region HUZUAAH!
    public const string hidden =
    "Launcher DL Version 7.1 (7th Generation DL)\n\n"         +
    "[ Fixes ]\n"                                             +
    "- Fixed where BackgroundGlow and Image are not setting\n"+
    "up correctly as it is.\n"                                + 
    "- Fixed where Textbox needing 2 tab presses\n"           +
    "before actually typing on it.\n"                         +
    "- ComboBo'x textbox also need 2 tab presses when its\n"  +
    "on TextEditable state.\n"                                +
    "- Fixed where Download on Custom types with fetched\n"   +
    "Formats other sites other than youtube.\n"               +
    "- Fixed where Download on Twitter throws random error\n" +
    "because of api but it doesn't affect\n"                  +
    "the downloaded file.\n"                                  +
    "- Fixed where ID is going past the limit on ComboBox\n"  +
    "now has an \"...\" when it has more than 8 chars\n\n"    +
    "[ New ]\n"+
    "- Open file context menu will have disabled buttons\n"   +
    "if the folder doesn't exist.";
    #endregion

}

public struct ObjectListNames
{
    public string Title     { get; set; }
    public string Type      { get; set; }
    public string Name      { get; set; }
    public string Format    { get; set; }
    public string Link      { get; set; }
}