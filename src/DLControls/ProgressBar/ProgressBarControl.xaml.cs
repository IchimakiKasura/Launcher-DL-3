namespace DLControls;

/// <summary>
/// Interaction logic for ProgressBarControl.xaml
/// </summary>
public partial class ProgressBarControl : UserControl
{
    readonly static DependencyProperty ValueProperty =
    DependencyProperty.Register("Value", typeof(double), typeof(ProgressBarControl));

    public double Value
    {
        get => (double)GetValue(ValueProperty);
        set => SetValue(ValueProperty, UserProgressBar.Value = value);
    }

    public ProgressBarControl() =>
        InitializeComponent();
}
