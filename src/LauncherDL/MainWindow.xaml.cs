using System;
namespace LauncherDL;

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

        PerformanceCounter Yeet = new("Processor", "% Processor Time", "_Total");

        var Test1 = new ProgressBar();
        var Test2 = new TextBlock();
        var Test3 = new ProgressBar();
        var Test4 = new Button()
        {
            Width = 50,
            Height = 25,
            Content = "Test"
        };
        Canvas.SetTop(Test4, 70);

        _windowCanvas.Add(Test4);
        

        Test3.Width = Test1.Width = 750;
        Test1.Height = 25;
        Test3.Height = 35;
        Test1.Maximum = 100;
        Test3.Maximum = 10000;
        Test3.BorderBrush =
        Test3.Background = Brushes.Transparent;
        Test3.BorderThickness = new(0,0,0,0);
        Test3.Foreground = Brushes.Red;
        
        Test2.FontSize = 15;
        Test2.Foreground = Brushes.White;
        Test2.Text = "N/A";

        long lastTick = 0, lastFrameRate = 0, frameRate = 0;
        double cpu = 0;
        CompositionTarget.Rendering += delegate
        {
           if (System.Environment.TickCount64 - lastTick >= 1000)
            {
                lastFrameRate = frameRate;
                frameRate = 0;
                lastTick = System.Environment.TickCount64;
                if(cpu.ToString().Length < 2) cpu += 0.01;
                cpu = Math.Round(Yeet.NextValue(), 2);
            }
            frameRate++;

            if(lastFrameRate >= 61) lastFrameRate = 60;

            Test1.Value = new Random().Next(0, 100-1);
            Test3.Value += 2;
            Test2.Text = $"CPU: {cpu}\rFPS: {lastFrameRate}\rDateNow: {DateTime.UtcNow.Ticks}";
            if(Test3.Value == Test3.Maximum) Test3.Value = 0;
        };

        Test4.Click += (s,e)=>
        {
            if(_windowCanvas.Contains(Test3))
            {
                _windowCanvas.Remove(Test3);
                _windowCanvas.Remove(Test1);
                _windowCanvas.Remove(Test2);
            }
            else
            {
                _windowCanvas.Add(Test3);
                _windowCanvas.Add(Test1);
                _windowCanvas.Add(Test2);
            }
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