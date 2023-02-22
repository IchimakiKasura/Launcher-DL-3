namespace Launcher_DL.Core;

class EventHandlers
{
	public static void InitializeEventHandlers()
	{
		MainWindowStatic.Loaded += WindowsComponents.Window_Loaded;

		windowDrag.MouseDown += WindowsComponents.Window_Drag;
		Minimize.Click += TopButtons.MinimizeWindow;
		CloseButton.Click += TopButtons.CloseWindow;
	}
}

