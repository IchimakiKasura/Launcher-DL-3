namespace DLControls;

/// <summary>
/// Interaction logic for ProgressBarControl.xaml
/// </summary>
public partial class ProgressBarControl : UserControl
{
    readonly static DependencyProperty ValueProperty =
        DependencyProperty.Register("Value", typeof(double), typeof(ProgressBarControl));
    readonly new static DependencyProperty OpacityProperty =
        DependencyProperty.Register("Opacity", typeof(double), typeof(ProgressBarControl));

    public enum ProgressBarState{Hide,Show}
    
    public UIElement UICanvas =>
        UserProgressBar;

    public double Value
    {
        get => (double)GetValue(ValueProperty);
        set => SetValueAnimated(this, ValueProperty, value, TimeSpan.FromMilliseconds(500));
        
    }

    public new double Opacity
    {
        get => (double)GetValue(OpacityProperty);
        set => SetValueAnimated(this, OpacityProperty, Math.Max(0, Math.Min(value, 1)), TimeSpan.FromMilliseconds(300));
    }

    /// <summary>
    /// Holds the thread until the progress value is 100
    /// </summary>
    public async Task AwaitCompletionAsync()
    {
        while(Value is not 100) await Task.Delay(100);
    }

    /// <summary>
    /// Holds the thread until the Opacity hits its mark
    /// </summary>
    public async Task AwaitOpacityCompletionAsync(int TargetValue)
    {
        while(Opacity != TargetValue) await Task.Delay(100);
    }

    public ProgressBarControl() =>
        InitializeComponent();
}
