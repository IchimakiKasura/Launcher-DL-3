namespace DLControls;

public partial class ButtonControl : UserControl
{
    public RoutedEventHandler Click;
    readonly static DependencyProperty ImageProperty =
        DependencyProperty.Register("Image", typeof(string), typeof(ButtonControl), new(null));
    readonly static DependencyProperty BorderEffectProperty =
        DependencyProperty.Register("BorderEffect", typeof(Color), typeof(ButtonControl), new(null));
    readonly static DependencyProperty TextProperty =
        DependencyProperty.Register("Text", typeof(string), typeof(ButtonControl), new("DL Button"));
    readonly static DependencyProperty IconProperty =
        DependencyProperty.Register("Icon", typeof(string), typeof(ButtonControl), new(null));
    readonly static DependencyProperty IconHeightProperty =
        DependencyProperty.Register("IconHeight", typeof(int), typeof(ButtonControl), new(50));
    readonly static DependencyProperty IconWidthProperty =
        DependencyProperty.Register("IconWidth", typeof(int), typeof(ButtonControl), new(50));
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
    public int IconWidth
	{
        get => (int)GetValue(IconWidthProperty);
        set => SetValue(IconWidthProperty, value);
	}
	public int TextSize
	{
		get => (int)GetValue(TextSizeProperty);
		set => SetValue(TextSizeProperty, value);
	}

	public ButtonControl()
    {
        InitializeComponent();

        void SetStoryboard(DoubleAnimation FontSize)
        {
	        Storyboard _Storyboard = new();
            Storyboard.SetTargetProperty(FontSize, new("(Button.FontSize)"));
		    Storyboard.SetTarget(FontSize, UserButton);
		    _Storyboard.Children.Add((Timeline)FontSize);
		    _Storyboard.Begin();
        }

        UserButton.MouseEnter += delegate
        {
            SetStoryboard(new(TextSize+3,TimeSpan.FromMilliseconds(100)));
			GC.Collect();
		};

        UserButton.MouseLeave += delegate
        {
			SetStoryboard(new(TextSize,TimeSpan.FromMilliseconds(100)));
            GC.Collect();
		};

    }

    protected virtual void OnClicked(RoutedEventArgs e)
    {
        RoutedEventHandler eh = Click;
        if (eh != null)
        {
            if (e == null) return; 
            eh(this, e);
        }
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        OnClicked(e);
		GC.Collect();
    }

}