namespace Launcher_DL_v6;

public class DebugOutput
{
    static bool Started = false;

    // Added this because I think it can cause performance issues
    public static bool IsDebug = false;

    public static void StartUp()
    {
        // Only shows when the OutputType is on "Exe" and not "WinExe"
        Console.OutputEncoding = Encoding.UTF8;
        Console.Title = "LauncherDL: ==== DEVELOPMENT/EXPERIMENTAL BUILD VERSION ====";
        Console.WriteLine("==== DEVELOPMENT/EXPERIMENTAL BUILD VERSION ====");
    }

    public static void Close()
    {
        if (IsDebug) Console.WriteLine("Application is Closing");
    }
    public static void CloseCancel()
    {
        if (IsDebug) Console.WriteLine("Cannot Close the Application while Downloading!");
    }

    public static void LoadConfig_Debug(dynamic Match)
    {
        if (!IsDebug) return;
        if (!Started) Console.WriteLine("\nLoading Configs:\n");
        Started = true;
        Console.WriteLine(Match);
    }
    public static void LoadConfig_Done(bool isFailed)
    {
        if (!IsDebug) return;
        if (Directory.Exists($"{Directory.GetCurrentDirectory()}\\{Launcher_DL_v6.MainWindow.MW.Config.DefaultOutput}")) Console.WriteLine("\x1b[32m[OUTPUT]\x1b[0m \"output\" folder Found!");
        if (Launcher_DL_v6.MainWindow.MW.Config.DefaultOutput != "output" && Directory.Exists(Launcher_DL_v6.MainWindow.MW.Config.DefaultOutput)) Console.WriteLine("\x1b[32m[OUTPUT]\x1b[0m custom \"output\" folder Found!");
        if (!isFailed)
        {
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("Config Reading Success ✔️");
            return;
        }

        Console.WriteLine("---------------------------------------------");
        Console.WriteLine("Config Reading Failed ❌\n");
        Console.WriteLine("Using Default Config");
    }

    public static void WindowFocusDebug(bool IsFocused)
    {
        if (!IsDebug) return;
        if (IsFocused)
        {
            Console.WriteLine("Application is Now Focused");
            return;
        }
        Console.WriteLine("Application is Unfocused");
    }

    public static void Button_Clicked(string WhatButton)
    {
        if (!IsDebug) return;
        switch (WhatButton)
        {
            case "format":
                Console.WriteLine("\x1b[32m[CLICKED]\x1b[0m User has clicked the Format button (Akira)");
                break;
            case "download":
                Console.WriteLine("\x1b[32m[CLICKED]\x1b[0m User has clicked the download button (Astolfo)");
                break;
            case "update":
                Console.WriteLine("\x1b[32m[CLICKED]\x1b[0m User has clicked the update button (Venti)");
                break;
        };
    }

    public static void Button_Output(string WhatButton, dynamic Download = default)
    {
        if (!IsDebug) return;
        switch (WhatButton)
        {
            case "format":
                Console.WriteLine("Checking File Formats");
                break;
            case "download":
                Console.WriteLine($"\x1b[32m===== DOWNLOAD INFO ======\x1b[0m");
                Console.WriteLine($"Download Type:	 {Download.DT}");
                Console.WriteLine($"Name:		 {Download.Name}");
                Console.WriteLine($"Format:		 {Download.Format}");
                Console.WriteLine($"Link:		{Download.Link}");
                Console.WriteLine($"Force MP3:	{Download.MP3}");
                Console.WriteLine($"Playlist?:	{Download.Playlist}");
                break;
            case "update":
                Console.WriteLine("Updating");
                break;
        };
    }

    public static void FormatAdderDebug(dynamic options)
    {
        if (IsDebug) Console.WriteLine($"\x1b[32m[FORMAT ADDED]\x1b[0m file format: {options.format},   resolution: {options.resolution},    size: {options.size}");
    }

    public static void ERROR_Debug(string Text)
    {
        if (IsDebug) Console.WriteLine($"\x1b[31m[I don't feel so good]:\n{Text}\x1b[0m\n---------------------------------------------");
    }

    public static void Selected_Language(string text)
    {
        if (text == "japanese" ||
        text == "tagalog" ||
        text == "english" ||
        text == "default" ||
        text == "bruh")
        {
            if (IsDebug) Console.WriteLine($"\x1b[32m[LANGUAGE]\x1b[0m Current Language: {text}");
        }
        else
        {
            if (IsDebug) Console.WriteLine($"\x1b[31m[LANGUAGE]\x1b[0m Error Can't Recognize \"{text}\", Please Check again.");
        }
    }

}