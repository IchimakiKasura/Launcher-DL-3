namespace LauncherDL;

public partial class App : Application
{
    static Mutex _mutex;

    protected override void OnStartup(StartupEventArgs e)
    {
        string appName = Assembly.GetExecutingAssembly().GetName().Name;
        
        _mutex = new(true, appName, out bool createdNew);

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

            ConsoleDebug.Log($"""
            
            ============================
            =   Version Update Check   =
            ============================
            Current Version: {Update.CurrentVersion}
            Latest Version: {Update.NewVersion}

            """);
        #endif
    }
}