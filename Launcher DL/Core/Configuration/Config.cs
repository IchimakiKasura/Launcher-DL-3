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
	static bool error = false;
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

		CheckError<string>(DefaultConfiguration.background, Data["Background"]["backgroundName"]);
		CheckError<Color>(DefaultConfiguration.backgroundColor, Data["Background"]["backgroundColor"]);
		CheckError<Color>(DefaultConfiguration.backgroundGlow, Data["Background"]["backgroundGlowColor"]);

		CheckError<string>(DefaultConfiguration.DefaultOutput, Data["File"]["DefaultOutput"]);

		CheckError<bool>(DefaultConfiguration.ShowSystemOutput, Data["Console"]["ShowSystemOutput"]);

		CheckError<int>(DefaultConfiguration.DefaultFileTypeOnStartUp, Data["DropDown"]["DefaultFileTypeOnStartUp"]);

		CheckError<bool>(DefaultConfiguration.EnablePlaylist, Data["Playlist"]["EnablePlaylist"]);
		CheckError<bool>(DefaultConfiguration.EpicAnimations, Data["graphics"]["EpicAnimations"]);
		CheckError<string>(DefaultConfiguration.BrowserCookie, Data["BrowserCookie"]["BrowserCookie"]);
		
		// Well they are excluded on Release mode so what gives
		#if DEBUG
			ConsoleDebug.LoadingConfig<string>(DefaultConfiguration.background, Data["Background"]["backgroundName"],"backgroundName");
			ConsoleDebug.LoadingConfig<Color>(DefaultConfiguration.backgroundColor, ClrConv(Data["Background"]["backgroundColor"]),"backgroundColor");
			ConsoleDebug.LoadingConfig<Color>(DefaultConfiguration.backgroundGlow, ClrConv(Data["Background"]["backgroundGlowColor"]),"backgroundGlowColor");
			ConsoleDebug.LoadingConfig<string>(DefaultConfiguration.DefaultOutput, Data["File"]["DefaultOutput"],"DefaultOutput");
			ConsoleDebug.LoadingConfig<bool>(DefaultConfiguration.ShowSystemOutput, bool.Parse(Data["Console"]["ShowSystemOutput"]),"ShowSystemOutput");
			ConsoleDebug.LoadingConfig<int>(DefaultConfiguration.DefaultFileTypeOnStartUp, int.Parse(Data["DropDown"]["DefaultFileTypeOnStartUp"]),"DefaultFileTypeOnStartUp");
			ConsoleDebug.LoadingConfig<bool>(DefaultConfiguration.EnablePlaylist, bool.Parse(Data["Playlist"]["EnablePlaylist"]),"EnablePlaylist");
			ConsoleDebug.LoadingConfig<bool>(DefaultConfiguration.EpicAnimations, bool.Parse(Data["graphics"]["EpicAnimations"]),"EpicAnimations");
			ConsoleDebug.LoadingConfig<string>(DefaultConfiguration.BrowserCookie, Data["BrowserCookie"]["BrowserCookie"],"BrowserCookie");
		#endif

		if(!error)
		{
			ConsoleOutputMethod.ConfigOutputComment(true);
			#if DEBUG
				ConsoleDebug.LoadConfigDone(false);
			#endif
		}
		else 
		{
			#if DEBUG
				ConsoleDebug.LoadConfigDone(true);
			#endif
		}
		return DefaultConfiguration;
	}

	private static void CheckError<T>(T a,dynamic b)
	{
		try
		{
			switch(a.GetType().ToString())
			{
				case "System.String": a = b; break;
				case "System.Int32": a = int.Parse(b); break;
				case "System.Windows.Media.Color": a = ClrConv(b); break;
				case "System.Boolean": a = bool.Parse(b); break;
			}

		} catch(Exception e)
		{
			error = true;
			ConsoleOutputMethod.ConfigOutputComment(false, e.Message);
		}
	} 
}