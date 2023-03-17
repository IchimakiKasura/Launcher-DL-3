namespace LauncherDL.StartUp;

partial class OnStartUp
{
    private static async void InitializeComboBoxComponents()
    {
        Canvas.SetTop(comboBoxType, 89);
        Canvas.SetTop(comboBoxQuality, 117);
        Canvas.SetLeft(comboBoxQuality, 648);

        await WindowsComponents.WindowAwaitLoad(comboBoxType.IsLoaded);

        comboBoxQuality.AddQualityTypeList();
        comboBoxType.AddCustomTypeList();

        comboBoxType.ItemIndex              =   config.DefaultFileTypeOnStartUp;
        comboBoxType.ContentAlignment       =   HorizontalAlignment.Center;
        comboBoxType.ShowVerticalScrollbar  =   false;
        comboBoxQuality.ItemIndex           =   3;
    }
}