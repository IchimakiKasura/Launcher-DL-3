namespace LauncherDL.Core;

public class MainWindowStaticControls
{
    [MainWindowStaticMember(MainWindowElement.Minimize)]
    public static   Button                          Minimize            { get; set; }

    [MainWindowStaticMember(MainWindowElement.CloseButton)]
    public static   Button                          CloseButton         { get; set; }

    [MainWindowStaticMember(MainWindowElement.buttonFileFormat)]
    public static   ButtonControl                   buttonFileFormat    { get; set; }

    [MainWindowStaticMember(MainWindowElement.buttonDownload)]
    public static   ButtonControl                   buttonDownload      { get; set; }

    [MainWindowStaticMember(MainWindowElement.buttonUpdate)]
    public static   ButtonControl                   buttonUpdate        { get; set; }

    [MainWindowStaticMember(MainWindowElement.buttonOpenFile)]
    public static   ButtonControl                   buttonOpenFile      { get; set; }
    
    [MainWindowStaticMember(MainWindowElement.buttonMetadata)]
    public static   ButtonControl                   buttonMetadata      { get; set; }

    [MainWindowStaticMember(MainWindowElement.windowDrag)]
    public static   Border                          windowDrag          { get; set; }

    [MainWindowStaticMember(MainWindowElement.windowInnerBG)]
    public static   Border                          windowInnerBG       { get; set; }

    public static   ProgressBarControl              progressBar         { get; set; }

    [MainWindowStaticMember(MainWindowElement.console)]
    public static   ConsoleControl                  console             { get; set; }

    [MainWindowStaticMember(MainWindowElement.textBoxLink)]
    public static   TextBoxControl                  textBoxLink         { get; set; }

    [MainWindowStaticMember(MainWindowElement.textBoxName)]
    public static   TextBoxControl                  textBoxName         { get; set; }

    [MainWindowStaticMember(MainWindowElement.windowCanvas)]
    public static   Canvas                          windowCanvas        { get; set; }

    [MainWindowStaticMember(MainWindowElement.comboBoxType)]
    public static   ComboBoxControl                 comboBoxType        { get; set; }

    [MainWindowStaticMember(MainWindowElement.comboBoxFormat)]
    public static   ComboBoxControl                 comboBoxFormat      { get; set; }

    public static   ComboBoxControl                 comboBoxQuality     { get; set; } = new()
    {
        Width = 154,
        TextEditable = false,
    };

    [MainWindowStaticMember(MainWindowElement.textBlockLink)]
    public static   TextBlockControl                textBlockLink       { get; set; }

    [MainWindowStaticMember(MainWindowElement.textBlockFormat)]
    public static   TextBlockControl                textBlockFormat     { get; set; }

    [MainWindowStaticMember(MainWindowElement.textBlockName)]
    public static   TextBlockControl                textBlockName       { get; set; }

    [MainWindowStaticMember(MainWindowElement.textBlockType)]
    public static   TextBlockControl                textBlockType       { get; set; }
    
    [MainWindowStaticMember(MainWindowElement.TaskbarProgressBar)]
    public static   TaskbarItemInfo                 TaskbarProgressBar  { get; set; }

}