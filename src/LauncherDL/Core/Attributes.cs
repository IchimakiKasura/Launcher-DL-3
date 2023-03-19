namespace LauncherDL.Core;

// I don't know how attributes work
// anyway I suck at this.

public enum MainWindowElement
{
    Minimize,
    CloseButton,
    buttonFileFormat,
    buttonDownload,
    buttonUpdate,
    buttonOpenFile,
    buttonMetadata,
    windowDrag,
    windowInnerBG,
    console,
    textBoxLink,
    textBoxName,
    windowCanvas,
    comboBoxType,
    comboBoxFormat,
    textBlockLink,
    textBlockFormat,
    textBlockName,
    textBlockType,
    TaskbarProgressBar
}

[AttributeUsage(AttributeTargets.Property)]
public class MainWindowStaticMemberAttribute : Attribute
{
    public MainWindowElement Element;
    public MainWindowStaticMemberAttribute(MainWindowElement _Element) =>
        Element = _Element;
}

public class SetAttributes
{
    public static void Add(MainWindow _)
    {
        MainWindowStatic = _;
        
        foreach(var ControlProperty in typeof(MainWindowStaticControls).GetProperties())
        {
            var AttributeElement = ControlProperty.GetCustomAttribute<MainWindowStaticMemberAttribute>();

            if(AttributeElement != null)
                switch(AttributeElement.Element)
                {
                    case MainWindowElement.Minimize          : Minimize           = _._Minimize;           break;       
                    case MainWindowElement.CloseButton       : CloseButton        = _._CloseButton;        break;       
                    case MainWindowElement.buttonFileFormat  : buttonFileFormat   = _._buttonFileFormat;   break;       
                    case MainWindowElement.buttonDownload    : buttonDownload     = _._buttonDownload;     break;       
                    case MainWindowElement.buttonUpdate      : buttonUpdate       = _._buttonUpdate;       break;       
                    case MainWindowElement.buttonOpenFile    : buttonOpenFile     = _._buttonOpenFile;     break;       
                    case MainWindowElement.buttonMetadata    : buttonMetadata     = _._buttonMetadata;     break;       
                    case MainWindowElement.windowDrag        : windowDrag         = _._windowDrag;         break;       
                    case MainWindowElement.windowInnerBG     : windowInnerBG      = _._windowInnerBG;      break;       
                    case MainWindowElement.console           : console            = _._console;            break;       
                    case MainWindowElement.textBoxLink       : textBoxLink        = _._textBoxLink;        break;       
                    case MainWindowElement.textBoxName       : textBoxName        = _._textBoxName;        break;       
                    case MainWindowElement.windowCanvas      : windowCanvas       = _._windowCanvas;       break;       
                    case MainWindowElement.comboBoxType      : comboBoxType       = _._comboBoxType;       break;       
                    case MainWindowElement.comboBoxFormat    : comboBoxFormat     = _._comboBoxFormat;     break;       
                    case MainWindowElement.textBlockLink     : textBlockLink      = _._textBlockLink;      break;       
                    case MainWindowElement.textBlockFormat   : textBlockFormat    = _._textBlockFormat;    break;       
                    case MainWindowElement.textBlockName     : textBlockName      = _._textBlockName;      break;       
                    case MainWindowElement.textBlockType     : textBlockType      = _._textBlockType;      break;       
                    case MainWindowElement.TaskbarProgressBar: TaskbarProgressBar = _._TaskbarProgressBar; break;       
                }
        }
    }
}