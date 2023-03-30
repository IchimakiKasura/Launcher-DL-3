namespace LauncherDL;

public partial class App : Application
{
    private static System.Threading.Mutex _mutex = null;
    const uint ENABLE_QUICK_EDIT = 0x0040;
    
    protected override void OnStartup(StartupEventArgs e)
    {
        string appName = Assembly.GetExecutingAssembly().GetName().Name;
        bool createdNew;

        _mutex = new(true, appName, out createdNew);

        if (!createdNew)
            if (MessageBox.Show("Only one instance at a time!", "Warning",
                                MessageBoxButton.OK,
                                MessageBoxImage.Warning) is MessageBoxResult.OK)
                Environment.Exit(0);

        App_Startup(e);
    }    

    private void App_Startup(StartupEventArgs e)
    {
        PresentationTraceSources.DataBindingSource.Switch.Level = SourceLevels.Off;
        Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.BelowNormal;
        ContextMenuAdjust();

        var Update = new Update.Updater();

        #if !DEBUG
            DispatcherUnhandledException += AppDispatcherUnhandledException;
        #else
            DispatcherUnhandledException += AppDebugException;
            AllocConsole();

            IntPtr consoleHandle = GetStdHandle(-10);
            DeleteMenu(GetSystemMenu(GetConsoleWindow(), false), 0xF060, 0x00000000);
            DeleteMenu(GetSystemMenu(GetConsoleWindow(), false), 0xF020, 0x00000000);
            DeleteMenu(GetSystemMenu(GetConsoleWindow(), false), 0xF030, 0x00000000);
            GetConsoleMode(consoleHandle, out uint consoleMode);
            consoleMode &= ~ENABLE_QUICK_EDIT;
            SetConsoleMode(consoleHandle, consoleMode);

            ConsoleDebug.Log(
             "============================\n"+
             "=   Version Update Check   =\n"+
             "============================\n"+
            $"Current Version: {Update.CurrentVersion}\n"+
            $"Latest Version: {Update.NewVersion}\n"
            );
        #endif
    }
}