namespace Launcher_DL.StartUp;

partial class OnStartUp
{
	private static void InitializeButtonsComponents()
	{
		// Button Background
		buttonFileFormat.Image = AkiraImage;
		buttonDownload.Image = AstolfoImage;
		buttonUpdate.Image = VentiImage;
		buttonOpenFile.Image = MeguminImage;

		// Button Icons
		buttonFileFormat.Icon = FileFormatIcon;
		buttonDownload.Icon = DownloadIcon;
		buttonUpdate.Icon = UpdateIcon;
		buttonOpenFile.Icon = OpenFileIcon;

		// Button Border Color Effect
		buttonFileFormat.BorderEffect = Colors.Blue;
		buttonDownload.BorderEffect = Colors.Pink;
		buttonUpdate.BorderEffect = Colors.Aqua;
		buttonOpenFile.BorderEffect = Colors.Red;

		// Button Icon Heights
		buttonFileFormat.IconHeight =
		buttonUpdate.IconHeight =
		buttonOpenFile.IconHeight = 35;

		// Button Storyboards
		buttonFileFormat.IsAnimationOn =
		buttonDownload.IsAnimationOn =
		buttonUpdate.IsAnimationOn =
		buttonOpenFile.IsAnimationOn = config.EpicAnimations;

	}
}