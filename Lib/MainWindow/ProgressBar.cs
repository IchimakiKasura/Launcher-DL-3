namespace Launcher_DL_v6;

public partial class MainWindow
{
    private void ProgressBarShow()
    {
        Opac = new(1, TimeSpan.FromMilliseconds(200));
        Storyboard sty = new();
        Storyboard.SetTargetProperty(Opac, new("(ProgressBar.Opacity)"));
        Storyboard.SetTarget(Opac, Window_ProgressBar);
        sty.Children.Add(Opac);
        sty.Begin();
    }

    private void ProgressBarHide()
	{
        Opac = new(0, TimeSpan.FromMilliseconds(200));
        Storyboard sty = new();
        Storyboard.SetTargetProperty(Opac, new("(ProgressBar.Opacity)"));
        Storyboard.SetTarget(Opac, Window_ProgressBar);
        sty.Children.Add(Opac);
        sty.Begin();
    }
}