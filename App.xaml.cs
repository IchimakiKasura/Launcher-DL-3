namespace Launcher_DL_v6
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        void App_Startup(object s, StartupEventArgs e)
        {
            ContextMenuAdjust();

			try
			{
                RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Control\Nls\CodePage", true);
                key.SetValue("ACP", "65001", RegistryValueKind.String);
			}
            catch
			{
                MessageBox.Show("For best experience, Run the application in Administrator\n if you're not Ok seeings blank titles in the console because its not\nrendered in UTF-8 format", "Note", MessageBoxButton.OK, MessageBoxImage.Warning);
			};
        }
        
        void App_Exit(object s, ExitEventArgs e)
        {
			try
            {
                RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\Control\Nls\CodePage", true);
                key.SetValue("ACP", "1252", RegistryValueKind.String);
            } catch { }
        }

        // Fixes the drop menus going from right to left because i don't know what happened.
        // Some say its because of the Tablet but I don't use Tablet PC or either have one.
        // anyways rip tablet users because this forces the menus to go left to right.
        private void ContextMenuAdjust()
        {
            var menuDropAlignmentField = typeof(SystemParameters).GetField("_menuDropAlignment", BindingFlags.NonPublic | BindingFlags.Static);
            Action setAlignmentValue = () =>
            {
                if (SystemParameters.MenuDropAlignment && menuDropAlignmentField != null) menuDropAlignmentField.SetValue(null, false);
            };

            setAlignmentValue();

            SystemParameters.StaticPropertyChanged += (sender, e) =>
            {
                setAlignmentValue();
            };
        }
    };
}
