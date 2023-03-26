namespace LauncherDL.Core.Metadata;

public partial class MetadataWindow : Window
{
    MetadataClicked DefaultClicked = MetadataClicked.Cancel;
    public static bool IsWindowOpen = false;
    public bool IsTextChanged = false;
    public enum MetadataClicked { Set,Cancel }
    public MetadataWindow()
    {
        InitializeComponent();
        InitializeBorderEffect();

        GetOldText(Old_Title, Metadata_Title);
        GetOldText(Old_Album, Metadata_Album);
        GetOldText(Old_Album_Artist, Metadata_Album_Artist);
        GetOldText(Old_Year, Metadata_Year);
        GetOldText(Old_Genre, Metadata_Genre);
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

    public static void MetadataClear()
    {
        console.DLAddConsole(CONSOLE_INFO_STRING, "Metadata has been cleared!");

        Old_Title           =
        Old_Album           =
        Old_Album_Artist    =
        Old_Year            =
        Old_Genre           = null;
    }
}