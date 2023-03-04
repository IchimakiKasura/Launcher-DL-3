using DLLanguages.Pick;
using static Launcher_DL.Core.Configuration.CONFIG_STR;

namespace Launcher_DL.Core.Configuration;

public class Config
{
	static bool error = false;
	static DefaultConfig DefaultConfiguration = new();
	public static DefaultConfig ReadConfigINI()
	{
		string ConfigString = File.ReadAllText(CONFIG_NAME);
		IniData Data = new IniDataParser().Parse(ConfigString);

		string LanguageCheck = Data[CONFIG_SECTION_APP][CONFIG_LANGUAGE];

		switch(LanguageCheck.ToLower())
		{
			case "default": DefaultConfiguration.Language = LanguageName.Default; break;
			case "english": DefaultConfiguration.Language = LanguageName.English; break;
			case "japanese": DefaultConfiguration.Language = LanguageName.Japanese; break;
			case "tagalog": DefaultConfiguration.Language = LanguageName.Tagalog; break;
			case "bruh": DefaultConfiguration.Language = LanguageName.bruh; break;
		}

		#region Check Error part
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
		#endregion

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
			if(c == CONFIG_FILE_TYPE)
				if(b > 3) throw new Exception("Default File type is above 3!");

			if(c == CONFIG_BACKGROUND_NAME)
				if(!File.Exists($@"./Images/{b}")) throw new Exception("Background image not found!");

			if(a.GetType().ToString().Contains(CONFIG_COLOR_CONTAINS)) a = ClrConv(b);
			else a = b;
		} catch(Exception e)
		{
			error = true;
			ConsoleOutputMethod.ConfigOutputComment(1, e.Message, c);
		}
	} 
}