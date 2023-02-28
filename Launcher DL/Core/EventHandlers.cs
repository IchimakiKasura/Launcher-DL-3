namespace Launcher_DL.Core;

class EventHandlers
{
	public static void InitializeEventHandlers()
	{
		MainWindowStatic.Loaded += WindowsComponents.WindowLoaded;

		windowDrag.MouseDown += WindowsComponents.WindowDrag;
		Minimize.Click += TopButtons.MinimizeWindow;
		CloseButton.Click += TopButtons.CloseWindow;
		windowInnerBG.MouseDown += delegate { Keyboard.ClearFocus(); };

		comboBoxType.OnItemChange += delegate
		{
			if (config.ShowSystemOutput) console.AddFormattedText($"<#a85192%14>[SYSTEM] <Gray%14>Changed TYPE to {comboBoxType.GetItemContent(ComboBoxTypes)}");
		};
	}
}

