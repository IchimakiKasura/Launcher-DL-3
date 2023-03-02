using DLLanguages.Pick;
using static Launcher_DL.Core.Configuration.CONFIG_STR;

namespace Launcher_DL.Core.Configuration;

public class DefaultConfig
{
	public string background = CONFIG_DEFAULT_BACKGROUND;
	public string DefaultOutput = CONFIG_DEFAULT_OUTPUT;
	public string BrowserCookie = CONFIG_DEFAULT_COOKIE;

	public Color backgroundColor = ClrConv(CONFIG_DEFAULT_BACKGROUND_COLOR);
	public Color backgroundGlow = ClrConv(CONFIG_DEFAULT_BACKGROUND_GLOW);

	public bool ShowSystemOutput = CONFIG_DEFAULT_SYSTEM_OUTPUT;
	public bool EnablePlaylist = CONFIG_DEFAULT_PLAYLIST;
	public bool EpicAnimations = CONFIG_DEFAULT_ANIMATIONS;
	public bool AllowCookies = CONFIG_DEFAULT_COOKIES;

	public int DefaultFileTypeOnStartUp = CONFIG_DEFAULT_FILE_TYPE;
	public LanguageName Language  = 0;
}

public class Config
{
	static bool error = false;
	static DefaultConfig DefaultConfiguration;
	public static DefaultConfig ReadConfigINI()
	{
		string ConfigString = File.ReadAllText(CONFIG_NAME);
		IniDataParser parser = new();
		DefaultConfiguration = new();
		IniData Data = parser.Parse(ConfigString);

		string LanguageCheck = Data[CONFIG_SECTION_APP][CONFIG_LANGUAGE];

		switch(LanguageCheck.ToLower())
		{
			case "default": DefaultConfiguration.Language = LanguageName.Default; break;
			case "english": DefaultConfiguration.Language = LanguageName.English; break;
			case "japanese": DefaultConfiguration.Language = LanguageName.Japanese; break;
			case "tagalog": DefaultConfiguration.Language = LanguageName.Tagalog; break;
			case "bruh": DefaultConfiguration.Language = LanguageName.bruh; break;
		}

		// I am pleased on this
		CheckError(ref DefaultConfiguration.background, 				Data[CONFIG_SECTION_BACKROUND][0],	CONFIG_BACKGROUND_NAME);
		CheckError(ref DefaultConfiguration.backgroundColor, 			Data[CONFIG_SECTION_BACKROUND][1],	CONFIG_BACKGROUND_COLOR);
		CheckError(ref DefaultConfiguration.backgroundGlow, 			Data[CONFIG_SECTION_BACKROUND][2],	CONFIG_BACKGROUND_GLOW);
		CheckError(ref DefaultConfiguration.AllowCookies, 				Data[CONFIG_SECTION_COOKIES][0],	CONFIG_ALLOW_COOKIES);
		CheckError(ref DefaultConfiguration.BrowserCookie, 				Data[CONFIG_SECTION_COOKIES][1],	CONFIG_BROWSER_COOKIES);
		CheckError(ref DefaultConfiguration.DefaultOutput, 				Data[CONFIG_SECTION_FILE][0],		CONFIG_OUTPUT);
		CheckError(ref DefaultConfiguration.ShowSystemOutput, 			Data[CONFIG_SECTION_CONSOLE][0],	CONFIG_SYSTEM_OUTPUT);
		CheckError(ref DefaultConfiguration.DefaultFileTypeOnStartUp, 	Data[CONFIG_SECTION_DROPDOWN][0],	CONFIG_FILE_TYPE);
		CheckError(ref DefaultConfiguration.EnablePlaylist, 			Data[CONFIG_SECTION_PLAYLIST][0],	CONFIG_ENABLE_PLAYLIST);
		CheckError(ref DefaultConfiguration.EpicAnimations, 			Data[CONFIG_SECTION_GRAPHICS][0],	CONFIG_ANIMATIONS);

		if(!error)
		{
			ConsoleOutputMethod.ConfigOutputComment(0);
			#if DEBUG
				ConsoleDebug.LoadConfigDone(false);
			#endif
		}
		else 
		{
			ConsoleOutputMethod.ConfigOutputComment(2);
			#if DEBUG
				ConsoleDebug.LoadConfigDone(true);
			#endif
		}
		return DefaultConfiguration;
	}

	private static void CheckError<T>(ref T a, dynamic b, string c)
	{
		#if DEBUG
			ConsoleDebug.LoadingConfig(a,b,c);
		#endif

		try
		{
			if(a.GetType().ToString().Contains(CONFIG_COLOR_CONTAINS)) a = ClrConv(b);
			else a = b;
		} catch(Exception e)
		{
			error = true;
			ConsoleOutputMethod.ConfigOutputComment(1, e.Message, c);
		}
	} 
}