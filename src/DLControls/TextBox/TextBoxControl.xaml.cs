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
		set => SetValue(TextPlaceholderAlignmentProperty, value);
		
	}

	public string Text
	{
		get => UserTextBox.Text;
		set => UserTextBox.Text = value;
	}

	public bool isTextBoxFocused { get; set; }

	private TextBlock Placeholder;

	public TextBoxControl()
	{
		InitializeComponent();
	}

	private void ContentLoaded(object sender, RoutedEventArgs e)
	{
		Grid UserGrid = GetTemplateResource<Grid>("UserTextBoxGRID", UserTextBox);

		Placeholder = new()
		{
			Foreground = Brushes.DimGray,
			FontSize = 20,
			HorizontalAlignment = TextPlaceholderAlignment,
			IsHitTestVisible = false,
			Margin = TextPlaceholderMargin,
			Text = TextPlaceholder,
			VerticalAlignment = VerticalAlignment.Center
		};

		UserGrid.Children.Add(Placeholder);

		UserTextBox.TextChanged += delegate
		{
			if (Text == "")
			{
				UserGrid.Children.Remove(Placeholder);
				UserGrid.Children.Add(Placeholder);
			} else UserGrid.Children.Remove(Placeholder);
		};

		UserTextBox.IsEnabledChanged += delegate
		{
			UserTextBox.Foreground =
			Placeholder.Foreground = Brushes.Red;
			Placeholder.Text = "Unavailable";
			if (UserTextBox.IsEnabled)
			{
				UserTextBox.Foreground = Brushes.White;
				Placeholder.Foreground = Brushes.DimGray;
				Placeholder.Text = TextPlaceholder;
			}
		};

		UserTextBox.GotFocus += delegate { isTextBoxFocused = true; };
		UserTextBox.LostFocus += delegate { isTextBoxFocused = false; };
	}
}