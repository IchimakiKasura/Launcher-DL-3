global using System;
global using System.IO;
global using System.Text;
global using System.Windows;
global using Microsoft.Win32;
global using System.Reflection;
global using System.Diagnostics;
global using System.Windows.Input;
global using System.Windows.Media;
global using System.ComponentModel;
global using System.Windows.Interop;
global using System.Threading.Tasks;
global using System.Windows.Controls;
global using System.Windows.Threading;
global using System.Windows.Documents;
global using System.Collections.Generic;
global using System.Windows.Media.Imaging;
global using System.Runtime.InteropServices;
global using System.Text.RegularExpressions;
global using System.Windows.Media.Animation;

namespace Launcher_DL_v6;
// Variables for MainWindow
public partial class MainWindow
{
    public static MainWindow MW;

    // Version
    readonly string Version = "Build Version:\nDevelopment Build";

    // ydl.bin location
    public readonly static string YDL_link = $"{Directory.GetCurrentDirectory()}\\LauncherDL_Data\\ydl.bin";

    // ffmpeg location
    private static string Ffmpeg = $"{Directory.GetCurrentDirectory()}\\LauncherDL_Data";

    // For the renaming process
    private List<string> ext = new() { "mp4", "mkv", "webm", "mp3", "m4a", "3gp", "flv" };

    // Hidden button / Update notes
    readonly string HiddenButtonText = "LauncherDL Development Build\n\n" +
        "OMG this is so Ｅ Ｐ Ｉ Ｃ!!\n\n" +
        "New GUI/Layout, Animations!?!\n\n" +
        "The OLD Button Hover Animation from ver3 is even back!??\n\n\n" +
        "Update v6.1:\n" +
        "Added Few Languages\n" +
        "Added Customizable Background color\n" +
        "Fixed font family\n\n" +
        "Created by Kasura.";

    // config
    public LauncherDefaultConfig Config = new();

    // Download / Update / File Format
    private Process Proc;

    // Window focus animations
    private DoubleAnimation Opac;
    private ColorAnimation Anim;

    // Temporary variables
    private string TemporaryEncodedName = string.Empty;
    private List<string> TemporaryFormatNames = new();
    private static string temp = string.Empty;
    public string TemporarySelectedFileFormat = string.Empty;
    public List<string> TemporaryFormatList = new();


    // others
    private bool IsDownloading = false;
    private MemoryStream DocumentTemp;


    // Window Flashing
    [DllImport("user32.dll", CallingConvention = CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static extern bool FlashWindowEx(ref FLASHWINFO pwfi);
    private const uint FLASHW_ALL = 3;
    private const uint FLASHW_TIMERNOFG = 12;
    [StructLayout(LayoutKind.Sequential)]
    private struct FLASHWINFO
    {
        public uint cbSize;
        public IntPtr hwnd;
        public uint dwFlags;
        public uint uCount;
        public uint dwTimeout;
    }

}
//https://www.youtube.com/playlist?list=PLbQl2vL-gF3-ijF3Se5qneu8ryV4pI2hx
//https://www.youtube.com/watch?v=ZWdYxQz4UqE