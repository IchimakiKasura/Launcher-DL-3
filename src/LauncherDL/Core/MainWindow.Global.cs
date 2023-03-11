namespace LauncherDL.Core;

public partial class Global
{
	//private void Test()
	//{
	//	MainWindowStatic.
	//}

	public static 	Button					Minimize			{ get; set; }
	public static 	Button					CloseButton			{ get; set; }

	public static 	ButtonControl			buttonFileFormat	{ get; set; }
	public static 	ButtonControl			buttonDownload		{ get; set; }
	public static 	ButtonControl			buttonUpdate		{ get; set; }
	public static 	ButtonControl			buttonOpenFile		{ get; set; }

	public static 	Border					windowDrag			{ get; set; }
	public static 	Border					windowInnerBG		{ get; set; }

	public static 	ProgressBarControl		progressBar			{ get; set; }
	public static 	ConsoleControl			console				{ get; set; }

	public static 	TextBoxControl			textBoxLink			{ get; set; }
	public static 	TextBoxControl			textBoxName			{ get; set; }

	public static 	Canvas					windowCanvas		{ get; set; }

	public static 	ComboBoxControl			comboBoxType		{ get; set; }
	public static 	ComboBoxControl			comboBoxFormat		{ get; set; }

	public static 	TextBlockControl		textBlockLink		{ get; set; }
	public static 	TextBlockControl		textBlockFormat		{ get; set; }
	public static 	TextBlockControl		textBlockName		{ get; set; }
	public static 	TextBlockControl		textBlockType		{ get; set; }
}

