namespace Launcher_DL.Core;

class EventHandlers
{
	public static void InitializeEventHandlers()
	{
		MainWindowStatic.Loaded += WindowsComponents.WindowLoaded;

		windowDrag.MouseDown += WindowsComponents.WindowDrag;
		Minimize.Click += TopButtons.MinimizeWindow;
		CloseButton.Click += TopButtons.CloseWindow;
	}
}

