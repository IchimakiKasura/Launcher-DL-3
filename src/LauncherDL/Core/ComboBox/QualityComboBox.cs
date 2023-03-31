namespace LauncherDL.Core.ComboBoxDL;

public class QualityComboBox : IComboBoxControl
{
    public static void ItemChanged(object s, RoutedEventArgs e)
    {
        if(windowCanvas.Contains(comboBoxQuality))
            ConsoleOutputMethod.ComboBoxChangedOutputComment(ConsoleOutputMethodSelection.QUALITY);
    }
}