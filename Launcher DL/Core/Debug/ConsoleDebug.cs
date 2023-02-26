namespace Launcher_DL.Core.Debug;

/// <summary>
/// This script is automatically discarded on release build.
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
	public static void LoadingConfig(dynamic a, dynamic b, string c)
	{
		Console.Write($"Loading {c}");
		try
		{
			switch(a.GetType().ToString())
			{
				case "System.String": a = b; break;
				case "System.Int32": a = int.Parse(b); break;
				case "System.Windows.Media.Color": a = ClrConv(b); break;
				case "System.Boolean": a = bool.Parse(b); break;
			}
			Console.SetCursorPosition(34,4 + count);
			Console.Write($"\x1b[32mLOADED! = {b}\x1b[0m\n");
		} catch
		{
			Console.SetCursorPosition(34,4 + count);
			Console.Write($"\x1b[31mFAILED! = {b}\x1b[0m\n");
		};
		count++;
	}

	public static void WindowFocused(bool isFocused)
	{
		if (isFocused) Console.WriteLine("Window is Focused!");
		else Console.WriteLine("Window is Unfocused!");
	}
}