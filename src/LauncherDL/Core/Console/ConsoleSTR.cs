namespace LauncherDL.Core.ConsoleDL;

public abstract class ConsoleLive_STR
{
    // Error output
    public const string ERROR_MESSAGE_HINT =
    "$nl$1. Link is unavailable$nl$2. Link is invalid$nl$3. Check internet connection.$nl$"+
    "4. YT-DLP might be outdated please update it first!";

    #region FORMAT STR
    public const int
    ID            = 0,
    FORMAT        = 1,
    RESOLUTION    = 2,
    FPS           = 3,
    SIZE          = 4,
    BITRATE       = 5;
    #endregion

    #region DOWNLOAD STR
    public const int 
    DOWNLOAD_SIZE           = 0,
    DOWNLOAD_PROGRESS       = 1,
    DOWNLOAD_SPEED          = 2,
    DOWNLOAD_ETA            = 3,
    DOWNLOAD_FMT_SPEED      = 0,
    DOWNLOAD_FMT_SIZE       = 1,
    DOWNLOAD_FMT_PROGRESS   = 2;

    public const string
    PROCESSING_MESSAGE      = "Please wait until its finished processing.",
    DOWNSPEED_COLOR_GB      = "Pink",
    DOWNSPEED_COLOR_MB_HIGH = "#83fa57",
    DOWNSPEED_COLOR_MB_LOW  = "#fff154",
    DOWNSPEED_COLOR_KB_HIGH = "Red",
    DOWNSPEED_COLOR_KB_LOW  = "#381900";
    #endregion

    #region UPDATE STR
    public const string
    UPDATE_UPDATED_MSG      = "File is up to date!",
    UPDATE_SUCCESS_MSG      = "Updated!";
    #endregion

    #region CONVERT STR
    public const string
    CONVERT_GROUP_TOTALTIME     = "TotalTime",
    CONVERT_GROUP_CURRENTTIME   = "CurrentTime";
    #endregion
    
}

// here's a little lesson in trickery
internal partial class ConsoleLive : ConsoleLive_STR {}