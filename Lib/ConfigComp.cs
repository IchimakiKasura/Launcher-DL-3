namespace Launcher_DL.Lib;

[Serializable]
public class LauncherDefaultConfig
{
	public string BackgroundName { get; set; } = "background.jpg";
	public string BackgroundColor { get; set; } = "#A31F0000";
	public string GlowColor { get; set; } = "#FFFF8282";
	public string DefaultOutput { get; set; } = "output";
	public string SystemLanguage { get; set; } = "default";
	public int DefaultFileTypeOnStartUp { get; set; } = 0;
	public string BrowserCookie { get; set; } = "chrome";
	public bool ShowSystemOutput { get; set; } = true;
	public bool EnablePlaylist { get; set; } = false;
	public bool AllowCookies { get; set; } = false;
	public bool EpicAnimations { get; set; } = true;
}

sealed class ConfigComp : Global
{
	static int TotalDetected = 0;

	// should've used JSON but damn,I don't want to add System.Text.Json or Newtonsoft.Json
	/// <summary>
	/// Loads the <see langword="Config.kasu"/>
	/// </summary>
	public static async Task LoadConfig(CancellationToken ct)
	{
		string Data = string.Empty;

		try
		{
			Data = await File.ReadAllTextAsync(KasuConfigName, ct);
		}
		catch
		{
			MessageBox.Show("Config.kasu is Missing!\nPlease create a Config.kasu to avoid this message", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
			DebugOutput.LoadConfig_Done(true);
			if (Config.ShowSystemOutput) Output_text.AddFormattedText($"<#a85192%14>[SYSTEM] <DarkRed%14>FAILED <gray%14>to locate \"Config.kasu\"");
		}

		try
		{
			Parallel.ForEach(RegexComp.KasuExtension.Matches(Data), match =>{
				DebugOutput.LoadConfig_Debug(match);
				if (match.Groups["BackgroundName"].Success) Config.BackgroundName = match.Groups["BackgroundName"].Value.Trim();
				if (match.Groups["BackgroundColor"].Success) Config.BackgroundColor = match.Groups["BackgroundColor"].Value.Trim();
				if (match.Groups["GlowColor"].Success) Config.GlowColor = match.Groups["GlowColor"].Value.Trim();
				if (match.Groups["DefaultOutput"].Success) Config.DefaultOutput = match.Groups["DefaultOutput"].Value.Trim();
				if (match.Groups["DefaultFileTypeOnStartUp"].Success) Config.DefaultFileTypeOnStartUp = int.Parse(match.Groups["DefaultFileTypeOnStartUp"].Value.Trim());
				if (match.Groups["ShowSystemOutput"].Success) Config.ShowSystemOutput = bool.Parse(match.Groups["ShowSystemOutput"].Value.Trim());
				if (match.Groups["EnablePlaylist"].Success) Config.EnablePlaylist = bool.Parse(match.Groups["EnablePlaylist"].Value.Trim());
				if (match.Groups["Language"].Success) Config.SystemLanguage = match.Groups["Language"].Value.Trim();
				if (match.Groups["AllowCookies"].Success) Config.AllowCookies = bool.Parse(match.Groups["AllowCookies"].Value.Trim());
				if (match.Groups["BrowserCookie"].Success) Config.BrowserCookie = match.Groups["BrowserCookie"].Value.Trim();
				if (match.Groups["EpicAnimations"].Success) Config.EpicAnimations = bool.Parse(match.Groups["EpicAnimations"].Value.Trim());

				if (match.Success) ++TotalDetected;
			});

			ThrowException();

			DebugOutput.Selected_Language(Config.SystemLanguage.ToLower());

			// Custom Background Color
			Color BackgroundColor = ClrConv(Config.BackgroundColor);
			// Custom Background Image
			Window_BackgroundName.ImageSource = new BitmapImage(new Uri($"Images/{Config.BackgroundName}", UriKind.Relative));
			// Custom Window Glow / DropShadow
			Window_DropShadow.Color = ClrConv(Config.GlowColor);

			DebugOutput.LoadConfig_Done(false);
			if (Config.ShowSystemOutput) Output_text.AddFormattedText($"<#a85192%14>[SYSTEM] <DarkGreen%14>SUCCESS <gray%14>\"Config.kasu\" loaded!");
		}
		catch
		{
			DebugOutput.LoadConfig_Done(true);
			Config.BackgroundColor = new LauncherDefaultConfig().BackgroundColor;
			if (Config.ShowSystemOutput) Output_text.AddFormattedText($"<#a85192%14>[SYSTEM] <DarkRed%14>FAILED <gray%14>to load \"Config.kasu\"");
		}

		Input_Type.SelectedIndex = Config.DefaultFileTypeOnStartUp;
	}

	private static void ThrowException()
	{
		bool SystemLanguageConfirm = false;
		string[] Languages = {"japanese", "tagalog", "english", "default", "bruh"};

		// checks if the background location exist
		if (!File.Exists($"Images/{Config.BackgroundName}")) throw new Exception();

		// check if the input exceeds to 3
		if (Config.DefaultFileTypeOnStartUp >= 3) throw new Exception();

		// checks the total options are present in the config.kasu
		if (TotalDetected != 11) throw new Exception();

		Parallel.ForEach(Languages, (lang, state)=>{
			if(Config.SystemLanguage.ToLower() == lang)
			{
				SystemLanguageConfirm = true;
				state.Break();
			}
		});

		if(!SystemLanguageConfirm) throw new Exception();
	}

}
