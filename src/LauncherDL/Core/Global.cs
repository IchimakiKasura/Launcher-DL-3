namespace LauncherDL.Core;

/// <summary>
/// Here lies where single variable can be shared to all.<br/>
/// and also long arrays or list are also here because 
/// it eats up all the space from the method.
/// </summary>
public partial class Global
{
	/// <summary>MainWindow but in <see langword="static"/></summary>
	public static MainWindow MainWindowStatic;

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

	/// <summary>For <see cref="WindowsComponents.FreezeComponents"/></summary>
	public static UIElement[] ControlLists = 
	{
		buttonFileFormat,
		buttonDownload,
		buttonUpdate,
		textBoxLink,
		textBoxName,
		comboBoxType,
		comboBoxFormat
	};

	public enum ProgressBarState{Hide,Show}
}

