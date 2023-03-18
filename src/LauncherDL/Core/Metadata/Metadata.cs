namespace LauncherDL.Core.Metadata;

// Bro literally created his own shit without xaml ☠️☠️
public partial class MetadataWindow
{
    internal Canvas MetadataWindowCanvas;

    #region Constant int variables
    const int
    METADATA_TITLE = 0,
    METADATA_ALBUM = 1,
    METADATA_ALBUM_ARTIST = 2,
    METADATA_YEAR = 3,
    METADATA_GENRE = 4,
    METADATA_LABEL = 5;
    #endregion

    internal List<TextBlock> LABEL_LIST = new()
    {
        new() { Text = "Title\t\t: "                ,FontFamily=MainWindowStatic.FontFamily, FontSize = 16},
        new() { Text = "Album\t\t: "                ,FontFamily=MainWindowStatic.FontFamily, FontSize = 16},
        new() { Text = "Album Artist\t: "           ,FontFamily=MainWindowStatic.FontFamily, FontSize = 16},
        new() { Text = "Year\t\t: "                 ,FontFamily=MainWindowStatic.FontFamily, FontSize = 16},
        new() { Text = "Genre\t\t: "                ,FontFamily=MainWindowStatic.FontFamily, FontSize = 16},
        new() { Text = "Created by Ichimaki Kasura" ,FontFamily=MainWindowStatic.FontFamily, FontSize = 12}
    };
    internal List<TextBox> TEXTBOX_LIST = new();

    internal TextBox Metadata_Title;
    internal TextBox Metadata_Album;
    internal TextBox Metadata_Album_Artist;
    internal TextBox Metadata_Year;
    internal TextBox Metadata_Genre;

    internal Button Button_Set;
    internal Button Button_Cancel;

    private bool _contentLoad;
    public void InitializeComponent()
    {
        if(_contentLoad)
            return;

        _contentLoad = true;
        
        // Setup window
        Title                   = "Launcher DL -METADATA EDIT-";
        Height                  = 230;
        Width                   = 440;
        ResizeMode              = ResizeMode.NoResize;
        WindowStartupLocation   = WindowStartupLocation.CenterScreen;

        // Add Canvas
        AddChild(MetadataWindowCanvas = new());

        // Adds the Controls to canvas
        SetupControls();

        MetadataWidowInitialized();

        // Show window as a dialog so
        // the MainWindow is untouchable or idk
        ShowDialog();
    }

    private void SetupControls()
    {
        for(int i=0;i<5;i++)
            TEXTBOX_LIST.Add(new() { Height = 22, Width = 265, Foreground = Brushes.Gray, FontStyle = FontStyles.Italic });

        #region Metadata
        Metadata_Title          = TEXTBOX_LIST[METADATA_TITLE];
        Metadata_Album          = TEXTBOX_LIST[METADATA_ALBUM];
        Metadata_Album_Artist   = TEXTBOX_LIST[METADATA_ALBUM_ARTIST];
        Metadata_Year           = TEXTBOX_LIST[METADATA_YEAR];
        Metadata_Genre          = TEXTBOX_LIST[METADATA_GENRE];

        Metadata_Title.Uid          = "Title (e.g: 21, Nichiyoubi etc..) ";
        Metadata_Album.Uid          = "Album (e.g: RED, Tegami etc..) ";
        Metadata_Album_Artist.Uid   = "Album Artist (e.g: Taylor Swift, Back Number etc..) ";
        Metadata_Year.Uid           = "Year (e.g: 2003, 2013, 2023 etc..) ";
        Metadata_Genre.Uid          = "Genre (e.g: JPOP, KPOP, ROCK etc..) ";
        #endregion

        Button_Set      = new() { Content = "Set"    , Height = 25, Width = 100};
        Button_Cancel   = new() { Content = "Cancel" , Height = 25, Width = 100};
        Button_Set.Click    += MetadataSet;
        Button_Cancel.Click += (s,e) => Close();

        SetCanvasPlacement();

        AddToCanvas(Button_Set);
        AddToCanvas(Button_Cancel);

        foreach(TextBlock Controls in LABEL_LIST)
            AddToCanvas(Controls);

        foreach(TextBox Controls in TEXTBOX_LIST)
        {
            Controls.Text = Controls.Uid;
            Controls.GotFocus += TextBoxFocused;
            Controls.LostFocus += TextBoxUnFocused;
            AddToCanvas(Controls);
        }
    }

    private void SetCanvasPlacement()
    {
        #region Label Placements
        SetCanvas(LABEL_LIST[METADATA_TITLE]        ,    2, 10);
        SetCanvas(LABEL_LIST[METADATA_ALBUM]        ,   30, 10);
        SetCanvas(LABEL_LIST[METADATA_ALBUM_ARTIST] ,   58, 10);
        SetCanvas(LABEL_LIST[METADATA_YEAR]         ,   86, 10);
        SetCanvas(LABEL_LIST[METADATA_GENRE]        ,  114, 10);
        SetCanvas(LABEL_LIST[METADATA_LABEL]        ,  160, 10);
        #endregion

        #region Textbox Placements
        SetCanvas(Metadata_Title        ,    6, 149);
        SetCanvas(Metadata_Album        ,   34, 149);
        SetCanvas(Metadata_Album_Artist ,   62, 149);
        SetCanvas(Metadata_Year         ,   90, 149);
        SetCanvas(Metadata_Genre        ,  118, 149);
        #endregion

        #region Button Placements
        SetCanvas(Button_Set    ,   150,200);
        SetCanvas(Button_Cancel ,   150,314);
        #endregion
    }

    void SetCanvas(UIElement Element, double Top, double Left)
    {
        Canvas.SetTop(Element, Top);
        Canvas.SetLeft(Element, Left);
    }

    void AddToCanvas(UIElement Element) =>
        MetadataWindowCanvas.Children.Add(Element);
}