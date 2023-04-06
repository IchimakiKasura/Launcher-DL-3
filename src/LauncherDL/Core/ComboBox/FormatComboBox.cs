namespace LauncherDL.Core.ComboBoxDL;

public class FormatComboBox : IComboBoxControl
{
    public static void ItemChanged(object s, RoutedEventArgs e)
    {
        if(comboBoxFormat.HasItems && !comboBoxFormat.TextEditable)
            ConsoleOutputMethod.ComboBoxChangedOutputComment(ConsoleOutputMethodSelection.FORMAT);

        // Weird
        if(comboBoxType.ItemIndex is 0 &&
           comboBoxFormat.HasItems &&
           comboBoxFormat.SelectedItem is FormatList SelectedFormat &&
           SelectedFormat.ID  is "Best"
          )
            console.DLAddConsole(CONSOLE_WARNING_STRING, "Metadata will be ignored when the format is on default!");
    }
}