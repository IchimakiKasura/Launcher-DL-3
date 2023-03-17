namespace LauncherDL.Core.ComboBoxDL;

public class FormatComboBox
{
    public static void ItemChanged(object s, RoutedEventArgs e)
    {
        if(comboBoxFormat.HasItems)
            ConsoleOutputMethod.ComboBoxChangedOutputComment(ConsoleOutputMethod.FORMAT);
    }
}