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

	#region StoryboardComponents
	List<DoubleAnimation> ControlDA;
	ThicknessAnimation ButtonMargin;
	ColorAnimation ButtonForeground;
	RectAnimation ButtonImageViewport;
	List<Storyboard> ControlsStoryboards = new List<Storyboard>()
	{
		new(),  // STYB_ButtonOpacity
        new(),  // STYB_ButtonWidth
        new(),  // STYB_ButtonHeight
        new(),  // STYB_ButtonText
        new(),  // STYB_ButtonImageOpacity
        new(),  // STYB_ButtonMargin
        new(),  // STYB_ButtonForeground
        new(),  // STYB_ButtonImageViewport
    };
	List<PropertyPath> ControlPaths = new List<PropertyPath>()
	{
		new("(Effect).Opacity"),                            // 0
        new("Width"),                                       // 1
        new("Height"),                                      // 2
        new("Width"),										// 3
        new("Background.(Brush.Opacity)"),                  // 4
        new("Margin"),                                      // 5
        new("(Button.Foreground).(SolidColorBrush.Color)"), // 6
        new("Background.(ImageBrush.Viewport)"),            // 7
    };
	#endregion

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
            switch(IsEnter)
            {
                case true:
                    ControlDA = new List<DoubleAnimation>()
                    {
                        new(1, AnimationDuration),         // ButtonOpacity
                        new(260, AnimationDuration),       // ButtonWidth
                        new(67.5, AnimationDuration),      // ButtonHeight
                        new(TextSize+15, AnimationDuration),// ButtonText
                        new(0.85, AnimationDuration)       // ButtonImageOpacity
                    };
                    ButtonMargin = new(new(-5,-1.5,0,0), AnimationDuration);
                    ButtonForeground = new(Colors.White, AnimationDuration);
                    ButtonImageViewport = new(new(0,0,1,1), AnimationDuration);
                break;
                
                case false:
                    ControlDA = new List<DoubleAnimation>()
                    {
                        new(0, AnimationDuration),       // ButtonOpacity
                        new(250, AnimationDuration),     // ButtonWidth
                        new(65, AnimationDuration) ,     // ButtonHeight
                        new(TextSize, AnimationDuration),// ButtonText
                        new(0, AnimationDurationLeave)   // ButtonImageOpacity
                    };
                    ButtonMargin = new(new(0,0,0,0), AnimationDuration);
                    ButtonForeground = new(Colors.Black, AnimationDuration);
                    ButtonImageViewport = new(new(-0.3,0,1.5,1.8), AnimationDurationLeave);
                break;

            }

            foreach(var (STYB, index) in ControlsStoryboards.Select((value, i) => (value,i)))
            {
                Storyboard.SetTargetProperty(ControlsStoryboards[index], ControlPaths[index]);
                DependencyObject TargetElement = UserButton;
                
                if(index == 4 || index == 7) TargetElement = UserButtonMainTemplate;
				if(index == 3 )TargetElement = UserButtonViewbox;

				Storyboard.SetTarget(STYB, TargetElement);

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

        UserButton.MouseEnter += delegate {SetStoryboard(true);GC.Collect();};
        UserButton.MouseLeave += delegate {SetStoryboard(false);GC.Collect();};
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