namespace DLControls;

public partial class ButtonControl
{
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

    private void SetAnimationsValues(bool isEnter, TimeSpan AnimationDuration, TimeSpan AnimationDurationLeave)
    {
        switch(isEnter)
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
    }
}