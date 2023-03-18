namespace LauncherDL.Core.Buttons;

public abstract class MetadataButton
{
    public static void ButtonClicked(object s, RoutedEventArgs e)
    {
        MetadataWindowStatic = new();
    }
}