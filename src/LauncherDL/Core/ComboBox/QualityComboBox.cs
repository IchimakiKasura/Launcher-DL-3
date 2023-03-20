namespace LauncherDL.Core.ComboBoxDL;

public class QualityComboBox
{
    public static void ItemChanged(object s, RoutedEventArgs e)
    {
        if(windowCanvas.Contains(comboBoxQuality))
            ConsoleOutputMethod.ComboBoxChangedOutputComment(ConsoleOutputMethod.QUALITY);
    }
}