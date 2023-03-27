namespace LauncherDL.Core.Buttons;

internal class ConvertButton : IButtonControls
{
    #region Error Texts
    public const string
    FILE___NOTFOUND   = "<%14>Selected file cannot be found!",
    NAME___REQUIRED   = "<%14>Name is required!",
    FFMPEG_NOTFOUND   = "<%14>FFmpeg files are missing! Cannot continue.",
    NAME___EXIST      = "<%14>File already Exist! or File name are the same!";
    #endregion

    public static void ButtonClicked(object s, RoutedEventArgs e)
    {
        var FILE_EXIST_PATH = $"{config.DefaultOutput}\\Convert\\{textBoxName.Text}.{comboBoxFormat.GetItemContent}";

        string ErrorString = string.Empty switch
        {
            _ when !File.Exists(textBoxLink.Text)          => FILE___NOTFOUND,
            _ when string.IsNullOrEmpty(textBoxName.Text)  => NAME___REQUIRED,
            _ when FFmpeg.FFmpegFiles.ErrorOccured         => FFMPEG_NOTFOUND,
            _ when File.Exists(FILE_EXIST_PATH)            => NAME___EXIST,
            _ => string.Empty
        };

        if(!ErrorString.IsEmpty())
        {
            console.DLAddConsole(CONSOLE_ERROR_SOFT_STRING, ErrorString);
            return;
        }

        console.AddFormattedText("<#83fa57%14>[PROCESSING] <%14>Please wait until the conversion is finished.");

        YDL YDLInfo = new(
            new()
            {
                Link = textBoxLink.Text,
                Format = comboBoxFormat.GetItemContent
            }
        );

        YDLInfo.ConvertMethod();

        WindowsComponents.FreezeComponents();
    }
}