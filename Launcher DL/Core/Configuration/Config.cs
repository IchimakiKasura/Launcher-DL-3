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
	
	public bool ConfigReadFinished = false;
}

public class Config
{
	static bool error = false;
	public static DefaultConfig ReadConfigINI(string Name = "Config.ini")
	{
		FileIniDataParser parser = new();
		DefaultConfig DefaultConfiguration = new();
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

		// So passing the variables on the arguments
		// then changing the variables on that method
		// doesn't actually change the real one but only change
		// the value on that scope only?
		// I guess I didn't read enough documentation about scoping on c# 
		#region pretty ugly code
		if(CheckError(DefaultConfiguration.background, Data["Background"]["backgroundName"],"backgroundName"))
			DefaultConfiguration.background = Data["Background"]["backgroundName"];
		if(CheckError(DefaultConfiguration.backgroundColor, Data["Background"]["backgroundColor"],"backgroundColor"))
			DefaultConfiguration.backgroundColor = ClrConv(Data["Background"]["backgroundColor"]);
		if(CheckError(DefaultConfiguration.backgroundGlow, Data["Background"]["backgroundGlowColor"],"backgroundGlowColor"))
			DefaultConfiguration.backgroundGlow = ClrConv(Data["Background"]["backgroundGlowColor"]);
		if(CheckError(DefaultConfiguration.DefaultOutput, Data["File"]["DefaultOutput"],"DefaultOutput"))
			DefaultConfiguration.DefaultOutput = Data["File"]["DefaultOutput"];
		if(CheckError(DefaultConfiguration.ShowSystemOutput, Data["Console"]["ShowSystemOutput"],"ShowSystemOutput"))
			DefaultConfiguration.ShowSystemOutput = bool.Parse(Data["Console"]["ShowSystemOutput"]);
		if(CheckError(DefaultConfiguration.DefaultFileTypeOnStartUp, Data["DropDown"]["DefaultFileTypeOnStartUp"],"DefaultFileTypeOnStartUp"))
			DefaultConfiguration.DefaultFileTypeOnStartUp = int.Parse(Data["DropDown"]["DefaultFileTypeOnStartUp"]);
		if(CheckError(DefaultConfiguration.EnablePlaylist, Data["Playlist"]["EnablePlaylist"],"EnablePlaylist"))
			DefaultConfiguration.EnablePlaylist = bool.Parse(Data["Playlist"]["EnablePlaylist"]);
		if(CheckError(DefaultConfiguration.EpicAnimations, Data["graphics"]["EpicAnimations"],"EpicAnimations"))
			DefaultConfiguration.EpicAnimations = bool.Parse(Data["graphics"]["EpicAnimations"]);
		if(CheckError(DefaultConfiguration.AllowCookies, Data["Cookies"]["AllowCookies"],"AllowCookies"))
			DefaultConfiguration.AllowCookies = bool.Parse(Data["Cookies"]["AllowCookies"]);
		if(CheckError(DefaultConfiguration.BrowserCookie, Data["Cookies"]["BrowserCookie"],"BrowserCookie"))
			DefaultConfiguration.BrowserCookie = Data["Cookies"]["BrowserCookie"];
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
		DefaultConfiguration.ConfigReadFinished = true;
		return DefaultConfiguration;
	}

	// it was a "void" but i turned to bool now because idfk
	private static bool CheckError(dynamic a,dynamic b,string c)
	{
		#if DEBUG
			ConsoleDebug.LoadingConfig(a,b,c);
		#endif
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
			ConsoleOutputMethod.ConfigOutputComment(1, e.Message, c);
		}
		if(error) return false;
		else return true;
	} 
}