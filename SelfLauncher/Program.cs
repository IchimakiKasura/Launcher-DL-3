using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows;

namespace SelfLauncher
{
	internal class Program
	{

		static void Main(string[] args)
		{
			// Deletes if the actual executable is killed using Task by you because you're too curious or idk
			deleteLeftOvers();

#if DEBUG
			File.WriteAllBytes("_temp.exe", Debug.uVad);
			File.WriteAllBytes("uVad.runtimeconfig.json", Debug.uVad_runtimeconfig);
#else
			File.WriteAllBytes("_temp.exe", Release.uVad);
			File.WriteAllBytes("uVad.runtimeconfig.json", Release.uVad_runtimeconfig);
#endif

			// Hides the exec and the freaking RUNTIMECONFIG.JSON
			// the json file is the reason why i made this shit.
			SetAttribs();

			// start
			var process = Process.Start("_temp.exe");

			// waits for the app to close or idk
			process.WaitForExit();

			// deletes the created files
			deleteLeftOvers();
		}

		private static void SetAttribs()
		{
			// attrib +s +h
			Process cmd = new Process();
			ProcessStartInfo SI = new ProcessStartInfo();
			SI.FileName = "cmd.exe";
			SI.Arguments = "/C attrib +s +h _temp.exe && attrib +s +h uvad.runtimeconfig.json && exit";
			SI.WindowStyle = ProcessWindowStyle.Hidden;
			cmd.StartInfo = SI;
			cmd.Start();
		}

		private static void deleteLeftOvers()
		{
			File.Delete("_temp.exe");
			File.Delete("uVad.runtimeconfig.json");
		}
	}
}
