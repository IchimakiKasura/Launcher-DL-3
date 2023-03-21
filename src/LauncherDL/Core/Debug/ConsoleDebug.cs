namespace LauncherDL.Core.Debug;

/// <summary>
/// This script is automatically discarded on release build. <br/>
/// So saying "Uh JUSt uSe DeBug" bish im using vscode and rarely use <br/>
/// MSVC but I got used to doing this so its my habit.
/// </summary>
public static class ConsoleDebug
{
    public static void Log(dynamic Any) =>
        Console.WriteLine(Any);

    // Only shows when the OutputType is on "Exe" and not "WinExe"
    public static void InitiateConsoleDebug()
    {
        System.Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.Title = "LauncherDL: ==== DEBUG ====";
        ConsoleDebug.Log("==== DEBUG ====\n");
        ConsoleDebug.Log($"\x1b[33m[INFO] Current OS: {Environment.OSVersion}");
        ConsoleDebug.Log("[INFO] You are now running in DEBUG mode!\x1b[0m");
        ConsoleDebug.Log("\x1b[35m[SYSTEM] Loading resources \x1b[0m");

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

        windowCanvas.Add(Test4);
        
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
            if(windowCanvas.Contains(Test3))
            {
                windowCanvas.Remove(Test3);
                windowCanvas.Remove(Test1);
                windowCanvas.Remove(Test2);
            }
            else
            {
                windowCanvas.Add(Test3);
                windowCanvas.Add(Test1);
                windowCanvas.Add(Test2);
            }
        };
        ConsoleDebug.Log("\n-----------------------Loading CONFIG------------------------");
    }

    public static void LoadConfigDone(bool isFailed)
    {
        //if (Directory.Exists($"{Directory.GetCurrentDirectory()}\\{config.DefaultOutput}")) ConsoleDebug.Log("\x1b[32m[OUTPUT]\x1b[0m \"output\" folder Found!");
        //if (config.DefaultOutput != "output" && Directory.Exists(config.DefaultOutput)) ConsoleDebug.Log("\x1b[32m[OUTPUT]\x1b[0m custom \"output\" folder Found!");
        if (!isFailed)
        {
            ConsoleDebug.Log("-------------------------------------------------------------");
            ConsoleDebug.Log("[CONFIG] Config Reading Success ✅");
            ConsoleDebug.Log("\n-----------------------Loading FFMPEG------------------------");
            return;
        }

        ConsoleDebug.Log("-------------------------------------------------------------");
        ConsoleDebug.Log("[CONFIG] Config Reading Failed ❌\n");
        ConsoleDebug.Log("[CONFIG] Using Default Config");
        ConsoleDebug.Log("\n-----------------------Loading FFMPEG------------------------");
    }

    // goddamn it  I got lazy naming these parameters
    public static void LoadingConfig<T>(T a, dynamic b, string c)
    {
        Console.Write($"[CONFIG] Loading {c}");
        try
        {
            if(c is CONFIG_STR.CONFIG_FILE_TYPE)
                if(b > 3) throw new Exception("Default File type is above 3!");

            if(c is CONFIG_STR.CONFIG_BACKGROUND_NAME)
                if(!File.Exists($@"./Images/{b}")) throw new Exception("Background image not found!");

            if(a.GetType().ToString().Contains(CONFIG_STR.CONFIG_COLOR_CONTAINS)) a = ClrConv(b);
            else a = b;

            Console.SetCursorPosition(43, Console.GetCursorPosition().Top);
            Console.Write($"\x1b[32mLOADED! = {b}\x1b[0m\n");
        } catch
        {
            Console.SetCursorPosition(43, Console.GetCursorPosition().Top);
            Console.Write($"\x1b[31mFAILED! = {b}\x1b[0m\n");
        };
    }

    public static void LoadingFFmpeg(bool a, string c)
    {
        Console.Write(a ? $"[FFMPEG] \x1b[32m{c}SUCCESS" : $"[FFMPEG] \x1b[31m{c}");
        Console.SetCursorPosition(43, Console.GetCursorPosition().Top);
        Console.Write(a ? $"FOUND\x1b[0m\n" : $"NOT FOUND\x1b[0m\n");
    }
    public static void LoadingFFmpegDone(bool a)
    {
        ConsoleDebug.Log("-------------------------------------------------------------");
        Console.Write(a ? $"[FFMPEG] \x1b[32mFFMPEG FILES LOADED \x1b[0m\n" : $"[FFMPEG] \x1b[31mFFMPEG FILES MISSING \x1b[0m\n");
        ConsoleDebug.Log("\n\n--------------------App startup done!------------------------");
    }

    public static void WindowFocused(bool isFocused) =>
        ConsoleDebug.Log(isFocused ? "Window is Focused!" : "Window is Unfocused!");
}