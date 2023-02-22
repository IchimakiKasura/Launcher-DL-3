namespace DLControls;

public partial class TextBoxControl : UserControl
{

	readonly static DependencyProperty TextPlaceholderProperty =
		DependencyProperty.Register("TextPlaceholder", typeof(string), typeof(TextBoxControl), new("Placeholder"));

	readonly static DependencyProperty TextPlaceholderAlignmentProperty =
		DependencyProperty.Register("TextPlaceholderAlignment", typeof(HorizontalAlignment), typeof(TextBoxControl), new(HorizontalAlignment.Left));

	[Browsable(false)]
	public Thickness TextPlaceholderMargin
	{
		get
		{
			if (TextPlaceholderAlignment == HorizontalAlignment.Left)
				return new(10, 2, 0, 0);
			else return new(0, 2, 0, 0);
		}
	}

	public string TextPlaceholder
	{
		get => (string)GetValue(TextPlaceholderProperty);
		set => SetValue(TextPlaceholderProperty, value);
	}

	public HorizontalAlignment TextPlaceholderAlignment
	{
		get => (HorizontalAlignment)GetValue(TextPlaceholderAlignmentProperty);
		set
		{
			SetValue(TextPlaceholderAlignmentProperty, value);
		}
	}

	public string Text
	{
		get
		{
			return UserTextBox.Text;
		}
		set
		{
			UserTextBox.Text = value;
		}
	}
	private void Text_GotFocus(object s,RoutedEventArgs e){isTextBoxFocused = true;}
	private void Text_LostFocus(object s,RoutedEventArgs e){isTextBoxFocused = false;}

	public bool isTextBoxFocused { get; set; }

	public TextBoxControl()
	{
		InitializeComponent();
	}

}
