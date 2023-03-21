namespace LauncherDL.Core.Metadata;

public partial class MetadataWindow : Window
{
    MetadataClicked DefaultClicked = MetadataClicked.Cancel;
    public static bool IsWindowOpen = false;

    #region For Tooltips
    [ToolTipTexts("Edit Title")]
    internal static TextBox Metadata_Title         { get; set; }
    [ToolTipTexts("Edit Album")]
    internal static TextBox Metadata_Album         { get; set; }
    [ToolTipTexts("Edit Artist")]
    internal static TextBox Metadata_Album_Artist  { get; set; }
    [ToolTipTexts("Set the Year")]
    internal static TextBox Metadata_Year          { get; set; }
    [ToolTipTexts("Edit Genre")]
    internal static TextBox Metadata_Genre         { get; set; }

    [ToolTipTexts("Set the Metadata")]
    internal static Button Button_Set              { get; set; }
    [ToolTipTexts("Cancel Metadata")]
    internal static Button Button_Cancel           { get; set; }
    [ToolTipTexts("Close Window")]
    internal static Button Button_Exit             { get; set; }
    #endregion

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