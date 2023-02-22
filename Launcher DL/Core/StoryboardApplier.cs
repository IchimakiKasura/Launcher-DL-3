namespace Launcher_DL.Core;

public class StoryboardApplier
{
	Storyboard _Storyboard;
	public StoryboardApplier(DependencyObject Element, DependencyObject Value, PropertyPath Path)
	{
		_Storyboard = new();

		Storyboard.SetTargetProperty(Element, Path);
		Storyboard.SetTarget(Element, Value);
		_Storyboard.Children.Add((Timeline)Element);
		_Storyboard.Begin();
	}
}

