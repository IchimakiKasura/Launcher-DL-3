using static DLControls.ProgressBarControl;
namespace LauncherDL.Core.Windows;

class WindowsComponents
{
    static DoubleAnimation WindowOpacity;
    static ColorAnimation WindowAnimation;

    // Onload Event
    public static void WindowLoaded(object sender, RoutedEventArgs e) =>
        new TransparencyConverter(MainWindowStatic).MakeTransparent();

    // Window Focus or unfocused
    public static void WindowFocusAnimation()
    {
        void Focus()
        {
            new StoryboardApplier(WindowOpacity     ,   MainWindowStatic    ,   new(             "(Window.Effect).Opacity"        ) );
            new StoryboardApplier(WindowAnimation   ,   windowInnerBG       ,   new("(Control.Background).(SolidColorBrush.Color)") );
        }

        MainWindowStatic.Activated += (s,e) =>
        {
            if(MetadataWindow.IsWindowOpen) return;
            
            if (TaskbarProgressBar.ProgressValue is 1)
                TaskbarProgressBar.ProgressValue  = 0;

            WindowOpacity       = new(1, TimeSpan.FromMilliseconds(100));
            WindowAnimation     = new(config.backgroundColor, TimeSpan.FromMilliseconds(100));
            Focus();

            #if DEBUG
                ConsoleDebug.WindowFocused(true);
            #endif
        };

        MainWindowStatic.Deactivated += (s,e) =>
        {
            WindowOpacity       = new(0, TimeSpan.FromMilliseconds(100));
            WindowAnimation     = new(Colors.Black, TimeSpan.FromMilliseconds(100));
            Focus();
            
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
        if(progressBar.Value > 0) progressBar.Value = 0;
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

        _ = comboBoxType switch
        {
            _ when comboBoxType.ItemIndex is 3 =>
                buttonOpenFile.IsEnabled = !buttonOpenFile.IsEnabled,
            _ when comboBoxType.ItemIndex is not 0 =>
                buttonFileFormat.IsEnabled = !buttonFileFormat.IsEnabled,
            _ => default
        };

        WindowProgressBar(comboBoxType.IsEnabled ? ProgressBarState.Hide : ProgressBarState.Show);
    }

    public static void WindowHoverTooltip()
    {

    }
}