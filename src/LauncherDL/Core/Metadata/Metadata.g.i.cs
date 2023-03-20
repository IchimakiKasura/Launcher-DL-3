namespace LauncherDL.Core.Metadata;

// Bro literally created his own shit without xaml ☠️☠️
// I like it more chaotic
public partial class MetadataWindow
{
    internal Canvas MetadataWindowCanvas;
    internal TextBox Metadata_Title;
    internal TextBox Metadata_Album;
    internal TextBox Metadata_Album_Artist;
    internal TextBox Metadata_Year;
    internal TextBox Metadata_Genre;

    internal Button Button_Set;
    internal Button Button_Cancel;

    internal List<TextBlock> LABEL_LIST = new()
    {
        new() { Text = LABEL_TITLE          },
        new() { Text = LABEL_ALBUM          },
        new() { Text = LABEL_ALBUM_ARTIST   },
        new() { Text = LABEL_YEAR           },
        new() { Text = LABEL_GENRE          },
        new() { Text = LABEL_CREATOR        }
    };
    internal List<TextBox> TEXTBOX_LIST = new();

    private bool _contentLoad;
    public void InitializeComponent()
    {
        if(_contentLoad)
            return;

        _contentLoad = true;
        
        // Setup window
        Title                   = LABEL_WINDOW_TITLE;
        Height                  = 230;
        Width                   = 440;
        ResizeMode              = ResizeMode.NoResize;
        WindowStartupLocation   = WindowStartupLocation.CenterScreen;

        // Add Canvas
        AddChild(MetadataWindowCanvas = new());

        // Adds the Controls to canvas
        SetupControls();
        
        EventHandlers();
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

        Metadata_Title.Uid          = PLACEHOLDER_TITLE;
        Metadata_Album.Uid          = PLACEHOLDER_ALBUM;
        Metadata_Album_Artist.Uid   = PLACEHOLDER_ALBUM_ARTIST;
        Metadata_Year.Uid           = PLACEHOLDER_YEAR;
        Metadata_Genre.Uid          = PLACEHOLDER_GENRE;
        #endregion

        Button_Set      = new() { Content = BUTTON_SET    , Height = 25, Width = 100};
        Button_Cancel   = new() { Content = BUTTON_CANCEL , Height = 25, Width = 100};

        SetCanvasPlacement();

        AddToCanvas(Button_Set);
        AddToCanvas(Button_Cancel);

        foreach(TextBlock Controls in LABEL_LIST)
        {
            Controls.FontFamily = MainWindowStatic.FontFamily;
            Controls.FontSize = 16;

            if(Controls.Text is LABEL_CREATOR)
                Controls.FontSize = 12;

            AddToCanvas(Controls);
        }

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
        SetCanvas(LABEL_LIST[METADATA_TITLE       ] ,   2, 10);
        SetCanvas(LABEL_LIST[METADATA_ALBUM       ] ,  30, 10);
        SetCanvas(LABEL_LIST[METADATA_ALBUM_ARTIST] ,  58, 10);
        SetCanvas(LABEL_LIST[METADATA_YEAR        ] ,  86, 10);
        SetCanvas(LABEL_LIST[METADATA_GENRE       ] , 114, 10);
        SetCanvas(LABEL_LIST[METADATA_LABEL       ] , 160, 10);
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
        MetadataWindowCanvas.Add(Element);

    void EventHandlers()
    {
        Button_Set.Click        += MetadataSet;
        Button_Cancel.Click     += (s,e) => Close();
    }

    protected override void OnClosing(System.ComponentModel.CancelEventArgs e) =>
        IsWindowOpen = false;

}