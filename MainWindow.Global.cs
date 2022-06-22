namespace Launcher_DL;

public partial class MainWindow
{
	void StaticSetup()
	{
		// Buttons
		Global.Minimize = Minimize;
		Global.Open_File = Open_File;
		Global.Open_Folder = Open_Folder;
		Global.CloseButton = CloseButton;
		Global.Button_Update = Button_Update;
		Global.Button_Format = Button_Format;
		Global.Button_Download = Button_Download;
		Global.OpenDir_flv = ContextMenuButtons.CMB.OpenDir_flv;
		Global.OpenDir_mkv = ContextMenuButtons.CMB.OpenDir_mkv;
		Global.OpenDir_webm = ContextMenuButtons.CMB.OpenDir_webm;
		Global.OpenDir_Audio = ContextMenuButtons.CMB.OpenDir_Audio;
		Global.OpenDir_Video = ContextMenuButtons.CMB.OpenDir_Video;
		Global.OpenDir_Logs = ContextMenuButtons.CMB.OpenDir_Logs;
		Global.OpenDir_mFourA = ContextMenuButtons.CMB.OpenDir_mFourA;
		Global.OpenDir_mpFour = ContextMenuButtons.CMB.OpenDir_mpFour;
		Global.OpenDir_mpThree = ContextMenuButtons.CMB.OpenDir_mpThree;
		Global.OpenDir_threeGP = ContextMenuButtons.CMB.OpenDir_threeGP;
		Global.OpenDir_Convert = ContextMenuButtons.CMB.OpenDir_Convert;
		Global.OpenDir_Formatted = ContextMenuButtons.CMB.OpenDir_Formatted;

		// Inputs
		Global.Input_Link = Input_Link;
		Global.Input_Name = Input_Name;
		Global.Input_Type = Input_Type;
		Global.Input_Format = Input_Format;

		// Window
		Global.WindowBG = WindowBG;
		Global.WindowDrag = WindowDrag;
		Global.Window_Hidden = Window_Hidden;
		Global.TaskBarThingy = TaskBarThingy;
		Global.Window_VersionLabel = Window_VersionLabel;
		Global.Window_ProgressBar = Window_ProgressBar;
		Global.Window_DropShadow = Window_DropShadow;
		Global.Window_BackgroundName = Window_BackgroundName;

		// Console
		Global.Output_text = Output_text;

		// Label
		Global.Text_Link = Text_Link;
		Global.Text_Name = Text_Name;
		Global.Text_Format = Text_Format;
		Global.Text_DownloadType = Text_DownloadType;
		Global.ComboBox_Label_Audio = ComboBox_Label_Audio;
		Global.ComboBox_Label_Video = ComboBox_Label_Video;
		Global.ComboBox_Label_Custom = ComboBox_Label_Custom;
		Global.ComboBox_Label_Convert = ComboBox_Label_Convert;
	}
}