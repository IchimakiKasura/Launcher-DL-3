namespace LauncherDL.Core.ComboBoxDL;

public sealed class QualityComboBox : IComboBoxControl
{
    public static void ItemChanged(object s, RoutedEventArgs e)
    {
        if(windowCanvas.Contains(comboBoxQuality))
            ConsoleOutputMethod.ComboBoxChangedOutputComment(ConsoleOutputMethodSelection.QUALITY);
    }
}