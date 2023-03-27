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

    public static void ApplyMetadataOnFile()
    {
        // for better naming
        string
        DIRECTORY_OUTPUT            = config.DefaultOutput,
        DIRECTORY_TYPE              = comboBoxType.GetItemContent,
        FILE_NAME                   = textBoxName.Text,
        FILE_EXTENSION              = comboBoxFormat.GetItemContent,

        // Full path and Full name with extension
        FILE_FULL_NAME              = $"{FILE_NAME}.{FILE_EXTENSION}",
        FILE_PATH                   = $"{DIRECTORY_OUTPUT}\\{DIRECTORY_TYPE}",

        TEMPORARY_NAME_DIRECTORY    = $"\"{FILE_PATH}\\TEMP_{FILE_FULL_NAME}\"",
        NAME_DIRECTORY              = $"\"{FILE_PATH}\\{FILE_FULL_NAME}\"",

        // For deleting and renaming
        DeleteAndRename             = $"del {NAME_DIRECTORY} && ren {TEMPORARY_NAME_DIRECTORY} \"{FILE_FULL_NAME}\"";
        
        var MetadataArguments = $" -i {NAME_DIRECTORY} "        +
        $"-metadata title=\"{Old_Title}\" "                     +
        $"-metadata album=\"{Old_Album}\" "                     +
        $"-metadata album_artist=\"{Old_Album_Artist}\" "       +
        $"-metadata date=\"{Old_Year}\" "                       + 
        $"-metadata genre=\"{Old_Genre}\" "                     +
        $"-metadata description=\"Downloaded on launcherDL\" "  +
        $"-metadata comment=\"Downloaded on launcherDL\" "      ;

        Process.Start(new ProcessStartInfo()
        {
            FileName        = "cmd.exe",
            Arguments       = $"/c \"\"{FFMPEG_Path}\" {MetadataArguments} -codec copy {TEMPORARY_NAME_DIRECTORY} && {DeleteAndRename} \"",
            CreateNoWindow  = true  
        });
    }
}