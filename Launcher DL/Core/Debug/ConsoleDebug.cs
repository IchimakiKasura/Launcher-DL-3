namespace Launcher_DL.Core.Debug;

/// <summary>
/// This script is automatically discarded on release build.
/// </summary>
class ConsoleDebug
{
	public static void InitiateConsoleDebug()
	{
		// Only shows when the OutputType is on "Exe" and not "WinExe"
		System.Console.OutputEncoding = System.Text.Encoding.UTF8;
		Console.Title = "LauncherDL: ==== DEBUG ====";
		Console.WriteLine("==== DEBUG ====\n");
		Console.WriteLine($"\x1b[33m[INFO] Current OS: {Environment.OSVersion}");
		Console.WriteLine("[INFO] You are now running in DEBUG mode!\x1b[0m");
	}

	public static void LoadConfig_Done(bool isFailed)
	{
		//if (Directory.Exists($"{Directory.GetCurrentDirectory()}\\{config.DefaultOutput}")) Console.WriteLine("\x1b[32m[OUTPUT]\x1b[0m \"output\" folder Found!");
		//if (config.DefaultOutput != "output" && Directory.Exists(config.DefaultOutput)) Console.WriteLine("\x1b[32m[OUTPUT]\x1b[0m custom \"output\" folder Found!");
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
}