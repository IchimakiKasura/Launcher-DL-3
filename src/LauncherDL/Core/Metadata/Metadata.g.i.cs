namespace LauncherDL.Core.Metadata;

// Bro literally created his own shit without xaml ☠️☠️
// I like it more chaotic
public partial class MetadataWindow
{
    #region Window fields
    private Border MetadataRoundBorder;
    private Border MetadataDragBorder;
    private Canvas MetadataWindowCanvas;
    #endregion

    private ColorAnimation WindowAnimation;
    private DoubleAnimation  WindowOpacity;

    #region Window Controls
    [ToolTipTexts("Edit Title")]
    private TextBoxControl Metadata_Title;
    [ToolTipTexts("Edit Album")]
    private TextBoxControl Metadata_Album;
    [ToolTipTexts("Edit Artist")]
    private TextBoxControl Metadata_Album_Artist;
    [ToolTipTexts("Set the Year")]
    private TextBoxControl Metadata_Year;
    [ToolTipTexts("Edit Genre")]
    private TextBoxControl Metadata_Genre;
    [ToolTipTexts("Set the Metadata")]
    private Button Button_Set;
    [ToolTipTexts("Cancel Metadata")]
    private Button Button_Cancel;
    [ToolTipTexts("Close Window")]
    private Button Button_Exit;
    #endregion

    private List<TextBlock> LABEL_LIST = new()
    {
        new() { Text = LABEL_TITLE          },
        new() { Text = LABEL_ALBUM          },
        new() { Text = LABEL_ALBUM_ARTIST   },
        new() { Text = LABEL_YEAR           },
        new() { Text = LABEL_GENRE          },
        new() { Text = LABEL_CREATOR        }
    };
    private List<TextBoxControl> TEXTBOX_LIST = new();
    
    private bool _contentLoad;
    public void InitializeComponent()
    {
        if(_contentLoad)
            return;

        _contentLoad = true;
        MetadataWindowStatic = this;
        IsWindowOpen = true;

        #region Setup window

        Name                    = "MetadataRoot";
        Title                   = LABEL_WINDOW_TITLE;
        Height                  = 260;
        Width                   = 455;
        ResizeMode              = ResizeMode.CanMinimize;
        WindowStartupLocation   = WindowStartupLocation.CenterScreen;
        Background              = Brushes.Transparent;
        Effect                  = (Effect)MainWindowStatic.FindResource(WINDOW_RESOURCE_DROP_SHADOW);
        Resources               = MainWindowStatic.Resources;
        new WindowInteropHelper(this).EnsureHandle();
        new TransparencyConverter(this).MakeTransparent();

        #endregion

        #region Setup Top bar

        var _WindowChrome                   = new WindowChrome();
        _WindowChrome.GlassFrameThickness   = new(0);
        _WindowChrome.CornerRadius          = new(0);
        _WindowChrome.CaptionHeight         = 0;
        _WindowChrome.UseAeroCaptionButtons = false;
        _WindowChrome.ResizeBorderThickness = new(7);
        WindowChrome.SetWindowChrome(this, _WindowChrome);

        #endregion

        // Creates the Elements and its children 👀
        GenerateElements();
        
        // Adds the Controls to canvas
        SetupControls();
        
        // Setup the Events
        EventHandlers();

        // Setup the Tooltips
		ToolTipTextsAttribute.InitiateAttribute<MetadataWindow>();
    }

    private void SetupControls()
    {
        // TextBox background
        var TEXTBOX_Color = new SolidColorBrush();
        TEXTBOX_Color.Color = Colors.Black;
        TEXTBOX_Color.Opacity = 0.5;

        // Add Textbox as iteration
        for(int i=0;i<5;i++)
            TEXTBOX_LIST.Add(new() { Height = 22, Width = 265, TextPlaceholderFontSize = 10, FontSize = 11});

        // Did this for Placeholders
        #region Metadata
        Metadata_Title                          = TEXTBOX_LIST[METADATA_TITLE];
        Metadata_Album                          = TEXTBOX_LIST[METADATA_ALBUM];
        Metadata_Album_Artist                   = TEXTBOX_LIST[METADATA_ALBUM_ARTIST];
        Metadata_Year                           = TEXTBOX_LIST[METADATA_YEAR];
        Metadata_Genre                          = TEXTBOX_LIST[METADATA_GENRE];

        Metadata_Title.TextPlaceholder          = PLACEHOLDER_TITLE;
        Metadata_Album.TextPlaceholder          = PLACEHOLDER_ALBUM;
        Metadata_Album_Artist.TextPlaceholder   = PLACEHOLDER_ALBUM_ARTIST;
        Metadata_Year.TextPlaceholder           = PLACEHOLDER_YEAR;
        Metadata_Genre.TextPlaceholder          = PLACEHOLDER_GENRE;
        #endregion

        Button_Set          = new() { Content = BUTTON_SET    , Style = (Style)MainWindowStatic.FindResource(WINDOW_RESOURCE_BUTTONS)};
        Button_Cancel       = new() { Content = BUTTON_CANCEL , Style = (Style)MainWindowStatic.FindResource(WINDOW_RESOURCE_BUTTONS)};
        Button_Exit.Content = "✕";
        Button_Exit.Style   = (Style)MainWindowStatic.FindResource(WINDOW_RESOURCE_EXIT_BUTTON);
        Button_Exit.Margin  = new(this.Width - 70, 0,0,0);

        SetCanvasPlacement();

        AddToCanvas(Button_Set);
        AddToCanvas(Button_Cancel);

        foreach(TextBlock Controls in LABEL_LIST)
        {
            Controls.FontFamily = MainWindowStatic.FontFamily;
            Controls.FontSize = 16;
            Controls.Foreground = Brushes.White;

            if(Controls.Text is LABEL_CREATOR)
                Controls.FontSize = 12;

            AddToCanvas(Controls);
        }

        foreach(TextBoxControl Controls in TEXTBOX_LIST)
            AddToCanvas(Controls);
        
    }

    private void SetCanvasPlacement()
    {
        #region Label Placements
        SetCanvas(LABEL_LIST[METADATA_TITLE       ] ,  42, 16);
        SetCanvas(LABEL_LIST[METADATA_ALBUM       ] ,  70, 16);
        SetCanvas(LABEL_LIST[METADATA_ALBUM_ARTIST] ,  98, 16);
        SetCanvas(LABEL_LIST[METADATA_YEAR        ] , 126, 16);
        SetCanvas(LABEL_LIST[METADATA_GENRE       ] , 154, 16);
        SetCanvas(LABEL_LIST[METADATA_LABEL       ] , 210, 16);
        #endregion

        #region Textbox Placements
        SetCanvas(Metadata_Title        ,   44, 155);
        SetCanvas(Metadata_Album        ,   72, 155);
        SetCanvas(Metadata_Album_Artist ,  100, 155);
        SetCanvas(Metadata_Year         ,  128, 155);
        SetCanvas(Metadata_Genre        ,  156, 155);
        #endregion

        #region Button Placements
        SetCanvas(Button_Set    ,   196,204);
        SetCanvas(Button_Cancel ,   196,320);
        #endregion
    }
    
    void EventHandlers()
    {
        Button_Set.Click                += MetadataSet;
        Button_Exit.Click               += (s,e) => Close();
        Button_Cancel.Click             += (s,e) => Close();
        MetadataDragBorder.MouseDown    += (s,e) =>
        {
            if (e.ChangedButton is MouseButton.Left)
                DragMove();
        };

    }
    
    protected override void OnClosing(System.ComponentModel.CancelEventArgs e) =>
        IsWindowOpen = false;

}