namespace LauncherDL.Core.Buttons;

internal sealed class MetadataButton : IButtonControls
{
    public static void ButtonClicked(object s, RoutedEventArgs e)
    {   
        if(new MetadataWindow().OpenDialog() is not MetadataClicked.Set)
            return;

        if(MetadataWindowStatic.IsTextChanged)
            ConsoleOutputMethod.MetadataOutputComment();
    }
}