namespace Launcher_DL.Lib.Windows;

sealed class ComboBoxComp : Global
{
	private static List<object> FormatTemp = new();

	private static void InputFormatShortCut()
	{
		if (FormatTemp.Count == 0 && !Input_Format.IsReadOnly)
		{
			foreach (object item in Input_Format.Items) FormatTemp.Add(item);
		}
		Input_Format.Items.Clear();
		Input_Format.Text = string.Empty;
		Input_Format.IsReadOnly = true;
		Input_Format.IsEditable = false;
		Button_Format.IsEnabled = false;
	}

	private static void SelectedFormat(string format)
	{
		dynamic Type = null;
		switch (format)
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

	public static void SelectedInputType(object s, SelectionChangedEventArgs e)
	{
		switch (Input_Type.SelectedIndex)
		{
			case 0:
				MainWindowStatic.Title = "Launcher DL - Custom";
				Input_Format.IsReadOnly = false;
				Input_Format.IsEditable = true;
				Input_Format.Items.Clear();
				Input_Format.Text = "Best";
				Button_Format.IsEnabled = !Button_Format.IsEnabled;
				foreach (object item in FormatTemp)
					Input_Format.Items.Add(item);
				FormatTemp.Clear();
				break;

			case 1:
				MainWindowStatic.Title = "Launcher DL - Video";
				InputFormatShortCut();
				SelectedFormat("Video");
				Input_Format.SelectedIndex = 0;
				break;

			case 2:
				MainWindowStatic.Title = "Launcher DL - Audio";
				InputFormatShortCut();
				SelectedFormat("Audio");
				Input_Format.SelectedIndex = 0;
				break;

			case 3:
				MainWindowStatic.Title = "Launcher DL - Convert";
				InputFormatShortCut();
				SelectedFormat("Convert");
				Input_Link.HorizontalAlignment =
				Text_Link.HorizontalAlignment = HorizontalAlignment.Left;
				Input_Link.Width =
				Text_Link.Width = 360;
				Input_Link.Uid = System_Language_Handler.Placeholder_File;
				Text_Link.Content = System_Language_Handler.Label_File;
				Input_Name.Uid = System_Language_Handler.Placeholder_Required;
				Button_Download.Text = System_Language_Handler.ComboBox_Label_Convert.ContentStringFormat;
				Open_File.Visibility = Visibility.Visible;
				Button_Download.Click -= Buttons.Download;
				Button_Download.Click += Buttons.ConvertFile;
				Input_Format.SelectedIndex = 0;

				if (Config.SystemLanguage.ToLower() == "default")
					Button_Download.Text = "コンバート";

				break;
		};

		if (Input_Type.SelectedIndex != 3)
		{
			Input_Link.HorizontalAlignment =
			Text_Link.HorizontalAlignment = HorizontalAlignment.Center;
			Input_Link.Width = 446;
			Text_Link.Width = 65;
			Input_Link.Uid = System_Language_Handler.Placeholder_Link;
			Text_Link.Content = System_Language_Handler.Label_Link;
			Input_Name.Uid = System_Language_Handler.Placeholder_Optional;
			Button_Download.Text = System_Language_Handler.Button_Download_Default;
			Open_File.Visibility = Visibility.Hidden;
			Button_Download.Click -= Buttons.ConvertFile;
			Button_Download.Click -= Buttons.Download;
			Button_Download.Click += Buttons.Download;
		}

		if (Config.ShowSystemOutput) Output_text.AddFormattedText($"<#a85192%14>[SYSTEM] <Gray%14>Changed TYPE to \"{((ComboBoxItem)Input_Type.SelectedItem).Content.ToString()}\"");
		TaskBarThingy.Description = MainWindowStatic.Title;
	}
}