namespace DLControls;

public partial class ButtonControl : UserControl
{
    public RoutedEventHandler Click;
    readonly static DependencyProperty ImageProperty =
        DependencyProperty.Register("Image", typeof(string), typeof(ButtonControl), new(null));
    readonly static DependencyProperty BorderEffectProperty =
        DependencyProperty.Register("BorderEffect", typeof(Color), typeof(ButtonControl));
    readonly static DependencyProperty TextProperty =
        DependencyProperty.Register("Text", typeof(string), typeof(ButtonControl), new("DL Button"));
    readonly static DependencyProperty IconProperty =
        DependencyProperty.Register("Icon", typeof(string), typeof(ButtonControl));
    readonly static DependencyProperty IconHeightProperty =
        DependencyProperty.Register("IconHeight", typeof(int), typeof(ButtonControl), new(50));
    readonly static DependencyProperty TextSizeProperty =
        DependencyProperty.Register("TextSize", typeof(int), typeof(ButtonControl), new(20));

    public string Image
    {
        get => (string)GetValue(ImageProperty);
        set => SetValue(ImageProperty, value);
    }
    public Color BorderEffect
    {
        get => (Color)GetValue(BorderEffectProperty);
        set => SetValue(BorderEffectProperty, value);
    }
    public string Text
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }
    public string Icon
    {
        get => (string)GetValue(IconProperty);
        set => SetValue(IconProperty, value);
    }
    public int IconHeight
    {
        get => (int)GetValue(IconHeightProperty);
        set => SetValue(IconHeightProperty, value);
    }
    public int TextSize
    {
        get => (int)GetValue(TextSizeProperty);
        set => SetValue(TextSizeProperty, value);
    }
    public bool IsAnimationOn { get; set; }

    public UIElement UICanvas =>
        UserButton;
        
    public ButtonControl() =>
        InitializeComponent();

    private void ContentLoaded(object s, RoutedEventArgs e) =>
        SetMouseEnterLeave(UserButton,()=>SetStoryboard(true),()=>SetStoryboard(false));
    
    protected virtual void OnClicked(RoutedEventArgs Event)
    {
        RoutedEventHandler eventHandler = Click;
        if (eventHandler is not null)
            if (Event is not null) 
                eventHandler(this, Event);
    }

    private void Clicked(object s, RoutedEventArgs Event) =>
        OnClicked(Event);
    
}