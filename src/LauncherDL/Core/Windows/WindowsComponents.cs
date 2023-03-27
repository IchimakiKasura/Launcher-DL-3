using static DLControls.ProgressBarControl;
namespace LauncherDL.Core.Windows;

class WindowsComponents
{
    // Onload Event
    public static void WindowLoaded(object sender, RoutedEventArgs e) =>
        new TransparencyConverter(MainWindowStatic).MakeTransparent();

    // Avoid window closing when there's an ongoing process
    public static void WindowOnClose(object s, System.ComponentModel.CancelEventArgs e)
    {
        if (IsInProcess)
        {
            MessageBoxResult sagot = MessageBox.Show(
                "Hey! You can't close me while Working! ಠ_ಠ",
                "Hutao",
                MessageBoxButton.OK, MessageBoxImage.Exclamation);

            if (sagot == MessageBoxResult.OK) e.Cancel = true;
        }
    }

    // Window Focus or unfocused
    public static void WindowFocusAnimation()
    {
        void Focus(ColorAnimation WindowAnimation, DoubleAnimation WindowOpacity)
        {
            new StoryboardApplier(WindowOpacity     ,   MainWindowStatic    ,   new(             "(Window.Effect).Opacity"        ) );
            new StoryboardApplier(WindowAnimation   ,   windowInnerBG       ,   new("(Control.Background).(SolidColorBrush.Color)") );
        }

        MainWindowStatic.Activated += (s,e) =>
        {
            if(MetadataWindow.IsWindowOpen) return;
            
            if (TaskbarProgressBar.ProgressValue is 1)
                TaskbarProgressBar.ProgressValue  = 0;

            Focus(
                WindowOpacity       : new(1, TimeSpan.FromMilliseconds(100)),
                WindowAnimation     : new(config.backgroundColor, TimeSpan.FromMilliseconds(100))
            );

            #if DEBUG
                ConsoleDebug.WindowFocused(true);
            #endif
        };

        MainWindowStatic.Deactivated += (s,e) =>
        {
            Focus(
                WindowOpacity       : new(0, TimeSpan.FromMilliseconds(100)),
                WindowAnimation     : new(Colors.Black, TimeSpan.FromMilliseconds(100))
            );

            #if DEBUG
                ConsoleDebug.WindowFocused(false);
            #endif
        };
    }

    public static void WindowDrag(object sender, MouseButtonEventArgs e)
    {
        if (e.ChangedButton is MouseButton.Left) MainWindowStatic.DragMove();
    }

    public static void WindowProgressBar(ProgressBarState State)
    {
        switch(State)
        {
            case ProgressBarState.Hide: windowCanvas.Remove    (progressBar);  console.ConsoleHeight = 273; break;
            case ProgressBarState.Show: windowCanvas.Add       (progressBar);  console.ConsoleHeight = 245; break;
        }
        console.manualScrollToEnd();
    }

    // Windows Taskbar flash
    public static bool WindowTaskBarFlash()
    {
        IntPtr hWnd = new System.Windows.Interop.WindowInteropHelper(MainWindowStatic).Handle;
        FLASHWINFO fInfo = new FLASHWINFO();

        fInfo.cbSize = Convert.ToUInt32(Marshal.SizeOf(fInfo));
        fInfo.hwnd = hWnd;
        fInfo.dwFlags = FLASHW_ALL | FLASHW_TIMERNOFG;
        fInfo.uCount = uint.MaxValue;
        fInfo.dwTimeout = 0;

        return FlashWindowEx(ref fInfo);
    }

    public static async Task WindowAwaitLoad(bool a) =>
        await Task.Run(()=>{ MainWindowStatic.Dispatcher.Invoke(async()=>{ while(!a) await Task.Delay(100); }); });
  

    // Is it bad to just call it without parameters to know if its freezed or not?
    // nah its my code and I know when to call the method but yeah it does look bad practice
    public static void FreezeComponents()
    {
        UIElement[] ControlLists = 
        {
            buttonFileFormat,
            buttonDownload,
            buttonUpdate,
            buttonMetadata,
            textBoxLink,
            textBoxName,
            comboBoxType,
            comboBoxFormat,
            comboBoxQuality
        };

        foreach (var CL in ControlLists)
            CL.IsEnabled = !CL.IsEnabled;

        if(comboBoxType.ItemIndex is not 0)
            buttonFileFormat.IsEnabled = !buttonFileFormat.IsEnabled;

        switch(comboBoxType.ItemIndex)
        {
            case 0:
                buttonMetadata.IsEnabled = !buttonMetadata.IsEnabled;
            break;

            case 3:
                buttonMetadata.IsEnabled = !buttonMetadata.IsEnabled;
                buttonOpenFile.IsEnabled = !buttonOpenFile.IsEnabled;
            break;
        }

        WindowProgressBar(comboBoxType.IsEnabled ? ProgressBarState.Hide : ProgressBarState.Show);
    }
}