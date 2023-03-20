namespace DLControls;

public partial class ButtonControl
{
    // Normal is default 100ms
    // faster is 50ms
    const int NORMAL_ANIMATION = 0, FASTER_ANIMATION = 1;

    List<DoubleAnimation> ControlDA;
    ThicknessAnimation ButtonMargin;
    ColorAnimation ButtonForeground;
    RectAnimation ButtonImageViewport;
    List<Storyboard> ControlsStoryboards;
    List<PropertyPath> ControlPaths = new List<PropertyPath>()
    {
        new("(Effect).Opacity"),                            // 0
        new("Width"),                                       // 1
        new("Height"),                                      // 2
        new("(Button.FontSize)"),                           // 3
        new("Background.(Brush.Opacity)"),                  // 4
        new("Margin"),                                      // 5
        new("(Button.Foreground).(SolidColorBrush.Color)"), // 6
        new("Background.(ImageBrush.Viewport)"),            // 7
    };
    List<TimeSpan> AnimationDuration;

    private void SetAnimationsValues(bool isEnter, List<TimeSpan> AnimationDuration)
    {
        switch(isEnter)
        {
            case true:
                ControlDA = new List<DoubleAnimation>()
                {
                    new(1, AnimationDuration[NORMAL_ANIMATION]),         // ButtonOpacity
                    new(260, AnimationDuration[NORMAL_ANIMATION]),       // ButtonWidth
                    new(67.5, AnimationDuration[NORMAL_ANIMATION]),      // ButtonHeight
                    new(TextSize+2, AnimationDuration[NORMAL_ANIMATION]),// ButtonText
                    new(0.85, AnimationDuration[NORMAL_ANIMATION])       // ButtonImageOpacity
                };
                ButtonMargin = new(new(-5,-1.5,0,0), AnimationDuration[NORMAL_ANIMATION]);
                ButtonForeground = new(Colors.White, AnimationDuration[NORMAL_ANIMATION]);
                ButtonImageViewport = new(new(0,0,1,1), AnimationDuration[NORMAL_ANIMATION]);
            break;
            
            case false:
                ControlDA = new List<DoubleAnimation>()
                {
                    new(0, AnimationDuration[NORMAL_ANIMATION]),       // ButtonOpacity
                    new(250, AnimationDuration[NORMAL_ANIMATION]),     // ButtonWidth
                    new(65, AnimationDuration[NORMAL_ANIMATION]) ,     // ButtonHeight
                    new(TextSize, AnimationDuration[NORMAL_ANIMATION]),// ButtonText
                    new(0, AnimationDuration[FASTER_ANIMATION])        // ButtonImageOpacity
                };
                ButtonMargin = new(new(0,0,0,0), AnimationDuration[NORMAL_ANIMATION]);
                ButtonForeground = new(Colors.Black, AnimationDuration[NORMAL_ANIMATION]);
                ButtonImageViewport = new(new(-0.3,0,1.5,1.8), AnimationDuration[FASTER_ANIMATION]);
            break;
        }
    }

    private void SetStoryboard(bool IsEnter)
    {
        if (IsAnimationOn)
            AnimationDuration = new(){ TimeSpan.FromMilliseconds(100), TimeSpan.FromMilliseconds(50) };
        else AnimationDuration = new(){ TimeSpan.Zero };

        SetAnimationsValues(IsEnter, AnimationDuration);

        // Found the Low framerate button animation bug
        // I just needed to Renew the Storyboards because its
        // stacking up thats why every hover the animation fps
        // goes down hard.
        ControlsStoryboards = new List<Storyboard>()
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

        foreach (var (STYB, index) in ControlsStoryboards.Select((value, i) => (value, i)))
        {
            DependencyObject TargetElement = UserButton;

            if (index is 4 || index is 7)
                TargetElement = (Border)GetTemplateResource<Border>("UserButtonMainBorder", UserButton);

            SetStoryboardAuto(STYB, TargetElement, ControlPaths[index]);

            switch (index)
            {
                default: STYB.Add(ControlDA[index]); break;
                case 5: STYB.Add(ButtonMargin); break;
                case 6: STYB.Add(ButtonForeground); break;
                case 7: STYB.Add(ButtonImageViewport); break;
            }

            STYB.Begin();
        }
    }
}