﻿namespace LauncherDL.Core;

/// <summary>
/// Here lies where single variable can be shared to all.<br/>
/// and also long arrays or list are also here because 
/// it eats up all the space from the method.
/// </summary>
public partial class Global
{
    // App version
    public const string APP_CURRENT_VERION = "7.0_DT3.29.2023";

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
    "Launcher DL Version 7 (7th Generation DL)\n\n"         +
    "[New!]\n"                                              +
    "- NEW UI\n"                                            +
    "- Improved Perfomance\n"                               +
    "- Code Refactored\n\n"                                 +
    "[New Features | Removed Features]\n"                   +
    "- Open file button has its own dedicated button.\n"    +
    "- Metadata button for Video/Audio Types!\n"            +
    "- Convert has now Quality options.\n"                  +
    "- Added more Console comments!\n"                      +
    "- Uses ARIA2C as downloader for faster download\n"     +
    "- REMOVED Playlist feature.\n"                         +
    "\n\n"                                                  +
    "[Fixes]\n"                                             +
    "- FIXED \'Cannot reenter Text Formatting engine\n"     +
    "During Optimal paragraph formatting\'\n"               +
    "- FIXED Text go beyond the button's width\n"           ;
    #endregion

}

public class ObjectListNames
{
    public string Title     { get; set; }
    public string Type      { get; set; }
    public string Name      { get; set; }
    public string Format    { get; set; }
    public string Link      { get; set; }
}