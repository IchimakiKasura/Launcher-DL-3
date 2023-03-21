namespace LauncherDL.Core.Metadata;

public partial class MetadataWindow : Window
{
    MetadataClicked DefaultClicked = MetadataClicked.Cancel;
    public static bool IsWindowOpen = false;
    public enum MetadataClicked { Set,Cancel }
    public MetadataWindow()
    {
        MetadataWindowStatic = this;
        
        InitializeComponent();
        InitializeBorderEffect();

        IsWindowOpen = true;

        GetOldText(Old_Title, Metadata_Title);
        GetOldText(Old_Album, Metadata_Album);
        GetOldText(Old_Album_Artist, Metadata_Album_Artist);
        GetOldText(Old_Year, Metadata_Year);
        GetOldText(Old_Genre, Metadata_Genre);

        new TransparencyConverter(this).MakeTransparent();
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

    private void GetOldText(string Old, TextBox Element)
    {
        if(Old is null) return;
        
        Element.Text = Old;

        if(Element.Text == Element.Uid) return;
        
        Element.Foreground = Brushes.Black;
        Element.FontStyle = default;
    }

    private void SetOldText(ref string Old, TextBox Element)
    {
        if(Element.Text != Element.Uid)
            Old = Element.Text;
        else Old = null;
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