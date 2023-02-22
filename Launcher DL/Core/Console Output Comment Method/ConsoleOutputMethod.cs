namespace Launcher_DL.Core.Console_Output_Comment_Method;

internal class ConsoleOutputMethod
{
	public static void StartUpOutputComments()
	{
		console.AddFormattedText("<Gray%15>堂主の私に何か用かな？あれ、知らなかった？私が往生堂七十七代目堂主、胡桃だよ！でもあなた、ツヤのある髪に健康そうな体してる･･･そっか！仕事以外で私に用があるってことだね？<>");
		console.Break("Gray");

		console.AddFormattedText("<>welcome, <#ff4747%20|ExtraBlack>Hutao <>here!");
		if (config.ShowSystemOutput) console.AddFormattedText($"<#a85192%14>[SYSTEM] <Gray%14>Changed TYPE to W.I.P"); //\"{((ComboBoxItem)Input_Type.SelectedItem).Content}\"

		#if !DEBUG
		InitiateTheWindow.InitiateMePlease = "Initiate";
		#endif
	}

}

