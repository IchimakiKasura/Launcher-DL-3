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

        InitializeContextMenuComponents();

        InitiateProgressBar();

        ConsoleOutputMethod.StartUpOutputComments();

        WindowsComponents.WindowTaskBarFlash();
    }
}
