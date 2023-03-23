namespace DLControls;

public partial class ButtonControl
{
    // Normal is default 100ms
    // faster is 50ms
    const int NORMAL_ANIMATION = 0, FASTER_ANIMATION = 1;

    const string
    BUTTON_OPACITY  = "(Effect).Opacity", 
    BUTTON_WIDTH    = "Width",
    BUTTON_HEIGHT   = "Height",
    BUTTON_FONTSIZE = "(Button.FontSize)",
    IMAGE_OPACITY   = "Background.(Brush.Opacity)",
    IMAGE_MARGIN    = "Margin",
    BUTTON_FONTCOLOR= "(Button.Foreground).(SolidColorBrush.Color)",
    IMAGE_VIEWPORT  = "Background.(ImageBrush.Viewport)",
    BORDER_RESOURCE = "UserButtonMainBorder";
}