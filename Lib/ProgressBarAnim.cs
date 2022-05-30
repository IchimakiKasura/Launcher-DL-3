namespace Launcher_DL.Lib;

sealed class ProgressBarAnim
{
	/// <summary>
	/// Show ProgressBar
	/// </summary>
	public static void ProgressBarShow()
	{
		Global.Opac = new(1, TimeSpan.FromMilliseconds(200));
		Storyboard sty = new();
		Storyboard.SetTargetProperty(Global.Opac, new("(ProgressBar.Opacity)"));
		Storyboard.SetTarget(Global.Opac, Global.Window_ProgressBar);
		sty.Children.Add(Global.Opac);
		sty.Begin();
	}

	/// <summary>
	/// Hides ProgressBar
	/// </summary>
	public static void ProgressBarHide()
	{
		Global.Opac = new(0, TimeSpan.FromMilliseconds(200));
		Storyboard sty = new();
		Storyboard.SetTargetProperty(Global.Opac, new("(ProgressBar.Opacity)"));
		Storyboard.SetTarget(Global.Opac, Global.Window_ProgressBar);
		sty.Children.Add(Global.Opac);
		sty.Begin();
	}
}