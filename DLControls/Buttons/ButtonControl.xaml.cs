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
        // I know I should've merged them but 
        // its better this way for me to organize
        // until i found a solution.
        ButtonStoryboardMain();
        ButtonStoryboardIMAGE();
        ButtonStoryboardTEXT();
    }

    // NOTE: Code is kinda scuffed will refactor this if I found a solution.
    // EDIT: will try foreach or other methods that would likely to work? idk im not that of an expert at c#
    //
    // sets the storyboard for the buttons
    private void ButtonStoryboardMain()
    {
        TimeSpan AnimationDuration = TimeSpan.Zero;
        if(!IsAnimationOn) AnimationDuration = TimeSpan.FromMilliseconds(100);

        void SetStoryboard(bool IsEnter)
        {

            DoubleAnimation ButtonOpacity;
            DoubleAnimation ButtonWidth;
            DoubleAnimation ButtonHeight;
            ThicknessAnimation ButtonMargin;
            ColorAnimation ButtonForeground;

            // Lmao kinda still the same but less letters idk.
            //// List<Storyboard> Example = new List<Storyboard>()
            //// {
            ////     new(),  // STYB_ButtonOpacity
            ////     new(),  // STYB_ButtonWidth
            ////     new(),  // STYB_ButtonHeight
            ////     new(),  // STYB_ButtonMargin
            ////     new()   // STYB_ButtonForeground
            //// };
            //
            // One liner but kinda weird to understand of that repeated "new()"
            //// List<Storyboard> Example = new List<Storyboard>() {new(),new(),new(),new(),new()};

            Storyboard STYB_ButtonOpacity = new();
            Storyboard STYB_ButtonWidth = new();
            Storyboard STYB_ButtonHeight = new();
            Storyboard STYB_ButtonMargin = new();
            Storyboard STYB_ButtonForeground = new();
            
            switch(IsEnter)
            {
                case true:
                    ButtonOpacity= new(1, AnimationDuration);
                    ButtonWidth= new(260, AnimationDuration);
                    ButtonHeight = new(67.5, AnimationDuration);
                    ButtonMargin = new(new(-5,-1.5,0,0), AnimationDuration);
                    ButtonForeground = new(Colors.White, AnimationDuration);
                break;
                
                case false:
                    ButtonOpacity= new(0, AnimationDuration);
                    ButtonWidth= new(250, AnimationDuration);
                    ButtonHeight = new(65, AnimationDuration);
                    ButtonMargin = new(new(0,0,0,0), AnimationDuration);
                    ButtonForeground = new(Colors.Black, AnimationDuration);
                break;

            }


            Storyboard.SetTargetProperty(ButtonOpacity, new("(Effect).Opacity"));            
            Storyboard.SetTargetProperty(ButtonWidth, new("Width"));
            Storyboard.SetTargetProperty(ButtonHeight, new("Height"));
            Storyboard.SetTargetProperty(ButtonMargin, new("Margin"));
            Storyboard.SetTargetProperty(ButtonForeground, new("(Button.Foreground).(SolidColorBrush.Color)"));

            Storyboard.SetTarget(ButtonOpacity, UserButton);
            Storyboard.SetTarget(ButtonWidth, UserButton);
            Storyboard.SetTarget(ButtonHeight, UserButton);
            Storyboard.SetTarget(ButtonMargin, UserButton);
            Storyboard.SetTarget(ButtonForeground, UserButton);

            STYB_ButtonOpacity.Children.Add(ButtonOpacity);
            STYB_ButtonWidth.Children.Add(ButtonWidth);
            STYB_ButtonHeight.Children.Add(ButtonHeight);
            STYB_ButtonMargin.Children.Add(ButtonMargin);
            STYB_ButtonForeground.Children.Add(ButtonForeground);
            
            STYB_ButtonOpacity.Begin();
            STYB_ButtonWidth.Begin();
            STYB_ButtonHeight.Begin();
            STYB_ButtonMargin.Begin();
            STYB_ButtonForeground.Begin();
        }

        UserButton.MouseEnter += delegate {SetStoryboard(true);GC.Collect();};
        UserButton.MouseLeave += delegate {SetStoryboard(false);GC.Collect();};

    }

    // image resizing storyboard
    private void ButtonStoryboardIMAGE()
    {
        TimeSpan AnimationDurationEnter = TimeSpan.Zero;
        TimeSpan AnimationDurationLeave = TimeSpan.Zero;
        if(!IsAnimationOn)
        {
            AnimationDurationEnter = TimeSpan.FromMilliseconds(100);
            AnimationDurationLeave = TimeSpan.FromMilliseconds(50);
        }

        Border UserButtonMainTemplate = (Border)UserButton.Template.FindName("UserButtonMainBorder", UserButton);

        void SetStoryboard(bool IsEnter)
        {
            DoubleAnimation ImageOpacity;
            RectAnimation ImageViewport;

            Storyboard STYB_ImageOpacity = new();
            Storyboard STYB_ImageViewport = new();

            switch(IsEnter)
            {
                case true:
                    ImageOpacity = new(0.85, AnimationDurationEnter);
                    ImageViewport = new(new(0,0,1,1), AnimationDurationEnter);
                break;

                case false:
                    ImageOpacity = new(0, AnimationDurationLeave);
                    ImageViewport = new(new(-0.3,0,1.5,1.8), AnimationDurationLeave);
                break;
            }

            Storyboard.SetTargetProperty(ImageOpacity, new("Background.(Brush.Opacity)"));
            Storyboard.SetTargetProperty(ImageViewport, new("Background.(ImageBrush.Viewport)"));

            Storyboard.SetTarget(ImageOpacity, UserButtonMainTemplate);
            Storyboard.SetTarget(ImageViewport, UserButtonMainTemplate);

            STYB_ImageOpacity.Children.Add(ImageOpacity);
            STYB_ImageViewport.Children.Add(ImageViewport);    

            STYB_ImageOpacity.Begin();
            STYB_ImageViewport.Begin();
        }

        UserButton.MouseEnter += delegate {SetStoryboard(true);GC.Collect();};
        UserButton.MouseLeave += delegate {SetStoryboard(false);GC.Collect();};
    }

    // only resize text
    private void ButtonStoryboardTEXT()
    {
        TimeSpan AnimationDuration = TimeSpan.Zero;
        if(!IsAnimationOn) AnimationDuration = TimeSpan.FromMilliseconds(100);

		void SetStoryboard(DoubleAnimation FontSize)
		{
			Storyboard _Storyboard = new();
			Storyboard.SetTargetProperty(FontSize, new("(Button.FontSize)"));
			Storyboard.SetTarget(FontSize, UserButton);
			_Storyboard.Children.Add(FontSize);
			_Storyboard.Begin();
		}

		UserButton.MouseEnter += delegate
		{
			SetStoryboard(new(TextSize + 3, AnimationDuration));
			GC.Collect();
		};

		UserButton.MouseLeave += delegate
		{
			SetStoryboard(new(TextSize, AnimationDuration));
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