namespace DLControls;

/// <summary>
/// Interaction logic for ProgressBarControl.xaml
/// </summary>
public partial class ProgressBarControl : UserControl
{
    readonly static DependencyProperty ValueProperty =
    DependencyProperty.Register("Value", typeof(double), typeof(ProgressBarControl));

    public enum ProgressBarState{Hide,Show}

    public double Value
    {
        get => (double)GetValue(ValueProperty);
        set => SetValue(ValueProperty, value);
    }

    public ProgressBarControl() =>
        InitializeComponent();
}
