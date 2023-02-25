using DLLanguages;
using DLLanguages.Pick;

namespace Launcher_DL.StartUp;

class OnStartUp
{
	// Initializes all the values for XML
	// (Avoiding too much shit on the XML to look the clean)
	public static void Initialize()
	{
		InitializeLanguage();

		EventHandlers.InitializeEventHandlers();
		WindowsComponents.WindowFocusAnimation();

		InitializeButtonsComponents();
		InitializeTextBoxComponents();
		InitiateContextMenu();

		ConsoleOutputMethod.StartUpOutputComments();

		GC.Collect();
	}

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

	private static void InitiateContextMenu()
	{
		ContextMenuResource.Link = textBoxLink;
		ContextMenuResource.Format = textBoxFormat;
		ContextMenuResource.Name = textBoxName;
	}

	private static void InitializeLanguage()
	{
		Language = new(config.Language);
		ShrinkFront.AutoShrink(config.Language);

		// Buttons
		buttonFileFormat.Text = Language.Button_Format;
		buttonDownload.Text = Language.Button_Download;
		buttonUpdate.Text = Language.Button_Update;
		buttonOpenFile.Text = Language.Button_OpenFile;

		// TextBox Placeholders
		textBoxLink.TextPlaceholder = Language.Placeholder_Link;
		// textBoxFormat.TextPlaceholder = Language.Placeholder_File;
		textBoxName.TextPlaceholder = Language.Placeholder_Optional;
	}

	private static void InitializeTextBoxComponents()
	{		
		textBoxLink.TextPlaceholderAlignment = 
		textBoxFormat.TextPlaceholderAlignment = 
		textBoxName.TextPlaceholderAlignment = HorizontalAlignment.Center;
	}
}
