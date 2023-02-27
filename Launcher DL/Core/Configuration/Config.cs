using DLLanguages.Pick;

namespace Launcher_DL.Core.Configuration;

public class DefaultConfig
{
	public string background = "background.png";
	public string DefaultOutput = "output";
	public string BrowserCookie = "chrome";

	public Color backgroundColor = ClrConv("#FF161438");
	public Color backgroundGlow = ClrConv("#FF7DB5FF");

	public bool ShowSystemOutput = true;
	public bool EnablePlaylist = true;
	public bool EpicAnimations = true;
	public bool AllowCookies = false;

	public int DefaultFileTypeOnStartUp  = 0;
	public LanguageName Language  = 0;
	
	public bool ConfigReadFinished = false;
}

public class Config
{
	static bool error = false;
	static DefaultConfig DefaultConfiguration;
	public static DefaultConfig ReadConfigINI(string Name = "Config.ini")
	{
		FileIniDataParser parser = new();
		DefaultConfiguration = new();
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

		// HOLY FUCKING SHIT I JUST NEEDED TO ADD THE "REF" BECAUSE ITS JUST PASSING ITS VALUE
		// SO IF I TRIED TO CHANGE THE VALUE FROM THAT METHOD IT WONT CHANGE UNLESS I REFERENCE IT
		// THANKS TO THIS SAVIOR:
		// https://codeeasy.io/lesson/passing_parameters_to_functions
		CheckError(ref DefaultConfiguration.background, Data["Background"]["backgroundName"],"backgroundName");
		CheckError(ref DefaultConfiguration.backgroundColor, Data["Background"]["backgroundColor"],"backgroundColor");
		CheckError(ref DefaultConfiguration.backgroundGlow, Data["Background"]["backgroundGlowColor"],"backgroundGlowColor");
		CheckError(ref DefaultConfiguration.DefaultOutput, Data["File"]["DefaultOutput"],"DefaultOutput");
		CheckError(ref DefaultConfiguration.ShowSystemOutput, Data["Console"]["ShowSystemOutput"],"ShowSystemOutput");
		CheckError(ref DefaultConfiguration.DefaultFileTypeOnStartUp, Data["DropDown"]["DefaultFileTypeOnStartUp"],"DefaultFileTypeOnStartUp");
		CheckError(ref DefaultConfiguration.EnablePlaylist, Data["Playlist"]["EnablePlaylist"],"EnablePlaylist");
		CheckError(ref DefaultConfiguration.EpicAnimations, Data["graphics"]["EpicAnimations"],"EpicAnimations");
		CheckError(ref DefaultConfiguration.AllowCookies, Data["Cookies"]["AllowCookies"],"AllowCookies");
		CheckError(ref DefaultConfiguration.BrowserCookie, Data["Cookies"]["BrowserCookie"],"BrowserCookie");

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
		DefaultConfiguration.ConfigReadFinished = true;
		return DefaultConfiguration;
	}

	private static void CheckError<T>(ref T a,dynamic b,string c)
	{
		#if DEBUG
			ConsoleDebug.LoadingConfig(a,b,c);
		#endif

		try
		{
			switch(a.GetType().ToString())
			{
				case "System.String": 				a = b; 				break;
				case "System.Int32": 				a = int.Parse(b); 	break;
				case "System.Windows.Media.Color": 	a = ClrConv(b); 	break;
				case "System.Boolean": 				a = bool.Parse(b); 	break;
			}
			
		} catch(Exception e)
		{
			error = true;
			ConsoleOutputMethod.ConfigOutputComment(1, e.Message, c);
		}
	} 
}