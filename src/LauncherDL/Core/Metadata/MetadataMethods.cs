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

    // FIXME: Refactor this please future me
    // it looks shit
    public static async void ApplyMetadataOnFile()
    {
        Console.WriteLine("adding metadata");

        bool isFileFound = false;

        #region Finds the file downloaded
        string FilePath = $"{config.DefaultOutput}\\{comboBoxType.GetItemContent ?? ""}\\{textBoxName.Text}.{comboBoxFormat.GetItemContent}";
        string FilePathArugment = "";
        string FileOutputDirectory = $"{config.DefaultOutput}\\{comboBoxType.GetItemContent ?? ""}";
        string FileNameWithExt = $"{textBoxName.Text}.{comboBoxFormat.GetItemContent}";

        if(comboBoxType.ItemIndex == 0)
        {
            foreach(var Ext in FileExtensions)
                if (File.Exists($"{config.DefaultOutput}\\Formatted\\{Ext}\\{textBoxName.Text}.{Ext}"))
                {
                    FilePathArugment = $"{config.DefaultOutput}\\Formatted\\{Ext}\\{textBoxName.Text}.{Ext}";
                    FileOutputDirectory = $"{config.DefaultOutput}\\Formatted\\{Ext}";
                    FileNameWithExt = $"{textBoxName.Text}.{Ext}";
                    isFileFound = true;
                }
        }
        else if (File.Exists(FilePath))
        {
            FilePathArugment = FilePath;
            isFileFound = true;
        }
        
        #endregion
    
        if(isFileFound)
        {

            var Arguments = $" -i \"{FilePathArugment}\" "      +
            $"-metadata title=\"{Old_Title}\" "                 +
            $"-metadata album=\"{Old_Album}\" "                 +
            $"-metadata album_artist=\"{Old_Album_Artist}\" "   +
            $"-metadata date=\"{Old_Year}\" "                   + 
            $"-metadata genre=\"{Old_Genre}\" "                 +
            $"-metadata comment=\"Downloaded on launcherDL\" "  ;

            Process FFmpegMetadata = new();

            string TEMP_DIR = $"\"{FileOutputDirectory}\\TEMP_{FileNameWithExt}\"";
            string DIR_NAME = $"\"{FileOutputDirectory}\\{FileNameWithExt}\"";

            FFmpegMetadata.StartInfo =
                new("cmd.exe", $"/c \"\"{FFMPEG_Path}\" {Arguments} -codec copy {TEMP_DIR} && del {DIR_NAME} && ren {TEMP_DIR} \"{FileNameWithExt}\" \"")
                {
                    CreateNoWindow = true
                };
            
            await FFmpegMetadata.StartAsync();
            await FFmpegMetadata.WaitForExitAsync();
        }
        else
        {
            Console.WriteLine("wat");
            // throw error on console
        }
    }
}