namespace DLControls;

public partial class ConsoleControl : UserControl
{
	public ConsoleControl()
	{
		InitializeComponent();
	}

	public double ConsoleHeight
	{
		get
		{
			return UserRichTextBox.Height;
		}
		set
		{
			UserRichTextBox.Height = value;
		}
	}

	public double ConsoleWidth
	{
		get
		{
			return UserRichTextBox.Width;
		}
		set
		{
			UserRichTextBox.Width = value;
		}
	}
}