namespace Launcher_DL_v6;

public partial class MainWindow
{
    public void InputType(object s, SelectionChangedEventArgs e)
    {
        if(Input_Type.SelectedIndex != 0)
        {
            Input_Format.Text = "Unavailable";
            Input_Format.IsEnabled = false;
        }
        else 
        {
            Input_Format.Text = "best";
            Input_Format.IsEnabled = true;
        }

        if (Input_Type.SelectedIndex == 2) Input_MpThreeFormat.Visibility = Visibility.Visible;
            else Input_MpThreeFormat.Visibility = Visibility.Hidden;

		if(Config.ShowSystemOutput) Output_text.AddFormattedText($"<#a85192%14>[SYSTEM] <Gray%14>Changed TYPE to \"{((ComboBoxItem)Input_Type.SelectedItem).Content.ToString()}\"");
    }
}