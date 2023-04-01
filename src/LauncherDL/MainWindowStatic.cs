namespace LauncherDL;

public partial class MainWindow
{
    [MainWindowStaticMember, ToolTipTexts("Minimize Window")]
    public static   Button                          Minimize                { get; set; }

    [MainWindowStaticMember, ToolTipTexts("Close Window")]
    public static   Button                          CloseButton             { get; set; }

    [ToolTipTexts("Open downloaded files")]
    public static   Button                          ButtonOpenFolder        { get; set; }

    [MainWindowStaticMember, ToolTipTexts("Fetch File Formats")]
    public static   ButtonControl                   buttonFileFormat        { get; set; }

    [MainWindowStaticMember, ToolTipTexts("Download")]
    public static   ButtonControl                   buttonDownload          { get; set; }

    [MainWindowStaticMember, ToolTipTexts("Update yt-dlp")]
    public static   ButtonControl                   buttonUpdate            { get; set; }

    [MainWindowStaticMember, ToolTipTexts("Open File")]
    public static   ButtonControl                   buttonOpenFile          { get; set; }
    
    [MainWindowStaticMember, ToolTipTexts("Edit Metadata")]
    public static   ButtonControl                   buttonMetadata          { get; set; }

    [MainWindowStaticMember]
    public static   Border                          windowDrag              { get; set; }

    [MainWindowStaticMember]
    public static   Border                          windowInnerBG           { get; set; }

    public static   ProgressBarControl              progressBar             { get; set; }

    [MainWindowStaticMember, ToolTipTexts("Console Output")]
    public static   ConsoleControl                  console                 { get; set; }

    [MainWindowStaticMember, ToolTipTexts("Input Link")]
    public static   TextBoxControl                  textBoxLink             { get; set; }

    [MainWindowStaticMember, ToolTipTexts("Input Name")]
    public static   TextBoxControl                  textBoxName             { get; set; }

    [MainWindowStaticMember]
    public static   Canvas                          windowCanvas            { get; set; }

    [MainWindowStaticMember, ToolTipTexts("Select a type of download")]
    public static   ComboBoxControl                 comboBoxType            { get; set; }

    [MainWindowStaticMember, ToolTipTexts("Select or Input Format")]
    public static   ComboBoxControl                 comboBoxFormat          { get; set; }

    [ToolTipTexts("Select Quality")]
    public static   ComboBoxControl                 comboBoxQuality         { get; set; }


    [MainWindowStaticMember]
    public static   TextBlockControl                textBlockLink           { get; set; }

    [MainWindowStaticMember]
    public static   TextBlockControl                textBlockFormat         { get; set; }

    [MainWindowStaticMember]
    public static   TextBlockControl                textBlockName           { get; set; }

    [MainWindowStaticMember]
    public static   TextBlockControl                textBlockType           { get; set; }
    
    [MainWindowStaticMember]
    public static   TaskbarItemInfo                 TaskbarProgressBar      { get; set; }
    
    [MainWindowStaticMember]
    public static   TextBlock                       textBlockFooter         { get; set; }

    [MainWindowStaticMember]
    public static   ImageBrush                      windowBackgroundImage   { get; set; }

    [MainWindowStaticMember]
    public static   DropShadowEffect                windowDropShadow        { get; set; }

    void InitiateStaticComponents(MainWindow _)
    {
        MainWindowStatic = _;

        //// Idk about these
        /**/VisualBitmapScalingMode = BitmapScalingMode.LowQuality;
        /**/MediaTimeline.DesiredFrameRateProperty.OverrideMetadata(typeof(System.Windows.Media.Animation.Timeline), new FrameworkPropertyMetadata(60));
        ////

        comboBoxQuality = new()
        {
            Width = 154,
            TextEditable = false,
        };

        ButtonOpenFolder = new()
        {
            Height = 25,
            Width = 100,
            Style = GetResources<Style>("MetadataButtons"),
            ContextMenu = GetResources<ContextMenu>("OpenFolderCM")
        };
        
        // "None" style has no minimize animation
        WindowStyle = WindowStyle.SingleBorderWindow;

        MainWindowStaticMemberAttribute.InitiateAttribute<MainWindow>();
        ToolTipTextsAttribute.InitiateAttribute<MainWindow>();
        FilePathAttribute.InitiateAttribute<Global>();
    }
}