namespace LauncherDL.StartUp;

partial class OnStartUp
{
	private static async void InitializeComboBoxComponents()
	{
		Canvas.SetTop(comboBoxType, 89);

		await WindowsComponents.WindowAwaitLoad(comboBoxType.IsLoaded);

		comboBoxType.ItemIndex              =   config.DefaultFileTypeOnStartUp;
		comboBoxType.ContentAlignment       =   HorizontalAlignment.Center;
		comboBoxType.ShowVerticalScrollbar  =   false;

		comboBoxType.ItemsAdd();
	}
}