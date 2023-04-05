namespace LauncherDL.Core.Metadata;

public partial class MetadataWindow
{
    #region Constant int variables
    const int
    METADATA_TITLE              = 0,
    METADATA_ALBUM              = 1,
    METADATA_ALBUM_ARTIST       = 2,
    METADATA_YEAR               = 3,
    METADATA_GENRE              = 4,
    METADATA_LABEL              = 5;
    #endregion

    const string
    LABEL_WINDOW_TITLE          = "Launcher DL -METADATA EDIT-",
    LABEL_TITLE                 = "Title\t\t: ",
    LABEL_ALBUM                 = "Album\t\t: ",
    LABEL_ALBUM_ARTIST          = "Album Artist\t: ",
    LABEL_YEAR                  = "Year\t\t: ",
    LABEL_GENRE                 = "Genre\t\t: ",
    LABEL_CREATOR               = "Created by Ichimaki Kasura",
    PLACEHOLDER_TITLE           = "Title (e.g: 21, Nichiyoubi etc..) ",
    PLACEHOLDER_ALBUM           = "Album (e.g: RED, Tegami etc..) ",
    PLACEHOLDER_ALBUM_ARTIST    = "Album Artist (e.g: Taylor Swift, Back Number etc..) ",
    PLACEHOLDER_YEAR            = "Year (e.g: 2003, 2013, 2023 etc..) ",
    PLACEHOLDER_GENRE           = "Genre (e.g: JPOP, KPOP, ROCK etc..) ",
    BUTTON_SET                  = "Set",
    BUTTON_CANCEL               = "Cancel",
    DEFAULT_COLOR               = "#FF011F4C",
    TOPBAR_COLOR                = "#A34F002F",
    WINDOW_RESOURCE_EXIT_BUTTON = "ExitButtonAlt",
    WINDOW_RESOURCE_BUTTONS     = "MetadataButtons",
    MESSAGE_CLEARED             = "Metadata has been cleared!";
    
    readonly string
    WINDOW_BACKGROUND           = $"pack://siteoforigin:,,,/Images/{config.background}",
    WINDOW_ICON                 = $@"pack://application:,,,{DLStrings.AppIcon}";
}