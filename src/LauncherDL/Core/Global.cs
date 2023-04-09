namespace LauncherDL.Core;

/// <summary>
/// Here lies where single variable can be shared to all.<br/>
/// and also long arrays or list are also here because 
/// it eats up all the space from the method.
/// </summary>
public sealed partial class Global
{
    // App version
    #if !DEBUG
        public const string APP_CURRENT_VERSION = "7.1_DT0.0.0000";
    #else
        public const string APP_CURRENT_VERSION = "Development Build";
    #endif

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
    public static T GetResources<T>(string Name) => (T)MainWindowStatic.FindResource(Name);
    public static Color ClrConv(string color) => (Color)ColorConverter.ConvertFromString(color);
    public static Brush BrhConv(string color) => (Brush)new BrushConverter().ConvertFromString(color);
    public static void SetCanvas(UIElement Element, double Top, double Left)
    {
        Canvas.SetTop(Element, Top);
        Canvas.SetLeft(Element, Left);
    }

    /// <summary>Languages</summary>
    public static DLLanguages.Pick.Interface.ILanguagePick Language;
    
    public static readonly ImmutableArray<string> FileExtensions = ImmutableArray.Create(
        "mp4",
        "mkv",
        "webm",
        "mp3",
        "m4a",
        "3gp",
        "flv"
    );

    /// <summary>ComboBoxFormat Temporary list</summary>
    public static List<FormatList> TemporaryList = new();

    public static MemoryStream ConsoleLastDocument;

    /// <summary>Process Start</summary>
    public static Process ProcessTaskVariable;

    #region Path variables
    [FilePath("ydl.bin")]
    public static string YDL_Path;
    [FilePath("ffmpeg.exe")]
    public static string FFMPEG_Path;
    [FilePath("aria2c.exe")]
    public static string ARIA2C_Path;
    #endregion

    #region Window Flash
    [DllImport("user32.dll")]
    public static extern bool FlashWindowEx(ref FLASHWINFO pwfi);
    public const uint FLASHW_ALL = 3;
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
    public const string hidden = """
    Launcher DL Version 7.1 (7th Generation DL)

    [ Fixes ]
    - Fixed where BackgroundGlow and Image are not setting
        up correctly as it is.
    - Fixed where Textbox needing 2 tab presses
        before actually typing on it.
    - ComboBo'x textbox also need 2 tab presses when its
        on TextEditable state.
    - Fixed where Download on Custom types with fetched
        Formats other sites other than youtube.
    - Fixed where Download on Twitter throws random error
        because of api but it doesn't affect the 
        downloaded file.
    - Fixed where ID is going past the limit on ComboBox
        now has an "..." when it has more than 8 chars.

    [ New ]
    - OpenFile context menu will have disabled buttons
        if the folder doesn't exist.
    - Metadata is now available on CustomType!
    - Added few Animations.

    [ Misc ]
    - Window is now continuously updating to hit the 60fps
        target and remove button stuttering animations.
            (Only when window is focused!)
    """;
    #endregion

}

public ref struct ObjectListNames
{
    public string Title     { get; set; }
    public string Type      { get; set; }
    public string Name      { get; set; }
    public string Format    { get; set; }
    public string Link      { get; set; }
}