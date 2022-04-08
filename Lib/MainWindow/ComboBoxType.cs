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
        Input_Format.IsEditable = false;
        Button_Format.IsEnabled = false;
    }

    private void SelectedFormat(string format)
    {
        dynamic Type = null;
        switch(format)
        {
            case "Video":
                Type = VideoType;
                break;
            case "Audio":
                Type = AudioType;
                break;
            case "Convert":
                Type = ConvertType;
                break;
        }

        foreach (string ext in Type)
        {
            Input_Format.Items.Add(new
            {
                Name = ext,
                Format = ext,
            });
        }
    }

    public void InputType(object s, SelectionChangedEventArgs e)
    {
        switch(Input_Type.SelectedIndex)
        {
            case 0:
                Input_Format.IsReadOnly = false;
                Input_Format.IsEditable = true;
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

            case 3:
                InputFormatShortCut();
                SelectedFormat("Convert");
                Input_Link.HorizontalAlignment =
                Text_Link.HorizontalAlignment = HorizontalAlignment.Left;
                Input_Link.Width =
                Text_Link.Width = 360;
                Input_Link.Uid = System_Language_Handler.DefaultInputLinkUIDTwo;
                Text_Link.Content = System_Language_Handler.DefaultLinkContentTwo;
                Open_File.Visibility = Visibility.Visible;
                Button_Download.Click -= Download;
                Button_Download.Click += ConvertFile;
                Input_Format.SelectedIndex = 0;
                break;
        };

        if(Input_Type.SelectedIndex != 3)
		{
            Input_Link.HorizontalAlignment = 
            Text_Link.HorizontalAlignment = HorizontalAlignment.Center;
            Input_Link.Width = 446;
            Text_Link.Width = 65;
            Input_Link.Uid = System_Language_Handler.DefaultInputLinkUID;
            Text_Link.Content = System_Language_Handler.DefaultLinkContent;
            Open_File.Visibility = Visibility.Hidden;
            Button_Download.Click -= ConvertFile;
            Button_Download.Click += Download;
        }

        if (Config.ShowSystemOutput) Output_text.AddFormattedText($"<#a85192%14>[SYSTEM] <Gray%14>Changed TYPE to \"{((ComboBoxItem)Input_Type.SelectedItem).Content.ToString()}\"");
    }
}