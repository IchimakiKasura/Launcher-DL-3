namespace Launcher_DL.Core.Windows;

class WindowsComponents
{
	public static void WindowLoaded(object sender, RoutedEventArgs e)
	{
		new TransparencyConverter(MainWindowStatic).MakeTransparent();
	}

	public static void WindowFocusAnimation()
	{
		void Focus()
		{
			_ = new StoryboardApplier(WindowOpacity, MainWindowStatic, new("(Window.Effect).Opacity"));
			_ = new StoryboardApplier(WindowAnimation, windowInnerBG, new("(Control.Background).(SolidColorBrush.Color)"));
		}

		MainWindowStatic.Activated += delegate
		{
			//if (TaskBarThingy.ProgressValue == 1) TaskBarThingy.ProgressValue = 0;

			WindowOpacity = new(1, TimeSpan.FromMilliseconds(100));
			WindowAnimation = new(config.backgroundColor, TimeSpan.FromMilliseconds(100));
			Focus();
			GC.Collect();

			#if DEBUG
			ConsoleDebug.WindowFocused(true);
			#endif
		};

		MainWindowStatic.Deactivated += delegate
		{
			WindowOpacity = new(0, TimeSpan.FromMilliseconds(100));
			WindowAnimation = new(Colors.Black, TimeSpan.FromMilliseconds(100));
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
			case ProgressBarState.Hide: windowCanvas.Children.Remove(progressBar);console.ConsoleHeight = 200; break;
			case ProgressBarState.Show: windowCanvas.Children.Add(progressBar);console.ConsoleHeight = 190; break;
		}
	}

	public static async Task WindowAwaitLoad(bool a)
	{
		if(!a)
		{
			await Task.Run(()=>{
				MainWindowStatic.Dispatcher.Invoke(async()=>
				{
					while(!a)
					{
						await Task.Delay(200);
					}
				});
			});
		}
	}

	public static void FreezeComponents(bool Freeze)
	{
		UIElement[] ControlLists = 
		{
			buttonFileFormat,
			buttonDownload,
			buttonUpdate,
			buttonOpenFile,
			textBoxLink,
			textBoxName,
			comboBoxType,
			comboBoxFormat
		};

		foreach(var CL in ControlLists)
			CL.IsEnabled = true;
		
		if(Freeze)
			foreach(var CL in ControlLists)
				CL.IsEnabled = false;
	}
}