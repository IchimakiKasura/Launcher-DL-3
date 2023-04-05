namespace LauncherDL.Core.Metadata;

public partial class MetadataWindow : Window
{
    MetadataClicked DefaultClicked = MetadataClicked.Cancel;
    public static bool IsWindowOpen = false;
    public bool IsTextChanged = false;
    
    public MetadataWindow()
    {
        InitializeComponent();
        InitializeBorderEffect();
        MetadataGet();
    }

    public MetadataClicked OpenDialog()
    {
        ShowDialog();
        return DefaultClicked;
    }

    private void MetadataSet(object s, RoutedEventArgs e)
    {
        SetOldText(ref Old_Title, Metadata_Title);
        SetOldText(ref Old_Album, Metadata_Album);
        SetOldText(ref Old_Album_Artist, Metadata_Album_Artist);
        SetOldText(ref Old_Year, Metadata_Year);
        SetOldText(ref Old_Genre, Metadata_Genre);

        DefaultClicked = MetadataClicked.Set;
        Close();
    }

    private void MetadataGet()
    {
        GetOldText(in Old_Title, Metadata_Title);
        GetOldText(in Old_Album, Metadata_Album);
        GetOldText(in Old_Album_Artist, Metadata_Album_Artist);
        GetOldText(in Old_Year, Metadata_Year);
        GetOldText(in Old_Genre, Metadata_Genre);
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