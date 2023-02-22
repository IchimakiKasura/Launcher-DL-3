namespace Launcher_DL;

public partial class MainWindow
{
	void InitiateStaticComponents()
	{
		//// Idk about these
		/**/VisualBitmapScalingMode = BitmapScalingMode.LowQuality;
		/**/MediaTimeline.DesiredFrameRateProperty.OverrideMetadata(typeof(System.Windows.Media.Animation.Timeline), new FrameworkPropertyMetadata(90));
		////	

		Global.Minimize = Minimize;
		Global.CloseButton = CloseButton;

		Global.buttonFileFormat = buttonFileFormat;
		Global.buttonDownload = buttonDownload;
		Global.buttonUpdate = buttonUpdate;
		Global.buttonOpenFile = buttonOpenFile;

		Global.windowDrag = windowDrag;
		Global.windowInnerBG = windowInnerBG;

		Global.progressBar = progressBar;
		Global.console = console;

		Global.textBoxLink = textBoxLink;
		Global.textBoxFormat= textBoxFormat;
		Global.textBoxName= textBoxName;

	}
}