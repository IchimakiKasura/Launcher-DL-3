namespace Launcher_DL_v6;

public partial class MainWindow
{
	private void Initialize()
	{
		WindowFocusAnimation();

		#region Output Log Startup Texts
		Output_text.AddFormattedText("<Gray%15>堂主の私に何か用かな？あれ、知らなかった？私が往生堂七十七代目堂主、胡桃だよ！でもあなた、ツヤのある髪に健康そうな体してる･･･そっか！仕事以外で私に用があるってことだね？<>");
		Output_text.Break("Gray");
		Output_text.AddFormattedText("<>welcome, <#ff4747%20|ExtraBlack>Hutao <>here!");
		#endregion
		
	}
}