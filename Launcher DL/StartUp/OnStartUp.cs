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

		// Button Margin
		buttonFileFormat.Margin = new(24,155,556,261);
		buttonDownload.Margin = new(24,231,556,183);
		buttonUpdate.Margin = new(24,309,556,105);
		buttonOpenFile.Margin = new(24,387,556,29);

		// Button Icon Heights
		buttonFileFormat.IconHeight = 
		buttonUpdate.IconHeight = 
		buttonOpenFile.IconHeight = 35;
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
		// Adjust TextBox Canvas Positions
		Canvas.SetLeft(textBoxLink, 415);
		Canvas.SetLeft(textBoxFormat, 415);
		Canvas.SetLeft(textBoxName, 415);
		Canvas.SetTop(textBoxLink, 67);
		Canvas.SetTop(textBoxFormat, 117);
		Canvas.SetTop(textBoxName, 171);
		
		textBoxLink.TextPlaceholderAlignment = HorizontalAlignment.Center;
		textBoxFormat.TextPlaceholderAlignment = HorizontalAlignment.Center;
		textBoxName.TextPlaceholderAlignment = HorizontalAlignment.Center;
	}
}
