﻿namespace LauncherDL.Core;

public sealed class StoryboardApplier
{
    public StoryboardApplier(DependencyObject Element,
                             DependencyObject Value,
                             PropertyPath Path)
    {
        Storyboard _Storyboard = new();

        Storyboard.SetTargetProperty(Element, Path);
        Storyboard.SetTarget(Element, Value);
        _Storyboard.Children.Add((Timeline)Element);
        _Storyboard.Begin();
    }
}

