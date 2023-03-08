namespace DLControls;

/// <summary>
/// Interaction logic for ProgressBarControl.xaml
/// </summary>
public partial class ProgressBarControl : UserControl
{
	readonly static DependencyProperty ValueProperty =
	DependencyProperty.Register("Value", typeof(int), typeof(ProgressBarControl), new(0));

	public int Value
	{
		get => (int)GetValue(ValueProperty);
		set
		{
			SetValue(ValueProperty, value);

			UserProgressBar.Value = value;
		}
	}

	public ProgressBarControl()
	{
		InitializeComponent();
	}
}
