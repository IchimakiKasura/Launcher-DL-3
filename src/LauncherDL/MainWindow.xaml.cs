namespace LauncherDL;

// TODO:
//
//
//  ==============================================================================================
//  Fix the ToolTip attribute and make it usable for every situation
//  not single typed focused or idk selective
//  [3/22/23] Have a temporary Tooltip fix but It needs to accept both Properties and Fields 
//  [3/22/23 | 5:02 AM] Got it to make smaller 
//
//  "Nothing more permanent than a temporary solution" ☠️☠️
//  ==============================================================================================
//
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

        InitiateStaticComponents(this);

        #if DEBUG
            ConsoleDebug.InitiateConsoleDebug();
        #endif

        config = Config.ReadConfigINI();
        FFmpegFiles.CheckFiles();
        OnStartUp.Initialize();
    }
}