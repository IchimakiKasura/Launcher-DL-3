namespace LauncherDL.Core.Metadata;

public partial class MetadataWindow
{
    private void GetOldText(string Old, TextBoxControl Element) =>
        Element.Text = Old;

    private void SetOldText(ref string Old, TextBoxControl Element)
    {
        if(Old != Element.Text && Element.Text is not "" or null)
            IsTextChanged = true;

        Old = Element.Text is "" ? null : Element.Text;
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

    // Another chatGPT refactoring ffs
    public static void ApplyMetadataOnFile()
    {
        // Retrieve input from UI controls
        string
        directoryOutput     = config.DefaultOutput,
        directoryType       = comboBoxType.GetItemContent,
        fileName            = textBoxName.Text,
        fileExtension       = comboBoxFormat.GetItemContent,
        filePath            = Path.Combine(directoryOutput, directoryType),
        fullFilePath        = Path.Combine(filePath, $"{fileName}.{fileExtension}"),
        temporaryFilePath   = Path.Combine(filePath, $"TEMP_{fileName}.{fileExtension}");
        
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

        ffmpegProcess.StartAsync();

        // Rename temporary file to final file name
        File.Delete(fullFilePath);
        File.Move(temporaryFilePath, fullFilePath);
    }

}