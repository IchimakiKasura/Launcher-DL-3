namespace LauncherDL.Core.Windows;

class WindowsComponents
{
	static DoubleAnimation WindowOpacity;
	static ColorAnimation WindowAnimation;

	public static void WindowLoaded(object sender, RoutedEventArgs e) =>
		new TransparencyConverter(MainWindowStatic).MakeTransparent();

	public static void WindowFocusAnimation()
	{
		void Focus()
		{
			new StoryboardApplier(WindowOpacity		,	MainWindowStatic	,	new(			"(Window.Effect).Opacity"		  )	);
			new StoryboardApplier(WindowAnimation	,	windowInnerBG		,	new("(Control.Background).(SolidColorBrush.Color)")	);
		}

		MainWindowStatic.Activated += (s,e)=>
		{
			//if (TaskBarThingy.ProgressValue == 1) TaskBarThingy.ProgressValue = 0;

			WindowOpacity		= new(1, TimeSpan.FromMilliseconds(100));
			WindowAnimation		= new(config.backgroundColor, TimeSpan.FromMilliseconds(100));
			Focus();
			GC.Collect();

			#if DEBUG
				ConsoleDebug.WindowFocused(true);
			#endif
		};

		MainWindowStatic.Deactivated += (s,e)=>
		{
			WindowOpacity		= new(0, TimeSpan.FromMilliseconds(100));
			WindowAnimation		= new(Colors.Black, TimeSpan.FromMilliseconds(100));
			Focus();
			
			#if DEBUG
				ConsoleDebug.WindowFocused(false);
			#endif
		};

	}

	public static void WindowDrag(object sender, MouseButtonEventArgs e)
	{
		if (e.ChangedButton == MouseButton.Left) MainWindowStatic.DragMove();
	}

	public static void WindowProgressBar(ProgressBarState State)
	{
		switch(State)
		{
			case ProgressBarState.Hide: windowCanvas.Children.Remove	(progressBar);	console.ConsoleHeight = 217; break;
			case ProgressBarState.Show: windowCanvas.Children.Add		(progressBar);	console.ConsoleHeight = 190; break;
		}
		console.manualScrollToEnd();
	}

	public static async Task WindowAwaitLoad(bool a)
	{
		// holy shit, compare it to the old one lmao
		if(!a) await Task.Run(()=> MainWindowStatic.Dispatcher.Invoke(async()=>{ while(!a) await Task.Delay(200); }));
	}

	// Is it bad to just call it without parameters to know if its freezed or not?
	// nah its my code and I know when to call the method but yeah it does look bad practice
	public static void FreezeComponents()
	{
		foreach(var CL in ControlLists)
			CL.IsEnabled = !CL.IsEnabled;
		
		// if(buttonOpenFile)

		if(!buttonFileFormat.IsEnabled) WindowProgressBar(ProgressBarState.Show);
			else WindowProgressBar(ProgressBarState.Hide);
	}
}