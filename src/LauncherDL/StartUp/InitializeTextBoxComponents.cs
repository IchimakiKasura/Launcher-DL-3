namespace LauncherDL.StartUp;

partial class OnStartUp
{
    private static void InitializeTextBoxComponents()
    {
        textBoxLink.TextPlaceholderAlignment = 
        textBoxName.TextPlaceholderAlignment = HorizontalAlignment.Center;

        textBoxLink.FontSize = 
        textBoxName.FontSize = 22;

        textBoxLink.Height =
        textBoxName.Height = 35;

        var BuildVersionText = APP_CURRENT_VERION;

        #if DEBUG
            BuildVersionText = "Development Build";
        #endif

        textBlockFooter.Text = $"Copyright © 2023 Kasura | Build Version: {BuildVersionText}";
        textBlockFooter.MouseDown += (s,e) => MessageBox.Show(hidden, "Huzuaah!", MessageBoxButton.OK, MessageBoxImage.Information);
    }
}