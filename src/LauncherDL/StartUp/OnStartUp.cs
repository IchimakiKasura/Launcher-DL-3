namespace LauncherDL.StartUp;
partial class OnStartUp
{
    // Initializes all the values for XAML
    // (Avoiding too much shit on the XAML to look the clean)
    /// <summary>
    /// Initialize all the components that are left
    /// </summary>
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

        INITIATE_CONSISTENT_FPS();
    }

    private static void INITIATE_CONSISTENT_FPS()
    {
        var TextMessage = $"Copyright © 2023 Kasura | Build Version: {APP_CURRENT_VERSION}";
        CompositionTarget.Rendering += delegate
        {
            if(textBlockFooter.Text == TextMessage)
                textBlockFooter.Text = $"Copyright © 2023 Kasura | Build Version: {APP_CURRENT_VERSION} ";
            else 
                textBlockFooter.Text = TextMessage;
        };
    }
}
