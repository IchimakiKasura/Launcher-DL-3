using System.Threading.Tasks;
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
        set
        {
            // smooth increase animation
            DoubleAnimation animation = new(value, TimeSpan.FromMilliseconds(500));
            BeginAnimation(ValueProperty, animation);
        }
    }

    public new double Opacity
    {
        get => (double)GetValue(OpacityProperty);
        set
        {
            var Anti_Overflow = Math.Max(0, Math.Min(value, 1));

            DoubleAnimation animation = new(Anti_Overflow, TimeSpan.FromMilliseconds(300));
            BeginAnimation(OpacityProperty, animation);
        }
    }

    /// <summary>
    /// Holds the thread until the progress value is 100
    /// </summary>
    public async System.Threading.Tasks.Task AwaitCompletion()
    {
        while(Value is not 100) await Task.Delay(100);
    }

    /// <summary>
    /// Holds the thread until the Opacity hits its mark
    /// </summary>
    public async System.Threading.Tasks.Task AwaitOpacityCompletion(int TargetValue)
    {
        while(Opacity != TargetValue) await Task.Delay(100);
    }

    public ProgressBarControl() =>
        InitializeComponent();
}
