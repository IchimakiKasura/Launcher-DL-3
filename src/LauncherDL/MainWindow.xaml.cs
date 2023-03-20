﻿namespace LauncherDL;

// TODO:
//
//  Add download method functionality
//  Add Metadata Functionality
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

        // To be remove
        int i = 0;
        var Test = new ProgressBar();
        Test.Width = 500;
        Test.Height = 50;
        Test.Maximum = 1000;
        _windowCanvas.Add(Test);
        CompositionTarget.Rendering += delegate
        {
            Test.Value = i++;
            if(i == 1000) i = 0;
        };
        ///////////////////////
        
        InitiateStaticComponents(this);

        #if DEBUG
            ConsoleDebug.InitiateConsoleDebug();
        #endif

        config = Config.ReadConfigINI();
        FFmpegFiles.CheckFiles();
        OnStartUp.Initialize();
    }
}