namespace Launcher_DL.Core.Windows;

class WindowsComponents
{
	public static void Window_Loaded(object sender, RoutedEventArgs e)
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
			//DebugOutput.WindowFocusDebug(true);
		};

		MainWindowStatic.Deactivated += delegate
		{
			WindowOpacity = new(0, TimeSpan.FromMilliseconds(100));
			WindowAnimation = new(Colors.Black, TimeSpan.FromMilliseconds(100));
			Focus();
			Keyboard.ClearFocus();
			//DebugOutput.WindowFocusDebug(false);
		};

	}

	public static void Window_Drag(object sender, MouseButtonEventArgs e)
	{
		if (e.ChangedButton == MouseButton.Left) MainWindowStatic.DragMove();
	}

}

