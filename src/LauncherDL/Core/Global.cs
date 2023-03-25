namespace LauncherDL.Core;

/// <summary>
/// Here lies where single variable can be shared to all.<br/>
/// and also long arrays or list are also here because 
/// it eats up all the space from the method.
/// </summary>
public partial class Global
{
    /// <summary>MainWindow but in <see langword="static"/></summary>
    [WindowStaticRef]
    public static MainWindow MainWindowStatic;
    /// <summary>MetadataWindow but in <see langword="static"/></summary>
    [WindowStaticRef]
    public static MetadataWindow MetadataWindowStatic;


    /// <summary>Config</summary>
    public static DefaultConfig config;

    /// <summary>shortcuts</summary>
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

}

public class ObjectListNames
{
    public string Title     { get; set; }
    public string Type      { get; set; }
    public string Name      { get; set; }
    public string Format    { get; set; }
    public string Link      { get; set; }
    public string Playlist  { get; set; }
}