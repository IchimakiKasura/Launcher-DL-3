using Lang = DLLanguages.Pick.LanguageName;
using static LauncherDL.Core.Configuration.CONFIG_STR;
using static LauncherDL.Core.Console_Output_Comment_Method.ConsoleOutputCheck;

namespace LauncherDL.Core.Configuration;

// Don't even question about it...
/// <summary>
/// Initiate the config by reading the Config.ini
/// </summary>
public class Config
{
    static DefaultConfig DefaultConfiguration   =   new();
    static bool error                           =   false;
    
    /// <summary>
    /// Reads the Config.ini at the current directory
    /// </summary>
    public static DefaultConfig ReadConfigINI()
    {
        string  ConfigString    =   File.ReadAllText(CONFIG_NAME);
        IniDataParser ParserSTR =   new();
        IniData Data            =   new();

        ParserSTR.Scheme.CommentString = "#";
        Data = ParserSTR.Parse(ConfigString);
        
        string  LanguageCheck   =   Data[CONFIG_SECTION_APP][CONFIG_LANGUAGE];

        switch(LanguageCheck.ToLower())
        {
            case "default"  : CheckError(ref DefaultConfiguration.Language, Lang.Default    , CONFIG_LANGUAGE); break;
            case "english"  : CheckError(ref DefaultConfiguration.Language, Lang.English    , CONFIG_LANGUAGE); break;
            case "japanese" : CheckError(ref DefaultConfiguration.Language, Lang.Japanese   , CONFIG_LANGUAGE); break;
            case "tagalog"  : CheckError(ref DefaultConfiguration.Language, Lang.Tagalog    , CONFIG_LANGUAGE); break;
            case "bruh"     : CheckError(ref DefaultConfiguration.Language, Lang.bruh       , CONFIG_LANGUAGE); break;
        }

        #region Check Error part
        CheckError(ref DefaultConfiguration.background               ,  Data[CONFIG_SECTION_BACKROUND][CONFIG_PROPERTY_BACKGROUND_NAME ], CONFIG_BACKGROUND_NAME  );
        CheckError(ref DefaultConfiguration.backgroundColor          ,  Data[CONFIG_SECTION_BACKROUND][CONFIG_PROPERTY_BACKGROUND_COLOR], CONFIG_BACKGROUND_COLOR );
        CheckError(ref DefaultConfiguration.backgroundGlow           ,  Data[CONFIG_SECTION_BACKROUND][CONFIG_PROPERTY_BACKGROUND_GLOW ], CONFIG_BACKGROUND_GLOW  );
        CheckError(ref DefaultConfiguration.AllowCookies             ,  Data[CONFIG_SECTION_COOKIES  ][CONFIG_PROPERTY_ALLOW_COOKIES   ], CONFIG_ALLOW_COOKIES    );
        CheckError(ref DefaultConfiguration.BrowserCookie            ,  Data[CONFIG_SECTION_COOKIES  ][CONFIG_PROPERTY_BROWSER_COOKIES ], CONFIG_BROWSER_COOKIES  );
        CheckError(ref DefaultConfiguration.DefaultOutput            ,  Data[CONFIG_SECTION_FILE     ][CONFIG_PROPERTY_OUTPUT          ], CONFIG_OUTPUT           );
        CheckError(ref DefaultConfiguration.ShowSystemOutput         ,  Data[CONFIG_SECTION_CONSOLE  ][CONFIG_PROPERTY_SYSTEM_OUTPUT   ], CONFIG_SYSTEM_OUTPUT    );
        CheckError(ref DefaultConfiguration.DefaultFileTypeOnStartUp ,  Data[CONFIG_SECTION_DROPDOWN ][CONFIG_PROPERTY_FILE_TYPE       ], CONFIG_FILE_TYPE        );
        CheckError(ref DefaultConfiguration.EpicAnimations           ,  Data[CONFIG_SECTION_GRAPHICS ][CONFIG_PROPERTY_ANMATIONS       ], CONFIG_ANIMATIONS       );
        #endregion

        if(!error)
        {
            ApplyConfig();

            ConsoleOutputMethod.ConfigOutputComment(SUCCESS);
            
            #if DEBUG
                ConsoleDebug.LoadConfigDone(false);
            #endif
        }
        else 
        {
            ConsoleOutputMethod.ConfigOutputComment(FAILED);

            #if DEBUG
                ConsoleDebug.LoadConfigDone(true);
            #endif
        }

        return DefaultConfiguration;
    }

    private static void CheckError<T1, T2>(ref T1 pDefaultConfig, T2 pNewConfig, string pConfigName)
    {
        #if DEBUG
            ConsoleDebug.LoadingConfig(pDefaultConfig, pNewConfig, pConfigName);
        #endif

        switch (pConfigName)
        {
            case CONFIG_FILE_TYPE:
                if (pNewConfig is int nInt && nInt > 3)
                {
                    error = true;
                    ConsoleOutputMethod.ConfigOutputComment(FAILED_MESSAGE, "Default File type is above 3!", pConfigName);
                }
            break;

            case CONFIG_BACKGROUND_NAME:
                var defaultBGPath = $"./Images/{new DefaultConfig().background}";

                if (pNewConfig is string nStr && nStr != new DefaultConfig().background)
                    defaultBGPath = nStr;

                if (!File.Exists(defaultBGPath))
                {
                    error = true;
                    ConsoleOutputMethod.ConfigOutputComment(FAILED_MESSAGE, "Background image not found!", pConfigName);
                }
            break;
        }

        if(pDefaultConfig is Color)
            pDefaultConfig = (T1)(Object)ClrConv(pNewConfig as string);
        else pDefaultConfig = (T1)(Object)pNewConfig;

    }


    private static void ApplyConfig()
    {
        var DefaultBG = $"pack://siteoforigin:,,,/Images/{DefaultConfiguration.background}";
        
        if(DefaultConfiguration.background != new DefaultConfig().background)
            DefaultBG = DefaultConfiguration.background;

        windowBackgroundImage.ImageSource = new BitmapImage(new Uri(DefaultBG, UriKind.Absolute));

        windowDropShadow.Color = DefaultConfiguration.backgroundGlow;
    }
}