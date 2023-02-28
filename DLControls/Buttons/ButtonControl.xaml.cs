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
    readonly static DependencyProperty IconWidthProperty =
        DependencyProperty.Register("IconWidth", typeof(int), typeof(ButtonControl), new(50));
	readonly static DependencyProperty TextSizeProperty =
	DependencyProperty.Register("TextSize", typeof(int), typeof(ButtonControl), new(150));
    readonly static DependencyProperty IsAnimationOnProperty = 
    DependencyProperty.Register("IsAnimationOn", typeof(bool), typeof(ButtonControl), new(true));

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
    public bool IsAnimationOn
    {
        get => (bool)GetValue(IsAnimationOnProperty);
        set => SetValue(IsAnimationOnProperty, value);
    }

	public ButtonControl()
    {
        InitializeComponent();
	}

    private void ContentLoaded(object s, RoutedEventArgs e)
    {
        Border UserButtonMainTemplate = GetTemplateResource<Border>("UserButtonMainBorder", UserButton);
		Viewbox UserButtonViewbox = GetTemplateResource<Viewbox>("UserButtonViewbox", UserButton);

        TimeSpan AnimationDuration = TimeSpan.Zero;
        TimeSpan AnimationDurationLeave = TimeSpan.Zero;

        if(IsAnimationOn)
        {
            AnimationDuration = TimeSpan.FromMilliseconds(100);
            AnimationDurationLeave = TimeSpan.FromMilliseconds(50);
        }

        void SetStoryboard(bool IsEnter)
        {
            SetAnimationsValues(IsEnter, AnimationDuration, AnimationDurationLeave);

            foreach(var (STYB, index) in ControlsStoryboards.Select((value, i) => (value,i)))
            {
                DependencyObject TargetElement = UserButton;
                if(index == 4 || index == 7) TargetElement = UserButtonMainTemplate;
				if(index == 3 )TargetElement = UserButtonViewbox;

                SetStoryboardAuto(STYB, TargetElement, ControlPaths[index]);

                switch(index)
                {
                    default: STYB.Children.Add(ControlDA[index]); break;
                    case 5: STYB.Children.Add(ButtonMargin); break;
                    case 6: STYB.Children.Add(ButtonForeground); break;
                    case 7: STYB.Children.Add(ButtonImageViewport); break;
                }

                STYB.Begin();
            }
            
        }
        SetMouseEnterLeave(UserButton, ()=>SetStoryboard(true), ()=>SetStoryboard(false));
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