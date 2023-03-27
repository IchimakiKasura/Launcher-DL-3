namespace LauncherDL.Core.Buttons;

internal class FolderButton : IButtonControls
{
    public static void ButtonClicked(object s, RoutedEventArgs e)
    {
        e.Handled = true;

        var currentDirectory = FolderDirectory();
        // if some bastards tried to delete the output folder
        if(!Directory.Exists(currentDirectory))
            currentDirectory = Directory.GetCurrentDirectory();

        Process.Start(new ProcessStartInfo()
        {
            Arguments = currentDirectory,
            FileName  = "explorer.exe"
        });
    }

    public static string FolderDirectory()
    {
        var currentDirectory = $"{Directory.GetCurrentDirectory()}\\{config.DefaultOutput}";

        if(config.DefaultOutput != new DefaultConfig().DefaultOutput)
            currentDirectory = config.DefaultOutput ;

        return currentDirectory;
    }
}