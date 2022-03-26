namespace Launcher_DL_v6;

public partial class MainWindow
{
	private async void Initialize()
	{
		//idfk whats dis
		MediaTimeline.DesiredFrameRateProperty.OverrideMetadata(typeof(Timeline), new FrameworkPropertyMetadata(60));

		WindowFocusAnimation();

		// help
		// EDIT: Turns out its just my CPU (2.4Ghz) is slow thats why the animations are choppy when my CPU is on full load.
		// like If chrome is opened the animation is choppy because of chrome using too much cpu.
		// my current cpu is 12 yrs old and have no money to buy new one.
		//
		// EDIT 3/25/22: Got a new CPU which is faster (Xeon E5 2640) I know its still old but its still works,
		// 6C/12T 2.5Ghz Turbo to 3Ghz (2.8Ghz).
		if ((RenderCapability.Tier >> 16) != 2)
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

		#region Open Folder thing
		Open_Folder.Click += delegate { OpenFolder(Config.DefaultOutput); };

		OpenDir_Audio.Click += delegate { OpenFolder($"{Config.DefaultOutput}\\Audio"); };
		OpenDir_Video.Click += delegate { OpenFolder($"{Config.DefaultOutput}\\Video"); };

		OpenDir_webm.Click += delegate { OpenFolder($"{Config.DefaultOutput}\\formatted\\webm"); };
		OpenDir_mFourA.Click += delegate { OpenFolder($"{Config.DefaultOutput}\\formatted\\m4a"); };
		OpenDir_mpFour.Click += delegate { OpenFolder($"{Config.DefaultOutput}\\formatted\\mp4"); };
		OpenDir_mpThree.Click += delegate { OpenFolder($"{Config.DefaultOutput}\\formatted\\mp3"); };
		#endregion

		#endregion

		#region Output Log Startup Texts
		Output_text.AddFormattedText("<Gray%15>堂主の私に何か用かな？あれ、知らなかった？私が往生堂七十七代目堂主、胡桃だよ！でもあなた、ツヤのある髪に健康そうな体してる･･･そっか！仕事以外で私に用があるってことだね？<>");
		Output_text.Break("Gray");

		Output_text.AddFormattedText("<>welcome, <#ff4747%20|ExtraBlack>Hutao <>here!");
		if (Config.ShowSystemOutput) Output_text.AddFormattedText($"<#a85192%14>[SYSTEM] <Gray%14>Changed TYPE to \"{((ComboBoxItem)Input_Type.SelectedItem).Content}\"");
		#endregion

		await LoadConfig();
		System_Language_Handler.LoadLanguage();

		if (Config.DefaultOutput == "output")
		{
			if (Directory.Exists($"{Directory.GetCurrentDirectory()}\\{Config.DefaultOutput}")) Open_Folder.Visibility = Visibility.Visible;
		}
		else
		{
			if (Directory.Exists(Config.DefaultOutput)) Open_Folder.Visibility = Visibility.Visible;
		}

	}

}