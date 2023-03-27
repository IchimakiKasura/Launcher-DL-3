namespace LauncherDL.Core.Buttons;

internal class MetadataButton : IButtonControls
{
    public static void ButtonClicked(object s, RoutedEventArgs e)
    {   
        if(new MetadataWindow().OpenDialog() is not MetadataWindow.MetadataClicked.Set)
            return;

        if(MetadataWindowStatic.IsTextChanged)
            ConsoleOutputMethod.MetadataOutputComment();
    }
}