namespace DLControls;

public partial class TextBlockControl : UserControl
{
    readonly static DependencyProperty TextProperty =
        DependencyProperty.Register("Text", typeof(string), typeof(TextBlockControl));

    public string Text
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    public TextBlockControl()
    {
        InitializeComponent();
    }
}
