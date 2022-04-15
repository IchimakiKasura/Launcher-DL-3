namespace Launcher_DL.Lib.Windows;

public partial class ContextMenuButtons
{
	void ClearText(object s, RoutedEventArgs e)
	{
		if (Global.IsLink) Global.Input_Link.Text = string.Empty;
		if (Global.IsName) Global.Input_Name.Text = string.Empty;
		if (Global.IsFormat) Global.Input_Format.Text = string.Empty;

		Global.IsLink = Global.IsName = Global.IsFormat = false;
	}
}