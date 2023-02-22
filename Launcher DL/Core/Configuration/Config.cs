using DLLanguages.Pick;

namespace Launcher_DL.Core.Configuration;

public class DefaultConfig
{
	public string background { get; set; } = "background.png";
	public string DefaultOutput { get; set; } = "output";
	public string BrowserCookie { get; set; } = "chrome";

	public Color backgroundColor { get; set; } = ClrConv("#FF161438");
	public Color backgroundGlow { get; set; } = ClrConv("#FF7DB5FF");

	public bool ShowSystemOutput { get; set; } = true;
	public bool EnablePlaylist { get; set; } = true;
	public bool EpicAnimations { get; set; } = true;
	public bool AllowCookies { get; set; } = false;

	public int DefaultFileTypeOnStartUp { get; set; } = 0;
	public LanguageName Language { get; set; } = 0;
}

public class Config
{
	public static DefaultConfig ReadConfigINI(string Name = "Config.ini")
	{
		var parser = new FileIniDataParser();
		var DefaultConfiguration = new DefaultConfig();
		IniData Data = parser.ReadFile(Name);

		string LanguageCheck = Data["App"]["Language"];
		

		switch(LanguageCheck.ToLower())
		{
			case "default": DefaultConfiguration.Language = LanguageName.Default; break;
			case "english": DefaultConfiguration.Language = LanguageName.English; break;
			case "japanese": DefaultConfiguration.Language = LanguageName.Japanese; break;
			case "tagalog": DefaultConfiguration.Language = LanguageName.Tagalog; break;
			case "bruh": DefaultConfiguration.Language = LanguageName.bruh; break;
		}

		// Background
		DefaultConfiguration.background = Data["Background"]["backgroundName"];
		DefaultConfiguration.backgroundColor = ClrConv(Data["Background"]["backgroundColor"]);
		DefaultConfiguration.backgroundGlow = ClrConv(Data["Background"]["backgroundGlowColor"]);

		// File
		DefaultConfiguration.DefaultOutput = Data["File"]["DefaultOutput"];

		//Console
		DefaultConfiguration.ShowSystemOutput = bool.Parse(Data["Console"]["ShowSystemOutput"]);

		//DropDown
		DefaultConfiguration.DefaultFileTypeOnStartUp = int.Parse(Data["DropDown"]["DefaultFileTypeOnStartUp"]);

		//Playlist
		DefaultConfiguration.EnablePlaylist = bool.Parse(Data["Playlist"]["EnablePlaylist"]);

		//graphics
		DefaultConfiguration.EpicAnimations = bool.Parse(Data["graphics"]["EpicAnimations"]);

		//Cookies
		DefaultConfiguration.BrowserCookie = Data["BrowserCookie"]["BrowserCookie"];

		return DefaultConfiguration;

	}
}