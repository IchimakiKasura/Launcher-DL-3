﻿global using System;
global using System.IO;
global using System.Linq;
global using System.Text;
global using System.Windows;
global using System.Threading;
global using System.Diagnostics;
global using System.Windows.Data;
global using System.Windows.Input;
global using System.Windows.Media;
global using System.Windows.Shapes;
global using System.ComponentModel;
global using System.Windows.Interop;
global using System.Threading.Tasks;
global using System.Windows.Controls;
global using System.Windows.Threading;
global using System.Windows.Documents;
global using System.Windows.Navigation;
global using System.Collections.Generic;
global using System.Windows.Media.Imaging;
global using System.Runtime.InteropServices;
global using System.Text.RegularExpressions;
global using System.Windows.Media.Animation;

namespace Launcher_DL_v6;
public partial class MainWindow
{
	readonly static string YDL_link = $"{Directory.GetCurrentDirectory()}\\LauncherDL_Data\\ydl.bin";
    private static string Ffmpeg = $"{Directory.GetCurrentDirectory()}\\LauncherDL_Data";
    private List<string> ext = new() { "mp4", "mkv", "webm", "mp3", "m4a" };

    readonly string Version = "Build Version:\nDevelopment Build";

    readonly string HiddenButtonText = "LauncherDL buildver6.0\n\n" +
        "OMG this is so Ｅ Ｐ Ｉ Ｃ!!\n\n" +
        "New GUI/Layout, Animations!?!\n\n" +
        "The OLD Button Hover Animation from ver3 is even back!??\n\n\n" +
        "Hotfix Update v6.0.5:\n" +
        "Added Few Languages\n" +
        "Added Customizable Background color\n" +
        "Fixed font family\n\n" +
        "Created by Kasura.";

    public LauncherDefaultConfig Config = new();
    public static MainWindow MW;

    private bool IsDownloading = false;
    private DoubleAnimation Opac;
    private ColorAnimation Anim;
    private MemoryStream DocumentTemp;
    private Process Proc;

    // Temporary variables
    private string TemporaryEncodedName = string.Empty;
    private List<string> TemporaryFormatNames = new();
    public string TemporarySelectedFileFormat = string.Empty;
    public List<string> TemporaryFormatList = new();

    private static string temp = string.Empty;

}
//https://www.youtube.com/playlist?list=PLbQl2vL-gF3-ijF3Se5qneu8ryV4pI2hx