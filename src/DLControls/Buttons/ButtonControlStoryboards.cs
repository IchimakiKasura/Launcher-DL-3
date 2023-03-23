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