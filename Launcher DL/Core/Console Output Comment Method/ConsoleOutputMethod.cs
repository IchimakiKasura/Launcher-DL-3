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

	public async static void ConfigOutputComment(int IsSuccess, string error = default, string Name = default)
	{
		await WindowsComponents.WindowAwaitLoad(console.IsLoaded);

		if(config.ShowSystemOutput)
		{
			switch(IsSuccess)
			{
				case 0:
					console.AddFormattedText($"<#a85192%14>[SYSTEM] <Green%14>SUCCESS <Gray%14>Config loaded");
				break;

				case 1:
					console.AddFormattedText($"<#a85192%14>[SYSTEM] <Red%14>FAILED <Gray%14>Error on loading [ {Name} ]");
					console.AddFormattedText($"<DimGray%12>ERROR: {error}", true);
				break;

				case 2:
					console.AddFormattedText($"<#a85192%14>[SYSTEM] <Red%14>FAILED <Gray%14>Default Config loaded");
				break;
			}
		}
	}
}
