namespace DLControls;

/// <summary>
/// Interaction logic for ProgressBarControl.xaml
/// </summary>
public partial class ProgressBarControl : UserControl
{
    readonly static DependencyProperty ValueProperty =
    DependencyProperty.Register("Value", typeof(double), typeof(ProgressBarControl));

    public enum ProgressBarState{Hide,Show}
    
    public bool IsValueExact = true;
    public double Value
    {
        get => (double)GetValue(ValueProperty);
        set
        {
            // FIXME: Make the Caller wait until the animation finished
            // smooth increase animation
            var animation = new DoubleAnimation(value, TimeSpan.FromMilliseconds(800));
            UserProgressBar.BeginAnimation(ProgressBar.ValueProperty, animation);
        }
    }

    public ProgressBarControl() =>
        InitializeComponent();
}
