namespace Launcher_DL_v6;

public partial class MainWindow
{
    private void WindowFocusAnimation()
    {
        Activated += delegate
        {
            Opac = new(1, TimeSpan.FromMilliseconds(200));
            Anim = new((Color)ColorConverter.ConvertFromString("#FF713131"), TimeSpan.FromMilliseconds(200));
            Storyboard sty = new();
            Storyboard sty2 = new();
            Storyboard.SetTargetProperty(Opac, new("(Window.Effect).Opacity"));
            Storyboard.SetTargetProperty(Anim, new("(Control.Background).(SolidColorBrush.Color)"));
            Storyboard.SetTarget(Opac, this);
            Storyboard.SetTarget(Anim, WindowBG);
            sty.Children.Add(Opac);
            sty2.Children.Add(Anim);
            sty.Begin();
            sty2.Begin();
        };

        Deactivated += delegate
        {
            Opac = new(0, TimeSpan.FromMilliseconds(200));
            Anim = new(Colors.Black, TimeSpan.FromMilliseconds(200));
            Storyboard sty = new();
            Storyboard sty2 = new();
            Storyboard.SetTargetProperty(Opac, new("(Window.Effect).Opacity"));
            Storyboard.SetTargetProperty(Anim, new("(Control.Background).(SolidColorBrush.Color)"));
            Storyboard.SetTarget(Opac, this);
            Storyboard.SetTarget(Anim, WindowBG);
            sty.Children.Add(Opac);
            sty2.Children.Add(Anim);
            sty.Begin();
            sty2.Begin();
        };
    }
}