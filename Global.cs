global using System;
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
	readonly static string YDL_link = $"{Directory.GetCurrentDirectory()}\\uVad_Data\\ydl.bin";

    string Version = "Build Version:\nDevelopment Build";

    public static MainWindow MW;

    bool IsDownloading = false;
    DoubleAnimation Opac;
    ColorAnimation Anim;
    MemoryStream DocumentTemp;
}