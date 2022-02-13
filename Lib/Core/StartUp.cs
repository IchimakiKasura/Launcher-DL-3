namespace Launcher_DL_v6;

public partial class MainWindow
{
	private void Initialize()
	{
		//idfk whats dis
		MediaTimeline.DesiredFrameRateProperty.OverrideMetadata(typeof(System.Windows.Media.Animation.Timeline), new FrameworkPropertyMetadata(60));

		WindowFocusAnimation();
		
		// help
		// EDIT: Turns out its just my CPU (2.4Ghz) is slow thats why the animations are choppy when my CPU is on full load.
		// like If chrome is opened the animation is choppy because of chrome using too much cpu.
		// my current cpu is 12 yrs old and have no money to buy new one.
		if((RenderCapability.Tier >> 16) != 2)
		{
			MessageBox.Show("Sorry it needs DX9+ cuz I'm not that good at optimizing performance.\nIf you want to get rid of this Go to the Repository/SourceCode and remove this \"IF\" statement and try ur luck\nIf it runs well on your PC","lmao",MessageBoxButton.OK,MessageBoxImage.Exclamation);
			Environment.Exit(0);
		}

		#region EventHandlers
		Input_Type.SelectionChanged += InputType;
		Button_Format.Click += FileFormat;
		Button_Download.Click += Download;
		Button_Update.Click += Update;
		Closing += Window_Close;
		KeyDown += Window_PreviewKeyDown;
		#endregion

		#region Output Log Startup Texts
		Output_text.AddFormattedText("<Gray%15>堂主の私に何か用かな？あれ、知らなかった？私が往生堂七十七代目堂主、胡桃だよ！でもあなた、ツヤのある髪に健康そうな体してる･･･そっか！仕事以外で私に用があるってことだね？<>");
		Output_text.Break("Gray");
		Output_text.AddFormattedText("<>welcome, <#ff4747%20|ExtraBlack>Hutao <>here!");

		if (Config.ShowSystemOutput) Output_text.AddFormattedText($"<#a85192%14>[SYSTEM] <Gray%14>Changed TYPE to \"{((ComboBoxItem)Input_Type.SelectedItem).Content.ToString()}\"");
		#endregion
	}

}