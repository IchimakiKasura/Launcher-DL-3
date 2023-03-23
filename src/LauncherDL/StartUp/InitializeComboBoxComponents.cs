namespace LauncherDL.StartUp;

partial class OnStartUp
{
    private static async void InitializeComboBoxComponents()
    {
        SetCanvas(comboBoxQuality, 117, 648);

        await WindowsComponents.WindowAwaitLoad(comboBoxType.IsLoaded);

        comboBoxQuality.AddQualityTypeList();
        comboBoxType.AddCustomTypeList();

        comboBoxType.ItemIndex              =   config.DefaultFileTypeOnStartUp;
        comboBoxType.ContentAlignment       =   HorizontalAlignment.Center;
        comboBoxType.ShowVerticalScrollbar  =   ScrollBarVisibility.Hidden;
        comboBoxQuality.ItemIndex           =   3;
        comboBoxQuality.Width               =   207;
    }
}