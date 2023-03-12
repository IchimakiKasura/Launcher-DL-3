namespace LauncherDL.StartUp;
partial class OnStartUp
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

		InitializeComboBoxComponents();

		InitiateContextMenu();

		ConsoleOutputMethod.StartUpOutputComments();

		progressBar = new() { Width = 502 };
		Canvas.SetLeft(progressBar, 300);
		Canvas.SetTop(progressBar, 434);

		GC.Collect();
		
	}

	private static void InitiateContextMenu()
	{
		ContextMenuResource.Link    =   textBoxLink;
		ContextMenuResource.Format  =   comboBoxFormat;
		ContextMenuResource.Name    =   textBoxName;
	}

	private static void InitializeTextBoxComponents()
	{		
		textBoxLink.TextPlaceholderAlignment = 
		textBoxName.TextPlaceholderAlignment = HorizontalAlignment.Center;
	}
}
