namespace Launcher_DL;

public partial class MainWindow
{
	void InitiateStaticComponents(MainWindow mainwindow)
	{
		MainWindowStatic = mainwindow;

		//// Idk about these
		/**/VisualBitmapScalingMode = BitmapScalingMode.LowQuality;
		/**/MediaTimeline.DesiredFrameRateProperty.OverrideMetadata(typeof(System.Windows.Media.Animation.Timeline), new FrameworkPropertyMetadata(60));
		////	

		Global.Minimize = Minimize;
		Global.CloseButton = CloseButton;

		Global.buttonFileFormat = buttonFileFormat;
		Global.buttonDownload = buttonDownload;
		Global.buttonUpdate = buttonUpdate;
		Global.buttonOpenFile = buttonOpenFile;

		Global.windowDrag = windowDrag;
		Global.windowInnerBG = windowInnerBG;

		Global.console = console;

		Global.textBoxLink = textBoxLink;
		Global.textBoxName= textBoxName;

		Global.windowCanvas = windowCanvas;

		Global.comboBoxType = comboBoxType;
		Global.comboBoxFormat = comboBoxFormat;

		Global.textBlockLink = textBlockLink;
		Global.textBlockFormat = textBlockFormat;
		Global.textBlockName = textBlockName;
		Global.textBlockType = textBlockType;

	}
}