namespace DLControls;

public partial class TextBlockControl : UserControl, IDLControls
{
    readonly static DependencyProperty TextProperty =
        DependencyProperty.Register("Text", typeof(string), typeof(TextBlockControl));

    public string Text
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    public UIElement UICanvas =>
        UserTextBlockMain;    

    public TextBlockControl() =>
        InitializeComponent();
}
