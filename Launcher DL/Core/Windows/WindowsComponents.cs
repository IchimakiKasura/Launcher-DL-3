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
			ConsoleDebug.WindowFocused(true);
		};

		MainWindowStatic.Deactivated += delegate
		{
			WindowOpacity = new(0, TimeSpan.FromMilliseconds(100));
			WindowAnimation = new(Colors.Black, TimeSpan.FromMilliseconds(100));
			Focus();
			//Keyboard.ClearFocus();
			ConsoleDebug.WindowFocused(false);
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
			case ProgressBarState.Hide: windowCanvas.Children.Remove(progressBar); break;
			case ProgressBarState.Show: windowCanvas.Children.Add(progressBar); break;
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

	// why does the Format combobox doesnt turn to bright red its just a dim
	// unlike the others.
	public static void FreezeComponents(bool Freeze)
	{
		buttonFileFormat.IsEnabled = true;
		buttonDownload.IsEnabled = true;
		buttonUpdate.IsEnabled = true;
		buttonOpenFile.IsEnabled = true;
		textBoxLink.IsEnabled = true;
		textBoxName.IsEnabled = true;
		comboBoxType.IsEnabled = true;
		comboBoxFormat.IsEnabled = true;

		if(Freeze)
		{
			buttonFileFormat.IsEnabled = false;
			buttonDownload.IsEnabled = false;
			buttonUpdate.IsEnabled = false;
			buttonOpenFile.IsEnabled = false;
			textBoxLink.IsEnabled = false;
			textBoxName.IsEnabled = false;
			comboBoxType.IsEnabled = false;
			comboBoxFormat.IsEnabled = false;
		}
	}
}