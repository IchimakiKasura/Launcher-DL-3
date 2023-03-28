namespace LauncherDL.Core.Configuration;

public abstract class CONFIG_STR
{
    //DefaultConfig
    public const string CONFIG_DEFAULT_BACKGROUND           = "background.jpg";
    public const string CONFIG_DEFAULT_OUTPUT               = "output";
    public const string CONFIG_DEFAULT_COOKIE               = "chrome";
    public const string CONFIG_DEFAULT_BACKGROUND_COLOR     = "#FF161438";
    public const string CONFIG_DEFAULT_BACKGROUND_GLOW      = "#FF7DB5FF";
    public const bool CONFIG_DEFAULT_SYSTEM_OUTPUT          = true;
    public const bool CONFIG_DEFAULT_ANIMATIONS             = true;
    public const bool CONFIG_DEFAULT_COOKIES                = false;
    public const int CONFIG_DEFAULT_FILE_TYPE               = 0;
    

    // uhh yeah
    public const string CONFIG_NAME                         = "Config.ini";
    public const string CONFIG_LANGUAGE                     = "Language";
    public const string CONFIG_BACKGROUND_NAME              = "backgroundName";
    public const string CONFIG_BACKGROUND_COLOR             = "backgroundColor";
    public const string CONFIG_BACKGROUND_GLOW              = "backgroundGlowColor";
    public const string CONFIG_ALLOW_COOKIES                = "AllowCookies";
    public const string CONFIG_BROWSER_COOKIES              = "BrowserCookie";
    public const string CONFIG_OUTPUT                       = "DefaultOutput";
    public const string CONFIG_SYSTEM_OUTPUT                = "ShowSystemOutput";
    public const string CONFIG_FILE_TYPE                    = "DefaultFileTypeOnStartUp";
    public const string CONFIG_ANIMATIONS                   = "EpicAnimations";

    public const string CONFIG_SECTION_APP                  = "App";
    public const string CONFIG_SECTION_BACKROUND            = "Background";
    public const string CONFIG_SECTION_COOKIES              = "Cookies";
    public const string CONFIG_SECTION_FILE                 = "File";
    public const string CONFIG_SECTION_CONSOLE              = "Console";
    public const string CONFIG_SECTION_DROPDOWN             = "DropDown";
    public const string CONFIG_SECTION_GRAPHICS             = "graphics";

    public const string CONFIG_COLOR_CONTAINS               = "System.Windows.Media.Color";

    // they called me a madman
    public const int    CONFIG_PROPERTY_BACKGROUND_NAME     = 0;
    public const int    CONFIG_PROPERTY_BACKGROUND_COLOR    = 1;
    public const int    CONFIG_PROPERTY_BACKGROUND_GLOW     = 2;
    public const int    CONFIG_PROPERTY_ALLOW_COOKIES       = 0;
    public const int    CONFIG_PROPERTY_BROWSER_COOKIES     = 1;
    public const int    CONFIG_PROPERTY_OUTPUT              = 0;
    public const int    CONFIG_PROPERTY_SYSTEM_OUTPUT       = 0;
    public const int    CONFIG_PROPERTY_FILE_TYPE           = 0;
    public const int    CONFIG_PROPERTY_ANMATIONS           = 0;
}