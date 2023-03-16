namespace LauncherDL.Core.Buttons;

public class ConvertButton
{
    public static void ButtonConvertClicked()
    {
        if(!File.Exists(textBoxLink.Text))
        {
            console.DLAddConsole(CONSOLE_ERROR_SOFT_STRING, "<%14>Selected file cannot be found!");
            return;
        }

        if(string.IsNullOrEmpty(textBoxName.Text))
        {
            console.DLAddConsole(CONSOLE_ERROR_SOFT_STRING, "<%14>Name is required!");
            return;
        }

        if(FFmpeg.FFmpegFiles.ErrorOccured)
        {
            console.DLAddConsole(CONSOLE_ERROR_SOFT_STRING, "<%14>FFmpeg files are missing! Cannot continue.");
            return;
        }

        if(File.Exists($"{config.DefaultOutput}\\Convert\\{textBoxName.Text}.{comboBoxFormat.GetItemContent}"))
        {
            console.DLAddConsole(CONSOLE_ERROR_SOFT_STRING, "<%14>File already Exist! or File name are the same!");
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