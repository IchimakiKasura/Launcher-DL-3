namespace LauncherDL.Core.Metadata;

public partial class MetadataWindow : Window
{
    public static bool IsWindowOpen = false;
    public bool IsTextChanged = false;
    
    public MetadataWindow()
    {
        InitializeComponent();
        InitializeBorderEffect();
        MetadataGet();
    }

    public MetadataClicked OpenDialog() =>
        ShowDialog().Value ? MetadataClicked.Set : MetadataClicked.Cancel;
    
    private void MetadataSet(object s, RoutedEventArgs e)
    {
        SetOldText(ref Old_Title, Metadata_Title);
        SetOldText(ref Old_Album, Metadata_Album);
        SetOldText(ref Old_Album_Artist, Metadata_Album_Artist);
        SetOldText(ref Old_Year, Metadata_Year);
        SetOldText(ref Old_Genre, Metadata_Genre);

        this.DialogResult = true;
        Close();
    }

    private void MetadataGet()
    {
        GetOldText(Old_Title, Metadata_Title);
        GetOldText(Old_Album, Metadata_Album);
        GetOldText(Old_Album_Artist, Metadata_Album_Artist);
        GetOldText(Old_Year, Metadata_Year);
        GetOldText(Old_Genre, Metadata_Genre);
    }

    public static void MetadataClear()
    {
        console.DLAddConsole(CONSOLE_INFO_STRING, MESSAGE_CLEARED);

        Old_Title           =
        Old_Album           =
        Old_Album_Artist    =
        Old_Year            =
        Old_Genre           = null;
    }
}