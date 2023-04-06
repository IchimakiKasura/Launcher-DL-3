namespace DLControls;

public abstract class CONSOLEOUTPUTMETHOD_STR
{
    public const string CONSOLE_START                   = "<Gray%15>堂主の私に何か用かな？あれ、知らなかった？私が往生堂七十七代目堂主、胡桃だよ！でもあなた、ツヤのある髪に健康そうな体してる･･･そっか！仕事以外で私に用があるってことだね？<>"; 
    public const string CONSOLE_SYSTEM_STRING           = "<#a85192%14>[SYSTEM] <%14>";
    public const string CONSOLE_ERROR_STRING            = "<Red%14>[ERROR] <%14>";
    public const string CONSOLE_WARNING_STRING          = "<Yellow%14>[WARNING] <%14>";
    public const string CONSOLE_ERROR_SOFT_STRING       = "<Orange%14>[ERROR] <%14>";
    public const string CONSOLE_INFO_STRING             = "<Yellow%14>[INFO] <%14>";
    public const string CONSOLE_YEY_STRING              = "<Pink%14>[YEY] <%14>";
    public const string CONSOLE_VERBOSE_STRING          = "<Cyan%14>[V] <%14>";
    public const string CONSOLE_PROCESSING              = "<Cyan%14>[PROCESSING] <%14>";

    public const string CONSOLE_METADATA_TITLE          = "[METADATA] Title$tab$$tab$:  ";
    public const string CONSOLE_METADATA_ALBUM          = "[METADATA] Album$tab$$tab$:  ";
    public const string CONSOLE_METADATA_ALBUM_ARTIST   = "[METADATA] Album Artist:$tab$:  ";
    public const string CONSOLE_METADATA_YEAR           = "[METADATA] Year$tab$$tab$:  ";
    public const string CONSOLE_METADATA_GENRE          = "[METADATA] Genre$tab$$tab$:  ";

    [Browsable(false)]
    public const string REGEX_STRING                    = @"<(?<color>.*?)(?:%(?:(?<size>.*?)\|(?<weight>.*?))|%(?<sizeOnly>.*?)|)>(?<text>.*?)(?=<|$)";
    
    [Browsable(false)]
    public const string
    LESS_THAN_SIGN                                      = "$lt$",
    GREATER_THAN_SIGN                                   = "$gt$",
    PERCENTAGE_SIGN                                     = "$perc$",
    VERTICAL_BAR                                        = "$vbar$",
    TAB                                                 = "$tab$",
    NEW_LINE                                            = "$nl$";
}