namespace Launcher_DL.Core.ComboBoxDL;

public class TypeComboBox
{
    public static void ItemChanged(object s, RoutedEventArgs e)
    {
        ConsoleOutputMethod.TypeChangedOutputComment();

        switch(comboBoxType.ItemIndex)
        {
            case 0:
                buttonOpenFile.IsEnabled = false;
                comboBoxFormatText(true);
                break;
            case 1:
                buttonOpenFile.IsEnabled = false;
                comboBoxFormatText(false);
                break;
            case 2:
                buttonOpenFile.IsEnabled = false;
                comboBoxFormatText(false);
                break;
            case 3:
                buttonOpenFile.IsEnabled = true;
                comboBoxFormatText(false);
                break;
        };
    }

    private static void comboBoxFormatText(bool Editable)
    {
        comboBoxFormat.TextEditable = Editable;
        comboBoxFormat.RefreshEditable();
    }
};