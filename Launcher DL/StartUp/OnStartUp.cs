namespace Launcher_DL.StartUp;

class OnStartUp
{
	// Initializes all the values for XAML
	// (Avoiding too much shit on the XAML to look the clean)
	public static void Initialize()
	{
		InitializeLanguage();

		EventHandlers.InitializeEventHandlers();
		WindowsComponents.WindowFocusAnimation();

		InitializeButtonsComponents();

		InitializeTextBoxComponents();

		InitiateComboBoxComponents();

		InitiateContextMenu();

		ConsoleOutputMethod.StartUpOutputComments();

		Canvas.SetLeft(progressBar, 300);
		Canvas.SetTop(progressBar, 434);

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
		ContextMenuResource.Format = comboBoxFormat;
		ContextMenuResource.Name = textBoxName;
	}

	private static void InitializeTextBoxComponents()
	{		
		textBoxLink.TextPlaceholderAlignment = 
		textBoxName.TextPlaceholderAlignment = HorizontalAlignment.Center;
	}

	private static async void InitiateComboBoxComponents()
	{
		Canvas.SetTop(comboBoxType, 89);

		await WindowsComponents.WindowAwaitLoad(comboBoxType.IsLoaded);

		comboBoxType.ItemIndex = config.DefaultFileTypeOnStartUp;
		comboBoxType.ContentAlignment = HorizontalAlignment.Center;
		comboBoxType.ShowVerticalScrollbar = false;

		comboBoxType.ItemsAdd();
	}

	private static void InitializeLanguage()
	{
		Language = new(config.Language);

		// Buttons
		buttonFileFormat.Text = Language.Button_Format;
		buttonDownload.Text = Language.Button_Download;
		buttonUpdate.Text = Language.Button_Update;
		buttonOpenFile.Text = Language.Button_OpenFile;

		// Placeholders
		textBoxLink.TextPlaceholder = Language.Placeholder_Link;
		comboBoxFormat.PlaceholderText = $"\"Best\"";
		textBoxName.TextPlaceholder = Language.Placeholder_Optional;

		// ComboBox
		comboBoxType.ComboBoxTypes[0].Content = Language.Types_Custom;
		comboBoxType.ComboBoxTypes[1].Content = Language.Types_Video;
		comboBoxType.ComboBoxTypes[2].Content = Language.Types_Audio;
		comboBoxType.ComboBoxTypes[3].Content = Language.Types_Convert;

		textBlockLink.Text = Language.Label_Link;
		textBlockFormat.Text = Language.Label_Format;
		textBlockName.Text = Language.Label_Name;
		textBlockType.Text = Language.Label_Type;
		
	}
}
