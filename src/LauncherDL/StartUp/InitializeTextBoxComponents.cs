namespace LauncherDL.StartUp;

internal sealed partial class OnStartUp
{
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