using static Launcher_DL.Core.Console_Output_Comment_Method.CONSOLEOUTPUTMETHOD_STR;
namespace Launcher_DL.Core.Console_Output_Comment_Method;

internal static class ConsoleOutputMethod
{
	/// <summary>
    /// extend ConsoleControl
    /// </summary>
    public static void DLAddConsole(this ConsoleControl console,string Type, string FormattedText, bool Italic = false, bool NoNL = false) => console.AddFormattedText($"{Type} {FormattedText}", Italic, NoNL);

	public static void StartUpOutputComments()
	{
		console.AddFormattedText(CONSOLE_START);
		console.Break("Gray");

		console.AddFormattedText("<>welcome, <#ff4747%20|ExtraBlack>Hutao <>here!");

		// we do a little troll
		#if !DEBUG
			InitiateTheWindow.InitiateMePlease = "Initiate";
		#endif
	}

	public async static void ConfigOutputComment(int IsSuccess, string error = default, string Name = default)
	{
		await WindowsComponents.WindowAwaitLoad(console.IsLoaded);

		if(config.ShowSystemOutput)
		{
			switch(IsSuccess)
			{
				case 0: console.DLAddConsole(CONSOLE_SYSTEM_STRING, "<Green%14>SUCCESS <Gray%14>Config loaded");
				break;

				case 1:
					console.DLAddConsole(CONSOLE_SYSTEM_STRING, $"<Red%14>FAILED <Gray%14>Error on loading [ {Name} ]");
					console.AddFormattedText($"<DimGray%12>ERROR: {error}", true);
				break;

				case 2: console.DLAddConsole(CONSOLE_SYSTEM_STRING,"<Red%14>FAILED <Gray%14>Default Config loaded");
				break;
			}
		}
	}

	public static void TypeChangedOutputComment()
	{
		if (config.ShowSystemOutput)
			console.DLAddConsole(CONSOLE_SYSTEM_STRING,$"<Gray%14>Changed TYPE to {comboBoxType.GetItemContent}");
	}
}
