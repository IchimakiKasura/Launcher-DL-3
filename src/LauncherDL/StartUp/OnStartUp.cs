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

        InitiateProgressBar();

        ConsoleOutputMethod.StartUpOutputComments();

        WindowsComponents.WindowTaskBarFlash();
    }

    private static void InitiateContextMenu()
    {
        ContextMenuResource.Link    =   textBoxLink;
        ContextMenuResource.Format  =   comboBoxFormat;
        ContextMenuResource.Name    =   textBoxName;
        
        ContextMenuResource.CONTEXTMENU_configDefaultDirectory = FolderButton.FolderDirectory();
    }

    private static void InitializeTextBoxComponents()
    {
        textBoxLink.TextPlaceholderAlignment = 
        textBoxName.TextPlaceholderAlignment = HorizontalAlignment.Center;

        textBoxLink.FontSize = 
        textBoxName.FontSize = 22;

        textBoxLink.Height =
        textBoxName.Height = 35;
    }
}
