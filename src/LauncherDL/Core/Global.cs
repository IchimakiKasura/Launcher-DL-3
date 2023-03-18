﻿namespace LauncherDL.Core;

/// <summary>
/// Here lies where single variable can be shared to all.<br/>
/// and also long arrays or list are also here because 
/// it eats up all the space from the method.
/// </summary>
public partial class Global
{
    /// <summary>MainWindow but in <see langword="static"/></summary>
    public static MainWindow MainWindowStatic;
    public static MetadataWindow MetadataWindowStatic;

    /// <summary>Config</summary>
    public static DefaultConfig config;

    /// <summary>ColorConverter shortcut</summary>
    public static Func<string, Color> ClrConv = (string color) => (Color)ColorConverter.ConvertFromString(color);

    /// <summary>Languages</summary>
    public static DLLanguages.Pick.LanguagePick Language;
    
    /// <summary>for Renaming Process</summary>
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

    public readonly static string YDL_Path = $"{Directory.GetCurrentDirectory()}\\LauncherDL_Data\\ydl.bin"; 
    public readonly static string FFMPEG_Path = $"{Directory.GetCurrentDirectory()}\\LauncherDL_Data\\ffmpeg.exe"; 

    /// <summary>ProgressBar State</summary>
    public enum ProgressBarState{Hide,Show}

    /// <summary>Process Start</summary>
    public static Process ProcessTaskVariable;

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

}

