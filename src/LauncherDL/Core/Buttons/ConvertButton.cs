namespace LauncherDL.Core.Buttons;

public class ConvertButton
{
    #region Error Texts
    const string
    FILE_NOTFOUND   = "<%14>Selected file cannot be found!",
    NAME_REQUIRED   = "<%14>Name is required!",
    FFMPEG_NOTFOUND = "<%14>FFmpeg files are missing! Cannot continue.",
    NAME_EXIST      = "<%14>File already Exist! or File name are the same!";
    #endregion

    public static void ButtonConvertClicked()
    {
        var FILE_EXIST_PATH = $"{config.DefaultOutput}\\Convert\\{textBoxName.Text}.{comboBoxFormat.GetItemContent}";

        string ErrorString = string.Empty switch
        {
            _ when !File.Exists(textBoxLink.Text)          => FILE_NOTFOUND,
            _ when string.IsNullOrEmpty(textBoxName.Text)  => NAME_REQUIRED,
            _ when FFmpeg.FFmpegFiles.ErrorOccured         => FFMPEG_NOTFOUND,
            _ when File.Exists(FILE_EXIST_PATH)            => NAME_EXIST,
            _ => string.Empty
        };

        if(!string.IsNullOrEmpty(ErrorString))
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