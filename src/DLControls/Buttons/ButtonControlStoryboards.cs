namespace DLControls;

public partial class ButtonControl
{
    List<DoubleAnimation> ControlDA;
    ThicknessAnimation ButtonMargin;
    ColorAnimation ButtonForeground;
    RectAnimation ButtonImageViewport;
    List<Storyboard> ControlsStoryboards;
    List<PropertyPath> ControlPaths = new List<PropertyPath>()
    {
        new(BUTTON_OPACITY),    // 0
        new(BUTTON_WIDTH),      // 1
        new(BUTTON_HEIGHT),     // 2
        new(BUTTON_FONTSIZE),   // 3
        new(IMAGE_OPACITY),     // 4
        new(IMAGE_MARGIN),      // 5
        new(BUTTON_FONTCOLOR),  // 6
        new(IMAGE_VIEWPORT),    // 7
    };
    List<TimeSpan> AnimationDuration;

    // ChatGPT says it so fuck it, ternary it is because fuck if-else and switch;
    private void SetAnimationsValues(bool isEnter, List<TimeSpan> AnimationDuration)
    {
        //  Variable Names      | Boolean |        If its true         |   If its False  |
        var ButtonOpacity       = isEnter ?                          1 :                0;
        var ButtonWidth         = isEnter ?                        260 :              250;
        var ButtonHeight        = isEnter ?                       67.5 :               65;
        var ButtonText          = isEnter ?                 TextSize+2 :         TextSize;
        var ButtonImageOpacity  = isEnter ?                       0.85 :                0;
        var buttonMargin        = isEnter ? new Thickness(-5,-1.5,0,0) : new Thickness(0);
        var buttonForeground    = isEnter ?               Colors.White :     Colors.Black;

        ControlDA = new List<DoubleAnimation>()
        {
            new(ButtonOpacity       , AnimationDuration[NORMAL_ANIMATION]),
            new(ButtonWidth         , AnimationDuration[NORMAL_ANIMATION]),
            new(ButtonHeight        , AnimationDuration[NORMAL_ANIMATION]),
            new(ButtonText          , AnimationDuration[NORMAL_ANIMATION]),
            new(ButtonImageOpacity  , AnimationDuration[NORMAL_ANIMATION]),
        };

        ButtonMargin            = new(buttonMargin, AnimationDuration[NORMAL_ANIMATION]);
        ButtonForeground        = new(buttonForeground, AnimationDuration[NORMAL_ANIMATION]);

        ButtonImageViewport     = isEnter ? 
            new(new(0,0,1,1), AnimationDuration[NORMAL_ANIMATION])
        :
            new(new(-0.3,0,1.5,1.8), AnimationDuration[NORMAL_ANIMATION]);
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
            new(),  // storyboard_ButtonOpacity
            new(),  // storyboard_ButtonWidth
            new(),  // storyboard_ButtonHeight
            new(),  // storyboard_ButtonText
            new(),  // storyboard_ButtonImageOpacity
            new(),  // storyboard_ButtonMargin
            new(),  // storyboard_ButtonForeground
            new(),  // storyboard_ButtonImageViewport
        };

        foreach (var (storyboard, index) in ControlsStoryboards.Select((value, index) => (value, index)))
        {
            DependencyObject TargetElement = UserButton;

            if (index is 4 || index is 7)
                TargetElement = (Border)GetTemplateResource<Border>(BORDER_RESOURCE, TargetElement);

            SetStoryboardAuto(storyboard, TargetElement, ControlPaths[index]);

            switch (index)
            {
                default: storyboard.Add(ControlDA[index]);      break;
                case  5: storyboard.Add(ButtonMargin);          break;
                case  6: storyboard.Add(ButtonForeground);      break;
                case  7: storyboard.Add(ButtonImageViewport);   break;
            }

            storyboard.Begin();
        }
    }
}