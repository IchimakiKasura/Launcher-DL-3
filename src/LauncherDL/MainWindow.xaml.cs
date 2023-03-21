namespace LauncherDL;

// TODO:
//
//  Add download method functionality
//  Add Metadata Functionality
//
//  Finish Metadata Design and refactor it to make it look
//  cleaner
//
//  Fix the ToolTip attribute and make it usable for every situation
//  not single typed focused or idk selective
//
//  Try to use Attributes for easy coding
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

        InitiateStaticComponents(this);

        #if DEBUG
            ConsoleDebug.InitiateConsoleDebug();
        #endif

        config = Config.ReadConfigINI();
        FFmpegFiles.CheckFiles();
        OnStartUp.Initialize();        
    }
}