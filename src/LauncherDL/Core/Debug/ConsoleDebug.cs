namespace LauncherDL.Core.Debug;

/// <summary>
/// This script is automatically discarded on release build.
/// <br/>
/// So saying "Uh JUSt uSe DeBug" nah i'll pass
/// I got used to doing this.
/// </summary>
class ConsoleDebug
{
	static int count = 0;
	public static void InitiateConsoleDebug()
	{
		// Only shows when the OutputType is on "Exe" and not "WinExe"
		System.Console.OutputEncoding = System.Text.Encoding.UTF8;
		Console.Title = "LauncherDL: ==== DEBUG ====";
		Console.WriteLine("==== DEBUG ====\n");
		Console.WriteLine($"\x1b[33m[INFO] Current OS: {Environment.OSVersion}");
		Console.WriteLine("[INFO] You are now running in DEBUG mode!\x1b[0m");
	}

	public static void LoadConfigDone(bool isFailed)
	{
		//if (Directory.Exists($"{Directory.GetCurrentDirectory()}\\{config.DefaultOutput}")) Console.WriteLine("\x1b[32m[OUTPUT]\x1b[0m \"output\" folder Found!");
		//if (config.DefaultOutput != "output" && Directory.Exists(config.DefaultOutput)) Console.WriteLine("\x1b[32m[OUTPUT]\x1b[0m custom \"output\" folder Found!");
		if (!isFailed)
		{
			Console.WriteLine("-------------------------------------------------------------");
			Console.WriteLine("Config Reading Success ✅");
			return;
		}

		Console.WriteLine("-------------------------------------------------------------");
		Console.WriteLine("Config Reading Failed ❌\n");
		Console.WriteLine("Using Default Config");
	}

	// goddamn it  I got lazy naming these parameters
	public static void LoadingConfig<T>(T a, dynamic b, string c)
	{
		Console.Write($"Loading {c}");
		try
		{
			if(c == CONFIG_STR.CONFIG_FILE_TYPE)
				if(b > 3) throw new Exception("Default File type is above 3!");

			if(c == CONFIG_STR.CONFIG_BACKGROUND_NAME)
				if(!File.Exists($@"./Images/{b}")) throw new Exception("Background image not found!");

			if(a.GetType().ToString().Contains(CONFIG_STR.CONFIG_COLOR_CONTAINS)) a = ClrConv(b);
			else a = b;

			Console.SetCursorPosition(34,4 + count);
			Console.Write($"\x1b[32mLOADED! = {b}\x1b[0m\n");
		} catch
		{
			Console.SetCursorPosition(34,4 + count);
			Console.Write($"\x1b[31mFAILED! = {b}\x1b[0m\n");
		};
		count++;
	}

	public static void LoadingFFmpeg(bool a, string c)
	{
		if(a)
		{
			Console.Write($"\x1b[32m{c}\x1b[0m\n");
		} else Console.Write($"\x1b[31m{c}\x1b[0m\n");
	}

	public static void WindowFocused(bool isFocused)
	{
		if (isFocused) Console.WriteLine("Window is Focused!");
		else Console.WriteLine("Window is Unfocused!");
	}
}