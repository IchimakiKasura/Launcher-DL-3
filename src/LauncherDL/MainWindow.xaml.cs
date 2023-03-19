namespace LauncherDL;

// TODO:
//
//  Add download method functionality
//  Add Metadata Functionality
// 
//  Implement the YDL.cs based on the old script from v6
//
// wa:
//  nothing, just clean the code idk.
//  Take more time. (what)

//=========================================================//
//   ██████╗██╗  ██╗██╗███████╗ █████╗ ████████╗ ██████╗   //
//  ██╔════╝██║  ██║██║██╔════╝██╔══██╗╚══██╔══╝██╔═══██╗  //
//  ██║     ███████║██║███████╗███████║   ██║   ██║   ██║  //
//  ██║     ██╔══██║██║╚════██║██╔══██║   ██║   ██║   ██║  //
//  ╚██████╗██║  ██║██║███████║██║  ██║   ██║   ╚██████╔╝  //
//   ╚═════╝╚═╝  ╚═╝╚═╝╚══════╝╚═╝  ╚═╝   ╚═╝    ╚═════╝   //
//=========================================================//
public partial class MainWindow : Window
{

    public MainWindow()
    {
        InitializeComponent();
        
        SetAttributes.Add(this);

        #if DEBUG
            ConsoleDebug.InitiateConsoleDebug();
        #endif

        config = Config.ReadConfigINI();
        FFmpegFiles.CheckFiles();
        OnStartUp.Initialize();
    }
}