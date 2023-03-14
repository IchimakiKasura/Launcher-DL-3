namespace LauncherDL;

public partial class MainWindow
{
    void InitiateStaticComponents(MainWindow mainwindow)
    {
        MainWindowStatic = mainwindow;

        //// Idk about these
        /**/VisualBitmapScalingMode = BitmapScalingMode.LowQuality;
        /**/MediaTimeline.DesiredFrameRateProperty.OverrideMetadata(typeof(System.Windows.Media.Animation.Timeline), new FrameworkPropertyMetadata(60));
        ////	

        Global.Minimize             =   mainwindow.Minimize;
        Global.CloseButton          =   mainwindow.CloseButton;

        Global.buttonFileFormat     =   mainwindow.buttonFileFormat;
        Global.buttonDownload       =   mainwindow.buttonDownload;
        Global.buttonUpdate         =   mainwindow.buttonUpdate;
        Global.buttonOpenFile       =   mainwindow.buttonOpenFile;

        Global.windowDrag           =   mainwindow.windowDrag;
        Global.windowInnerBG        =   mainwindow.windowInnerBG;

        Global.console              =   mainwindow.console;

        Global.textBoxLink          =   mainwindow.textBoxLink;
        Global.textBoxName          =   mainwindow.textBoxName;

        Global.windowCanvas         =   mainwindow.windowCanvas;

        Global.comboBoxType         =   mainwindow.comboBoxType;
        Global.comboBoxFormat       =   mainwindow.comboBoxFormat;

        Global.textBlockLink        =   mainwindow.textBlockLink;
        Global.textBlockFormat      =   mainwindow.textBlockFormat;
        Global.textBlockName        =   mainwindow.textBlockName;
        Global.textBlockType        =   mainwindow.textBlockType;
    }

}