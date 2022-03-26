namespace Launcher_DL_v6;

public partial class MainWindow
{
    private void WindowFocusAnimation()
    {
        void Focus()
		{
            Storyboard sty = new();
            Storyboard sty2 = new();
            Storyboard.SetTargetProperty(Opac, new("(Window.Effect).Opacity"));
            Storyboard.SetTargetProperty(Anim, new("(Control.Background).(SolidColorBrush.Color)"));
            Storyboard.SetTarget(Opac, this);
            Storyboard.SetTarget(Anim, WindowBG);
            sty.Children.Add(Opac);
            sty2.Children.Add(Anim);
            sty.Begin();
            sty2.Begin();
        }

        Activated += delegate
        {
            Opac = new(1, TimeSpan.FromMilliseconds(200));
            Anim = new((Color)ColorConverter.ConvertFromString(Config.BackgroundColor), TimeSpan.FromMilliseconds(200));
            Focus();
        };

        Deactivated += delegate
        {
            Opac = new(0, TimeSpan.FromMilliseconds(200));
            Anim = new(Colors.Black, TimeSpan.FromMilliseconds(200));
            Focus();
        };
    }

    // prevents closing while downloading
	private void Window_Close(object s, CancelEventArgs handler)
	{
		if (IsDownloading) {
			var sagot = MessageBox.Show(
				"Hey! You can't close me while Working! ಠ_ಠ",
				"Hutao",
				MessageBoxButton.OK, MessageBoxImage.Exclamation);
			handler.Cancel = (sagot == MessageBoxResult.OK);;
		}
	}

    // hides the Window's Border so it will looks like the "WindowStyle: None"
    // so THAT IT HAS A MINIMIZE ANIMATION. not just when you minimize it just 
    // disappear.
    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
        new TransparencyConverter(this).MakeTransparent();
    }

    // disable Tab navigation completely
    private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.Tab)
        {
            e.Handled = true;
        }
    }

    /// <summary>
    /// Disable/Enable the Components.
    /// </summary>
    /// <param name="Disable">True or False</param>
    private void Window_Components(bool Disable)
    {
        if(Disable)
        {
            Button_Format.IsEnabled =
            Button_Download.IsEnabled =
            Button_Update.IsEnabled = 
            Input_Link.IsEnabled =
            Input_Name.IsEnabled =
            Input_Format.IsEnabled = 
            Input_Type.IsEnabled =
            Input_MpThreeFormat.IsEnabled = false;
        }
        else
        {
            Button_Format.IsEnabled =
            Button_Download.IsEnabled =
            Button_Update.IsEnabled = 
            Input_Link.IsEnabled =
            Input_Name.IsEnabled =
            Input_Type.IsEnabled =
            Input_MpThreeFormat.IsEnabled = true;

            if(Input_Type.SelectedIndex == 0) Input_Format.IsEnabled = true;
        }
    }
}