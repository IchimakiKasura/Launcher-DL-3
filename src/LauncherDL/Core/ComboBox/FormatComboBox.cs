namespace LauncherDL.Core.ComboBoxDL;

public class FormatComboBox
{
    public static void ItemChanged(object s, RoutedEventArgs e)
    {
        if(comboBoxFormat.HasItems && !comboBoxFormat.TextEditable)
            ConsoleOutputMethod.ComboBoxChangedOutputComment(ConsoleOutputMethod.FORMAT);
    }
}