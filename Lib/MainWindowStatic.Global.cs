namespace Launcher_DL.Lib;

public partial class Global
{
	// Buttons
	internal static Button Minimize;
	internal static Button Open_File;
	internal static Button Open_Folder;
	internal static Button CloseButton;
	internal static ResourceDictionary.ButtonControl Button_Update;
	internal static ResourceDictionary.ButtonControl Button_Format;
	internal static ResourceDictionary.ButtonControl Button_Download;
	internal static MenuItem OpenDir_flv;
	internal static MenuItem OpenDir_mkv;
	internal static MenuItem OpenDir_webm;
	internal static MenuItem OpenDir_Audio;
	internal static MenuItem OpenDir_Video;
	internal static MenuItem OpenDir_Logs;
	internal static MenuItem OpenDir_mFourA;
	internal static MenuItem OpenDir_mpFour;
	internal static MenuItem OpenDir_mpThree;
	internal static MenuItem OpenDir_threeGP;
	internal static MenuItem OpenDir_Convert;
	internal static MenuItem OpenDir_Formatted;

	// Inputs
	internal static TextBox Input_Link;
	internal static TextBox Input_Name;
	internal static ComboBox Input_Type;
	internal static ComboBox Input_Format;

	// Window
	internal static Border WindowBG;
	internal static Border WindowDrag;
	internal static TextBlock Window_Hidden;
	internal static TaskbarItemInfo TaskBarThingy;
	internal static TextBlock Window_VersionLabel;
	internal static ProgressBar Window_ProgressBar;
	internal static DropShadowEffect Window_DropShadow;
	internal static ImageBrush Window_BackgroundName;


	// Console
	internal static RichTextBox Output_text;

	// Label
	internal static Label Text_Link;
	internal static Label Text_Name;
	internal static Label Text_Format;
	internal static Label Text_DownloadType;
	internal static ComboBoxItem ComboBox_Label_Audio;
	internal static ComboBoxItem ComboBox_Label_Video;
	internal static ComboBoxItem ComboBox_Label_Custom;
	internal static ComboBoxItem ComboBox_Label_Convert;
}
