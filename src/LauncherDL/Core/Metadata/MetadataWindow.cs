using System.Net.Mime;
namespace LauncherDL.Core.Metadata;

public partial class MetadataWindow
{
    private void GenerateElements()
    {
        // Window Rounded corner and Image Background
        MetadataRoundBorder = new()
        {
            Child = new Border()
            {
                CornerRadius = new(10),
                Child = MetadataWindowCanvas = new(),
                Background = new ImageBrush()
                {
                    ImageSource = new BitmapImage(new Uri(WINDOW_BACKGROUND, UriKind.Absolute)),
                    Stretch = Stretch.Fill,
                    Opacity = 0.5
                }
            },
            CornerRadius = new(10),
            Background = Brushes.Black,
            Margin = new(10,10,10,10)
        };

        // Instantiate the button because holy fuck
        // i don't know how to initiate it under the Grid Children 
        Button_Exit = new();

        // Icon Bar
        var iconBar = new Image()
        {
            IsHitTestVisible = false,
            Source = new BitmapImage(new(WINDOW_ICON, UriKind.Absolute)),
            Margin = new Thickness(8,0,this.Width - 49,0)
        };

        // Title Bar
        var titleBar = new TextBlock()
        {
            IsHitTestVisible = false,
            Text = Title,
            Foreground = Brushes.White,
            FontWeight = FontWeights.Medium,
            FontSize = 14,
            Padding = new Thickness(34,6.5,0,0)
        };
        
        // Top Bar
        MetadataDragBorder = new()
        {
            CornerRadius = new(10,10,0,0),
            Height = 35,
            Width = this.Width - 20,
            Background = BrhConv(TOPBAR_COLOR),
            Child = new Grid()
            {
                Children =
                {
                    iconBar,
                    titleBar,
                    Button_Exit
                }
            }
        };

        // Add Top bar to Canvas
        AddToCanvas(MetadataDragBorder);

        // Add Canvas to Window
        AddChild(MetadataRoundBorder);
    }
}