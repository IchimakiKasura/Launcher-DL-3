namespace Launcher_DL.Core;

public partial class Global
{
	/// <summary>MainWindow but in <see langword="static"/></summary>
	public static MainWindow MainWindowStatic;

	/// <summary>Config</summary>
	public static DefaultConfig config;

	/// <summary>ColorConverter shortcut</summary>
	public static Func<string, Color> ClrConv = (string color) => (Color)ColorConverter.ConvertFromString(color);

	/// <summary>Window focus animations</summary>
	public static DoubleAnimation WindowOpacity;
	public static ColorAnimation WindowAnimation;

	/// <summary>Languages</summary>
	public static DLLanguages.Pick.LanguagePick Language; 

	#region File Formats
	/// <summary>for Renaming Process</summary>
	public static List<string> ext = new() { "mp4", "mkv", "webm", "mp3", "m4a", "3gp", "flv" };
	/// <summary>Video Type Formats</summary>
	public static List<string> VideoType = new() { "mp4", "mkv", "webm", "flv", "auto" };
	/// <summary>Audio Type Formats</summary>
	public static List<string> AudioType = new() { "mp3", "webm", "m4a", "mp4", "wav", "auto" };
	/// <summary>Convert Type Formats</summary>
	public static List<string> ConvertType = new() { "mp4", "mp3", "flv", "webm", "m4a", "mkv", "avi", "wmv", "wma", "ogg", "aac", "wav" };
	#endregion

	public enum ProgressBarState{Hide,Show}

}

