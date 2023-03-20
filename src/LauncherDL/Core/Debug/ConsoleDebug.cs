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
    }

    public static void LoadConfigDone(bool isFailed)
    {
        //if (Directory.Exists($"{Directory.GetCurrentDirectory()}\\{config.DefaultOutput}")) ConsoleDebug.Log("\x1b[32m[OUTPUT]\x1b[0m \"output\" folder Found!");
        //if (config.DefaultOutput != "output" && Directory.Exists(config.DefaultOutput)) ConsoleDebug.Log("\x1b[32m[OUTPUT]\x1b[0m custom \"output\" folder Found!");
        if (!isFailed)
        {
            ConsoleDebug.Log("-------------------------------------------------------------");
            ConsoleDebug.Log("Config Reading Success ✅");
            ConsoleDebug.Log("-----------------------Loading FFMPEG------------------------");
            return;
        }

        ConsoleDebug.Log("-------------------------------------------------------------");
        ConsoleDebug.Log("Config Reading Failed ❌\n");
        ConsoleDebug.Log("Using Default Config");
        ConsoleDebug.Log("-----------------------Loading FFMPEG------------------------");
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

            Console.SetCursorPosition(40, Console.GetCursorPosition().Top);
            Console.Write($"\x1b[32mLOADED! = {b}\x1b[0m\n");
        } catch
        {
            Console.SetCursorPosition(40, Console.GetCursorPosition().Top);
            Console.Write($"\x1b[31mFAILED! = {b}\x1b[0m\n");
        };
    }

    public static void LoadingFFmpeg(bool a, string c)
    {
        Console.Write(a ? $"[FFMPEG] \x1b[32m{c}SUCCESS" : $"[FFMPEG] \x1b[31m{c}");
        Console.SetCursorPosition(40, Console.GetCursorPosition().Top);
        Console.Write(a ? $"FOUND\x1b[0m\n" : $"NOT FOUND\x1b[0m\n");
    }
    public static void LoadingFFmpegDone(bool a)
    {
        Console.Write(a ? $"[FFMPEG] \x1b[32mFFMPEG FILES LOADED \x1b[0m\n" : $"[FFMPEG] \x1b[31mFFMPEG FILES MISSING \x1b[0m\n");
    }

    public static void WindowFocused(bool isFocused) =>
        ConsoleDebug.Log(isFocused ? "Window is Focused!" : "Window is Unfocused!");
}