namespace LauncherDL.Core.Buttons;

public abstract class MetadataButton
{
    public static void ButtonClicked(object s, RoutedEventArgs e)
    {
        if(new MetadataWindow().OpenDialog == MetadataWindow.MetadataClicked.Set)
            ConsoleOutputMethod.MetadataOutputComment();
    }
}