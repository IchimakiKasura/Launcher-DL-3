namespace Launcher_DL_v6;

public class DebugOutput
{
    static bool Started = false;
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
        if(IsDebug)Console.WriteLine("Application is Closing");
    } 
    public static void CloseCancel()
    {
        if(IsDebug)Console.WriteLine("Cannot Close the Application while Downloading!");
    }

    public static void LoadConfig_Debug(dynamic Match)
    {
        if(!IsDebug) return;
        if (!Started) Console.WriteLine("\nLoading Configs:\n");
        Started = true;
        Console.WriteLine(Match);
    }
    public static void LoadConfig_Done(bool isFailed)
    {
        if(!IsDebug) return;
        if(!isFailed)
        {
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("Config Reading Success ✔️");
            return;
        }

        Console.WriteLine("---------------------------------------------");
        Console.WriteLine("Config Reading Failed ❌");
        Console.WriteLine("Using Default Config");
    }
    
    public static void WindowFocusDebug(bool IsFocused)
    {
        if(!IsDebug) return;
        if(IsFocused) 
        {
            Console.WriteLine("Application is Now Focused");
            return;
        }
        Console.WriteLine("Application is Unfocused");
    }

    public static void Button_Clicked(string WhatButton)
    {
        if(!IsDebug) return;
        switch(WhatButton)
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
        if(!IsDebug) return;
        switch(WhatButton)
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
        if(IsDebug)Console.WriteLine($"\x1b[32m[FORMAT ADDED]\x1b[0m file format: {options.format},   resolution: {options.resolution},    size: {options.size}");
    }

    public static void ERROR_Debug(string Text)
    {
        if(IsDebug)Console.WriteLine($"\x1b[31m[I don't feel so good]:\n{Text}\x1b[0m\n---------------------------------------------");
    }

    public static void Selected_Language(string text)
    {
        if(IsDebug)Console.WriteLine($"\x1b[32m[LANGUAGE]\x1b[0m Current Language: {text}");
    }

    public static void Selected_Language_Error(string text)
    {
        if(IsDebug)Console.WriteLine($"\x1b[31m[LANGUAGE]\x1b[0m Error Can't Recognize \"{text}\", Please Check again.");
    }

    // public static async void Test_Debug()
    // {
    //     if(IsDebug)Console.WriteLine($"\x1b[33m[TEST DEBUG]\x1b[0m Started!\n");
        
    //     MW.Input_Link.Text = "https://www.youtube.com/watch?v=3vSxHROQ4Hs";

    //     // File Format test
    //     if(IsDebug)Console.WriteLine($"\x1b[33m[TEST DEBUG]\x1b[0m File format test");

    //     // Video only [no sound]
    //     if(IsDebug)Console.WriteLine($"\x1b[33m[TEST DEBUG]\x1b[0m Video [No sound]");
    //     MW.Input_Type.SelectedIndex = 0;
    //     MW.Input_Format.Text = "313";
    //     MW.Input_Name.Text = "Video [No sound]";
    //     await Task.Run(delegate {Thread.Sleep(2000);});

    //     // Video only [Type]
    //     if(IsDebug)Console.WriteLine($"\x1b[33m[TEST DEBUG]\x1b[0m Video [Type]");
    //     MW.Input_Type.SelectedIndex = 1;
    //     MW.Input_Name.Text = "Video [Type]";
    //     await Task.Run(delegate {Thread.Sleep(2000);});


    //     // audio only
    //     if(IsDebug)Console.WriteLine($"\x1b[33m[TEST DEBUG]\x1b[0m Audio");
    //     MW.Input_Type.SelectedIndex = 2;
    //     MW.Input_MpThreeFormat.IsChecked = false;
    //     MW.Input_Name.Text = "Audio";
    //     await Task.Run(delegate {Thread.Sleep(2000);});


    //     // audio only [mp3 format]
    //     if(IsDebug)Console.WriteLine($"\x1b[33m[TEST DEBUG]\x1b[0m Audio [mp3]");
    //     MW.Input_Type.SelectedIndex = 2;
    //     MW.Input_MpThreeFormat.IsChecked = true;
    //     MW.Input_Name.Text = "Audio [mp3]";
    //     await Task.Run(delegate {Thread.Sleep(2000);});


    //     // video with audio
    //     if(IsDebug)Console.WriteLine($"\x1b[33m[TEST DEBUG]\x1b[0m Custom");
    //     MW.Input_Type.SelectedIndex = 0;
    //     MW.Input_Format.Text = "137+140";
    //     MW.Input_Name.Text = "Custom";
    //     await Task.Run(delegate {Thread.Sleep(2000);});


    //     if(IsDebug)Console.WriteLine($"\x1b[33m[TEST DEBUG]\x1b[0m Ended!\n");
    //     MW.Input_Link.Text = string.Empty;
    //     MW.Input_Name.Text = string.Empty;
    //     MW.Input_Format.Text = "Best";

    // }

}