namespace LauncherDL.StartUp;
internal sealed partial class OnStartUp
{
    static readonly string TextMessage = $"Copyright © 2023 Kasura | Build Version: {APP_CURRENT_VERSION}";
    static readonly string TextMessageModified = $"Copyright © 2023 Kasura | Build Version: {APP_CURRENT_VERSION} ";

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
    }

    public static void INITIATE_CONSISTENT_FPS(bool UpdatePerSec)
    {
        if(UpdatePerSec is true)
            CompositionTarget.Rendering += RenderUpdate;
        else CompositionTarget.Rendering -= RenderUpdate;
    }

    private static void RenderUpdate(object s, EventArgs e)
    {
        if(textBlockFooter.Text == TextMessage)
            textBlockFooter.Text = TextMessageModified;
        else 
            textBlockFooter.Text = TextMessage;
    }
}
