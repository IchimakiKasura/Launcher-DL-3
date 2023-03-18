namespace LauncherDL.Core.Metadata;

public partial class MetadataWindow : Window
{
    public MetadataWindow() =>
        InitializeComponent();

    // Apparently ShowDialog freezes the code afterwards it
    // like its synchronous not async
    private void MetadataWidowInitialized()
    {
        SetOldText(Old_Title, Metadata_Title);
        SetOldText(Old_Album, Metadata_Album);
        SetOldText(Old_Album_Artist, Metadata_Album_Artist);
        SetOldText(Old_Year, Metadata_Year);
        SetOldText(Old_Genre, Metadata_Genre);
    }

    private void SetOldText(string Old, TextBox Element)
    {
        if(Old == null) return;
        
        Element.Text = Old;

        if(Element.Text == Element.Uid) return;
        
        Element.Foreground = Brushes.Black;
        Element.FontStyle = default;
    }

    private void MetadataSet(object s, RoutedEventArgs e)
    {
        Old_Title           = Metadata_Title.Text;
        Old_Album           = Metadata_Album.Text;
        Old_Album_Artist    = Metadata_Album_Artist.Text;
        Old_Year            = Metadata_Year.Text;
        Old_Genre           = Metadata_Genre.Text;
        Close();
    }
}
