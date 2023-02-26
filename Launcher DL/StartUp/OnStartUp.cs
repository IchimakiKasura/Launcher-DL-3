using DLLanguages;
using DLLanguages.Pick;
using System.Windows.Controls;

namespace Launcher_DL.StartUp;

class OnStartUp
{
	static List<ComboBoxItem> ComboBoxTypes = new List<ComboBoxItem>() { new(),new(),new(),new() };

	// Initializes all the values for XML
	// (Avoiding too much shit on the XML to look the clean)
	public static void Initialize()
	{
		InitializeLanguage();

		EventHandlers.InitializeEventHandlers();
		WindowsComponents.WindowFocusAnimation();

		InitializeButtonsComponents();
		InitializeTextBoxComponents();
		InitiateComboBoxComponents();
		InitializeTextBlockComponents();
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
		textBoxName.TextPlaceholder = Language.Placeholder_Optional;

		// ComboBox
		ComboBoxTypes[0].Content = Language.Types_Custom;
		ComboBoxTypes[1].Content = Language.Types_Video;
		ComboBoxTypes[2].Content = Language.Types_Audio;
		ComboBoxTypes[3].Content = Language.Types_Convert;
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

		ComboBox CBT = comboBoxType.UserControlMain;

		CBT.Width = comboBoxType.Width;
		CBT.SelectedIndex = config.DefaultFileTypeOnStartUp;
		CBT.HorizontalContentAlignment = HorizontalAlignment.Center;

		comboBoxFormat.UserControlMain.Width = comboBoxFormat.Width;

		ScrollViewer.SetVerticalScrollBarVisibility(CBT, ScrollBarVisibility.Disabled);

		foreach (var (value, index) in ComboBoxTypes.Select((value, i) => (value, i)))
		{
			ComboBoxTypes[index].Style = (Style)CBT.FindResource("DownloadType");
			comboBoxType.UserControlMain.Items.Add(ComboBoxTypes[index]);
		}
	}

	private static void InitializeTextBlockComponents()
	{
		textBlockLink.Style =
		textBlockFormat.Style =
		textBlockName.Style =
		textBlockType.Style = (Style)App.Current.FindResource("TextBlockResource");
	}
}
