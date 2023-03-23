namespace DLControls;

public partial class ConsoleControl : UserControl
{
    readonly static DependencyProperty ConsoleHeightProperty =
        DependencyProperty.Register("ConsoleHeight", typeof(double), typeof(ConsoleControl));
    readonly static DependencyProperty ConsoleWidthProperty =
        DependencyProperty.Register("ConsoleWidth", typeof(double), typeof(ConsoleControl));

    public double ConsoleHeight
    {
        get => (double)GetValue(ConsoleHeightProperty);
        set => SetValue(ConsoleHeightProperty, value);
        
    }
    public double ConsoleWidth
    {
        get => (double)GetValue(ConsoleWidthProperty);
        set => SetValue(ConsoleWidthProperty, value);
    }

    public UIElement UICanvas =>
        UserRichTextBox;

    public ConsoleControl() =>
        InitializeComponent();
        

    public void manualScrollToEnd() => UserRichTextBox.ScrollToEnd();
}