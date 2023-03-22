namespace LauncherDL.Core.Buttons;

public abstract class MetadataButton
{
    public static void ButtonClicked(object s, RoutedEventArgs e)
    {
        if(new MetadataWindow().OpenDialog() is MetadataWindow.MetadataClicked.Set)
            ConsoleOutputMethod.MetadataOutputComment();

        // Remove the instance on static field
        MetadataWindowStatic = null;
    }
}