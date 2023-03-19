namespace LauncherDL;

public partial class MainWindow
{
    [MainWindowStaticMember]
    public static   Button                          Minimize            { get; set; }

    [MainWindowStaticMember]
    public static   Button                          CloseButton         { get; set; }

    [MainWindowStaticMember]
    public static   ButtonControl                   buttonFileFormat    { get; set; }

    [MainWindowStaticMember]
    public static   ButtonControl                   buttonDownload      { get; set; }

    [MainWindowStaticMember]
    public static   ButtonControl                   buttonUpdate        { get; set; }

    [MainWindowStaticMember]
    public static   ButtonControl                   buttonOpenFile      { get; set; }
    
    [MainWindowStaticMember]
    public static   ButtonControl                   buttonMetadata      { get; set; }

    [MainWindowStaticMember]
    public static   Border                          windowDrag          { get; set; }

    [MainWindowStaticMember]
    public static   Border                          windowInnerBG       { get; set; }

    public static   ProgressBarControl              progressBar         { get; set; }

    [MainWindowStaticMember]
    public static   ConsoleControl                  console             { get; set; }

    [MainWindowStaticMember]
    public static   TextBoxControl                  textBoxLink         { get; set; }

    [MainWindowStaticMember]
    public static   TextBoxControl                  textBoxName         { get; set; }

    [MainWindowStaticMember]
    public static   Canvas                          windowCanvas        { get; set; }

    [MainWindowStaticMember]
    public static   ComboBoxControl                 comboBoxType        { get; set; }

    [MainWindowStaticMember]
    public static   ComboBoxControl                 comboBoxFormat      { get; set; }

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
            
            if(MainWindowStaticAttribute is null) continue;
            
            var Property = MainWindowStaticAttribute.GetProperty<MainWindow>($"_{MainWindowField.Name}", MainWindowFieldFlags);

            if(!Property.HasValue) continue;

            MainWindowStaticAttribute.SetValue<MainWindow>(MainWindowField, Property.Value);
        }
    }

}