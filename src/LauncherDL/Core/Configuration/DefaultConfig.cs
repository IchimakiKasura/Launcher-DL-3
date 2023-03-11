using static LauncherDL.Core.Configuration.CONFIG_STR;

namespace LauncherDL.Core.Configuration;

public class DefaultConfig
{
	public string background						=	CONFIG_DEFAULT_BACKGROUND;
	public string DefaultOutput						=	CONFIG_DEFAULT_OUTPUT;
	public string BrowserCookie						=	CONFIG_DEFAULT_COOKIE;
	
	public Color backgroundColor					=	ClrConv(CONFIG_DEFAULT_BACKGROUND_COLOR);
	public Color backgroundGlow						=	ClrConv(CONFIG_DEFAULT_BACKGROUND_GLOW);
	
	public bool ShowSystemOutput					=	CONFIG_DEFAULT_SYSTEM_OUTPUT;
	public bool EnablePlaylist						=	CONFIG_DEFAULT_PLAYLIST;
	public bool EpicAnimations						=	CONFIG_DEFAULT_ANIMATIONS;
	public bool AllowCookies						=	CONFIG_DEFAULT_COOKIES;

	public int DefaultFileTypeOnStartUp 			=	CONFIG_DEFAULT_FILE_TYPE;
	public DLLanguages.Pick.LanguageName Language  	=	0;
}