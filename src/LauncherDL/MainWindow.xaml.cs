﻿namespace LauncherDL;

// TODO:
//
//	Fix ComboBoxItem for Format Add List
//  and its remaining bugs or idk
//
//  Implement the YDL.cs based on the old script from v6
//
//  After implementing YDL, please just don't over use the TASK method again
//  to avoid that "Cannot re-enter paragraph" error Try using background task.
//
// wa:
//	nothing, just clean the code idk.
//	Take more time. (what)

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