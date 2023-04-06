namespace DLControls;

public partial class ButtonControl
{
    ImmutableList<Timeline> ControlDA;
    TimeSpan AnimationDuration;
    readonly ImmutableList<PropertyPath> ControlPaths =
        ImmutableList.Create<PropertyPath>(
            new(BUTTON_OPACITY),    // 0
            new(BUTTON_WIDTH),      // 1
            new(BUTTON_HEIGHT),     // 2
            new(BUTTON_FONTSIZE),   // 3
            new(IMAGE_OPACITY),     // 4
            new(IMAGE_MARGIN),      // 5
            new(BUTTON_FONTCOLOR),  // 6
            new(IMAGE_VIEWPORT)     // 7
        );

    private void SetAnimationsValues(bool isEnter, TimeSpan animationDuration)
    {
        ControlDA = ImmutableList<Timeline>.Empty;

        //  Variable Names      | Boolean |        If its true         |       If its False      |
        var ButtonOpacity       = isEnter ?                          1 :                        0;
        var ButtonWidth         = isEnter ?                        260 :                      250;
        var ButtonHeight        = isEnter ?                       67.5 :                       65;
        var ButtonText          = isEnter ?                 TextSize+2 :                 TextSize;
        var ButtonImageOpacity  = isEnter ?                       0.85 :                        0;
        var buttonMargin        = isEnter ? new Thickness(-5,-1.5,0,0) :         new Thickness(0);
        var buttonForeground    = isEnter ?               Colors.White :             Colors.Black;
        var buttonImageViewport = isEnter ?          new Rect(0,0,1,1) : new Rect(-0.3,0,1.5,1.8);

        ControlDA = ImmutableList.Create<Timeline>(
            new DoubleAnimation     (ButtonOpacity       , animationDuration),
            new DoubleAnimation     (ButtonWidth         , animationDuration),
            new DoubleAnimation     (ButtonHeight        , animationDuration),
            new DoubleAnimation     (ButtonText          , animationDuration),
            new DoubleAnimation     (ButtonImageOpacity  , animationDuration),
            new ThicknessAnimation  (buttonMargin        , animationDuration),
            new ColorAnimation      (buttonForeground    , animationDuration),
            new RectAnimation       (buttonImageViewport , animationDuration)
        );

        ((RectAnimation)ControlDA[7]).EasingFunction = isEnter ?
        new PowerEase()
        {
            EasingMode = EasingMode.EaseIn,
            Power = 0.2
        }
        :
        new PowerEase()
        {
            EasingMode = EasingMode.EaseOut,
            Power = 0.5
        };
    }

    private void SetStoryboard(bool IsEnter)
    {
        AnimationDuration = IsAnimationOn ? TimeSpan.FromMilliseconds(100) : TimeSpan.Zero;
        
        SetAnimationsValues(IsEnter, AnimationDuration);

        ref var ControlAnimations = ref MemoryMarshal.GetArrayDataReference(ControlDA.ToArray());
        ref var ControlPathRef = ref MemoryMarshal.GetArrayDataReference(ControlPaths.ToArray());

        var storyboard = new Storyboard();
        DependencyObject TargetElement;
        var index = 0;

        while(index <= 7)
        {
            if(index is 4 || index is 7)
                TargetElement = GetTemplateResource<Border>(BORDER_RESOURCE, UserButton);
            else TargetElement = UserButton;

            ref var ControlTimeline = ref Unsafe.Add(ref ControlAnimations, index);

            SetStoryboardAuto(ControlTimeline, TargetElement, Unsafe.Add(ref ControlPathRef, index));
            storyboard.Children.Add(ControlTimeline);

            index++;
        }

        storyboard.Begin();
    }
}