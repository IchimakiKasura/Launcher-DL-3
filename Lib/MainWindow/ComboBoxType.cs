namespace Launcher_DL_v6;

public partial class MainWindow
{
    private List<object> FormatTemp = new();
    
    private void InputFormatShortCut()
    {
        if(FormatTemp.Count == 0 && !Input_Format.IsReadOnly)
        {
            foreach(object item in Input_Format.Items) FormatTemp.Add(item);
        }
        Input_Format.Items.Clear();
        Input_Format.Text = string.Empty;
        Input_Format.IsReadOnly = true;
        Button_Format.IsEnabled = false;
    }

    private void SelectedFormat(string format)
    {
        switch(format)
        {
            case "Video":
                foreach(string ext in VideoType)
                {
                    Input_Format.Items.Add(new{
                        Name = ext,
                        Format = ext,
                    });
                }
            break;

            case "Audio":
                foreach(string ext in AudioType)
                {
                    Input_Format.Items.Add(new{
                        Name = ext,
                        Format = ext,
                    });
                }
            break;
        }
    }

    public void InputType(object s, SelectionChangedEventArgs e)
    {
        switch(Input_Type.SelectedIndex)
        {
            case 0:
                Input_Format.IsReadOnly = false;
                Input_Format.Items.Clear();
                Input_Format.Text = "Best";
                Button_Format.IsEnabled = !Button_Format.IsEnabled;
                foreach(object item in FormatTemp)
                    Input_Format.Items.Add(item);
                FormatTemp.Clear();
            break;

            case 1:
                InputFormatShortCut();
                SelectedFormat("Video");
                Input_Format.SelectedIndex = 0;
            break;

            case 2:
                InputFormatShortCut();
                SelectedFormat("Audio");
                Input_Format.SelectedIndex = 0;
            break;
        };

        if (Config.ShowSystemOutput) Output_text.AddFormattedText($"<#a85192%14>[SYSTEM] <Gray%14>Changed TYPE to \"{((ComboBoxItem)Input_Type.SelectedItem).Content.ToString()}\"");
    }

}