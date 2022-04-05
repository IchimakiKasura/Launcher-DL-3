namespace Launcher_DL_v6;

public partial class MainWindow
{
    // Flashes the app in the Taskbar
    public bool WindowFlash()
    {
        IntPtr hWnd = new System.Windows.Interop.WindowInteropHelper(this).Handle;
        FLASHWINFO fInfo = new FLASHWINFO();

        fInfo.cbSize = Convert.ToUInt32(Marshal.SizeOf(fInfo));
        fInfo.hwnd = hWnd;
        fInfo.dwFlags = FLASHW_ALL | FLASHW_TIMERNOFG;
        fInfo.uCount = uint.MaxValue;
        fInfo.dwTimeout = 0;

        return FlashWindowEx(ref fInfo);
    }

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
            if(TaskBarThingy.ProgressValue == 1) TaskBarThingy.ProgressValue = 0;
            
            Opac = new(1, TimeSpan.FromMilliseconds(200));
            Anim = new(ClrConv(Config.BackgroundColor), TimeSpan.FromMilliseconds(200));
            Focus();
            DebugOutput.WindowFocusDebug(true);
        };

        Deactivated += delegate
        {
            Opac = new(0, TimeSpan.FromMilliseconds(200));
            Anim = new(Colors.Black, TimeSpan.FromMilliseconds(200));
            Focus();
            DebugOutput.WindowFocusDebug(false);
        };
    }

    // prevents closing while downloading
    private void Window_Close(object s, CancelEventArgs handler)
    {
        DebugOutput.Close();

        if (IsDownloading)
        {
            MessageBoxResult sagot = MessageBox.Show(
                "Hey! You can't close me while Working! ಠ_ಠ",
                "Hutao",
                MessageBoxButton.OK, MessageBoxImage.Exclamation);

            if(sagot == MessageBoxResult.OK) handler.Cancel = true;
            DebugOutput.CloseCancel();
        }

        #region Saves a Log file lmao

        string Current_date = DateTime.Now.ToString().Replace("/", ".").Replace(":", "-");

        TextRange textRange = new TextRange(
            Output_text.Document.ContentStart,
            Output_text.Document.ContentEnd
        );

        if (textRange.Text.Length >= 221)
        {
            if (!IsDownloading) Output_text.AddText("Exiting...");
            else Output_text.AddFormattedText("<Yellow>[INFO] <>Cannot Exit when download is started!");
            
            if (!Directory.Exists($"{Directory.GetCurrentDirectory}\\Logs")) Directory.CreateDirectory("Logs");
            File.WriteAllText($"./Logs/{Current_date}.txt", textRange.Text);
        }
        #endregion
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
        if (Disable)
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

            if (Input_Type.SelectedIndex == 0) Input_Format.IsEnabled = true;
        }
    }
}