﻿namespace LauncherDL.Core.Event_Handlers;

internal class EventHandlers
{
	public static void InitializeEventHandlers()
	{
		#region windows stuffs
		MainWindowStatic.Loaded 	+= WindowsComponents.WindowLoaded;

		windowDrag.MouseDown		+= WindowsComponents.WindowDrag;
		windowInnerBG.MouseDown 	+= delegate { Keyboard.ClearFocus(); };
		#endregion

		#region Buttons

		// Top buttons
		Minimize.Click 				+= TopButtons.MinimizeWindow;
		CloseButton.Click 			+= TopButtons.CloseWindow;

		// Body buttons
		buttonFileFormat.Click 		+= FileFormatButton.ButtonClicked;
		buttonDownload.Click 		+= DownloadButton.ButtonClicked;
		buttonUpdate.Click 			+= UpdateButton.ButtonClicked;
		buttonOpenFile.Click 		+= FileButton.ButtonClicked;

		#endregion

		comboBoxType.OnItemChange	+= TypeComboBox.ItemChanged;
	}
}
