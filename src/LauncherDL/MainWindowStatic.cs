namespace LauncherDL;

public partial class MainWindow
{
    [MainWindowStaticMember]
    [ToolTipTexts("Minimize Window")]
    public static   Button                          Minimize            { get; set; }

    [MainWindowStaticMember]
    [ToolTipTexts("Close Window")]
    public static   Button                          CloseButton         { get; set; }

    [MainWindowStaticMember]
    [ToolTipTexts("Fetch File Formats")]
    public static   ButtonControl                   buttonFileFormat    { get; set; }

    [MainWindowStaticMember]
    [ToolTipTexts("Download")]
    public static   ButtonControl                   buttonDownload      { get; set; }

    [MainWindowStaticMember]
    [ToolTipTexts("Update yt-dlp")]
    public static   ButtonControl                   buttonUpdate        { get; set; }

    [MainWindowStaticMember]
    [ToolTipTexts("Open File")]
    public static   ButtonControl                   buttonOpenFile      { get; set; }
    
    [MainWindowStaticMember]
    [ToolTipTexts("Edit Metadata")]
    public static   ButtonControl                   buttonMetadata      { get; set; }

    [MainWindowStaticMember]
    public static   Border                          windowDrag          { get; set; }

    [MainWindowStaticMember]
    public static   Border                          windowInnerBG       { get; set; }

    public static   ProgressBarControl              progressBar         { get; set; }

    [MainWindowStaticMember]
    [ToolTipTexts("Console Output")]
    public static   ConsoleControl                  console             { get; set; }

    [MainWindowStaticMember]
    [ToolTipTexts("Input Link")]
    public static   TextBoxControl                  textBoxLink         { get; set; }

    [MainWindowStaticMember]
    [ToolTipTexts("Input Name")]
    public static   TextBoxControl                  textBoxName         { get; set; }

    [MainWindowStaticMember]
    public static   Canvas                          windowCanvas        { get; set; }

    [MainWindowStaticMember]
    [ToolTipTexts("Select a type of download")]
    public static   ComboBoxControl                 comboBoxType        { get; set; }

    [MainWindowStaticMember]
    [ToolTipTexts("Select or Input Format")]
    public static   ComboBoxControl                 comboBoxFormat      { get; set; }

    [ToolTipTexts("Select Quality")]
    public static   ComboBoxControl                 comboBoxQuality     { get; set; } = new()
    {
        Width = 154,
        TextEditable = false,
    };


    [MainWindowStaticMember]
    public static   TextBlockControl                textBlockLink       { get; set; }

    [MainWindowStaticMember]
    public static   TextBlockControl                textBlockFormat     { get; set; }

    [MainWindowStaticMember]
    public static   TextBlockControl                textBlockName       { get; set; }

    [MainWindowStaticMember]
    public static   TextBlockControl                textBlockType       { get; set; }
    
    [MainWindowStaticMember]
    public static   TaskbarItemInfo                 TaskbarProgressBar  { get; set; }

    void InitiateStaticComponents(MainWindow _)
    {
        MainWindowStatic = _;

        //// Idk about these
        /**/VisualBitmapScalingMode = BitmapScalingMode.LowQuality;
        /**/MediaTimeline.DesiredFrameRateProperty.OverrideMetadata(typeof(System.Windows.Media.Animation.Timeline), new FrameworkPropertyMetadata(60));
        ////

        BindingFlags MainWindowFieldFlags = BindingFlags.Instance|BindingFlags.Public|BindingFlags.CreateInstance|BindingFlags.NonPublic;

        foreach(var MainWindowField in typeof(MainWindow).GetMembers())
        {
            var MainWindowStaticAttribute = MainWindowField.GetCustomAttribute<MainWindowStaticMemberAttribute>();
            var ToolTipTextAttribute = MainWindowField.GetCustomAttribute<ToolTipTextsAttribute>();
            var Name = MainWindowField.Name;

            // Sets all static properties
            if(MainWindowStaticAttribute is not null)
                MainWindowStaticAttribute.SetValue(Name, MainWindowFieldFlags, MainWindowField);

            // Sets all Tooltips
            if(ToolTipTextAttribute is not null)
                ToolTipTextAttribute.SetToolTipText(Name, ToolTipTextAttribute.Description, MainWindowFieldFlags);
        }
    }
}