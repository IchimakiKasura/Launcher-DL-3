namespace LauncherDL.Core.Metadata;

public partial class MetadataWindow
{
    private void GetOldText(in string Old, TextBoxControl Element) =>
        Element.Text = Old;

    private void SetOldText(ref string Old, TextBoxControl Element)
    {
        if(Old != Element.Text && !Element.Text.IsEmpty())
            IsTextChanged = true;

        Old = Element.Text.IsEmpty() ? null : Element.Text;
    }
    
    void AddToCanvas(UIElement Element) =>
        MetadataWindowCanvas.Add(Element);

    void InitializeBorderEffect()
    {
        void Focus(ColorAnimation WindowAnimation, DoubleAnimation WindowOpacity)
        {
            new StoryboardApplier(WindowOpacity     ,   this                ,   new(             "(Window.Effect).Opacity"        ) );
            new StoryboardApplier(WindowAnimation   ,   MetadataRoundBorder ,   new("(Control.Background).(SolidColorBrush.Color)") );
        }

        Activated += (s,e) =>
            Focus(
                WindowOpacity       : new(1, TimeSpan.FromMilliseconds(100)),
                WindowAnimation     : new(config.backgroundColor, TimeSpan.FromMilliseconds(100))
            );
        

        Deactivated += (s,e) =>
            Focus(
                WindowOpacity       : new(0, TimeSpan.FromMilliseconds(100)),
                WindowAnimation     : new(Colors.Black, TimeSpan.FromMilliseconds(100))
            );
    }

    // Ight, hear me out!
    // The reason this exist because "postprocessing-args" on ytdlp
    // won't fire when the file isn't "converted" or "merged" so selecting the 
    // "best" format won't run "postprocessing-args" hence this method
    // exist just to add metadata on a single option "Video Type: mp4"
    // The Convert type and Audio type still works tho
    public static async void ApplyMetadataOnFile()
    {
        // Retrieve input from UI controls
        string
        filePath            = Path.Combine(config.DefaultOutput, comboBoxType.GetItemContent),
        fullFilePath        = Path.Combine(filePath, $"{textBoxName.Text}.mp4"),
        temporaryFilePath   = Path.Combine(filePath, $"TEMP_{textBoxName.Text}.mp4");
        
        // Prepare FFmpeg command
        var metadataArguments = new StringBuilder();
        metadataArguments.Append($"-i \"{fullFilePath}\" ");
        metadataArguments.Append($"-metadata title=\"{Old_Title}\" ");
        metadataArguments.Append($"-metadata album=\"{Old_Album}\" ");
        metadataArguments.Append($"-metadata album_artist=\"{Old_Album_Artist}\" ");
        metadataArguments.Append($"-metadata date=\"{Old_Year}\" ");
        metadataArguments.Append($"-metadata genre=\"{Old_Genre}\" ");
        metadataArguments.Append($"-metadata description=\"Downloaded on launcherDL\" ");
        metadataArguments.Append($"-metadata comment=\"Downloaded on launcherDL\" ");
        
        Process ffmpegProcess = new()
        {
            StartInfo = new ProcessStartInfo()
            {
                FileName = FFMPEG_Path,
                Arguments = $"{metadataArguments.ToString()} -codec copy \"{temporaryFilePath}\"",
                CreateNoWindow = true,
                UseShellExecute = false,
            }
        };

        await ffmpegProcess.StartAsync();
        await ffmpegProcess.WaitForExitAsync();

        File.Delete(fullFilePath);
        File.Move(temporaryFilePath, fullFilePath);
    }

    public static void ApplyMetadataOnFile(ref StringBuilder MetadataArguments)
    {
        MetadataArguments.Append(" --postprocessor-args \"ffmpeg:");
        MetadataArguments.Append($"-metadata title='{Old_Title}' ");
        MetadataArguments.Append($"-metadata album='{Old_Album}' ");
        MetadataArguments.Append($"-metadata album_artist='{Old_Album_Artist}' ");
        MetadataArguments.Append($"-metadata date='{Old_Year}' ");
        MetadataArguments.Append($"-metadata genre='{Old_Genre}' ");
        MetadataArguments.Append($"-metadata description='Downloaded on launcherDL' ");
        MetadataArguments.Append($"-metadata comment='Downloaded on launcherDL' \"");
    }

}