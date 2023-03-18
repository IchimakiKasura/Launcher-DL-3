namespace LauncherDL;

public partial class MainWindow
{
    #region Static Controls

    public static   Button                  Minimize            { get; set; }
    public static   Button                  CloseButton         { get; set; }

    public static   ButtonControl           buttonFileFormat    { get; set; }
    public static   ButtonControl           buttonDownload      { get; set; }
    public static   ButtonControl           buttonUpdate        { get; set; }
    public static   ButtonControl           buttonOpenFile      { get; set; }
    public static   ButtonControl           buttonMetadata      { get; set; }

    public static   Border                  windowDrag          { get; set; }
    public static   Border                  windowInnerBG       { get; set; }

    public static   ProgressBarControl      progressBar         { get; set; }
    public static   ConsoleControl          console             { get; set; }

    public static   TextBoxControl          textBoxLink         { get; set; }
    public static   TextBoxControl          textBoxName         { get; set; }

    public static   Canvas                  windowCanvas        { get; set; }

    public static   ComboBoxControl         comboBoxType        { get; set; }
    public static   ComboBoxControl         comboBoxFormat      { get; set; }
    public static   ComboBoxControl         comboBoxQuality     { get; set; } = new()
    {
        Width = 154,
        TextEditable = false,
    };

    public static   TextBlockControl        textBlockLink       { get; set; }
    public static   TextBlockControl        textBlockFormat     { get; set; }
    public static   TextBlockControl        textBlockName       { get; set; }
    public static   TextBlockControl        textBlockType       { get; set; }
    
    public static   TaskbarItemInfo         TaskbarProgressBar  { get; set; }

    #endregion

    void InitiateStaticComponents(MainWindow mainwindow)
    {
        MainWindowStatic = mainwindow;

        //// Idk about these
        /**/VisualBitmapScalingMode = BitmapScalingMode.LowQuality;
        /**/MediaTimeline.DesiredFrameRateProperty.OverrideMetadata(typeof(System.Windows.Media.Animation.Timeline), new FrameworkPropertyMetadata(60));
        ////	

        Minimize             =   _Minimize;
        CloseButton          =   _CloseButton;

        buttonFileFormat     =   _buttonFileFormat;
        buttonDownload       =   _buttonDownload;
        buttonUpdate         =   _buttonUpdate;
        buttonOpenFile       =   _buttonOpenFile;
        buttonMetadata       =   _buttonMetadata;

        windowDrag           =   _windowDrag;
        windowInnerBG        =   _windowInnerBG;

        console              =   _console;

        textBoxLink          =   _textBoxLink;
        textBoxName          =   _textBoxName;

        windowCanvas         =   _windowCanvas;

        comboBoxType         =   _comboBoxType;
        comboBoxFormat       =   _comboBoxFormat;

        textBlockLink        =   _textBlockLink;
        textBlockFormat      =   _textBlockFormat;
        textBlockName        =   _textBlockName;
        textBlockType        =   _textBlockType;

        TaskbarProgressBar   =   _TaskbarProgressBar;
    }

}