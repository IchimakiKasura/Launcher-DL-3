namespace DLControls;

public partial class MainResource
{
    public static T GetTemplateResource<T>(in string Name,dynamic TemplatedParent) =>
        (T)TemplatedParent.Template.FindName(Name, TemplatedParent);
    
    public static void SetStoryboardAuto(Timeline element, DependencyObject value, PropertyPath path)
    {
        Storyboard.SetTargetProperty(element, path);
        Storyboard.SetTarget(element, value);
    }

    public static void SetMouseEnterLeave(UIElement Control, Action Enter, Action Leave)
    {
        Control.MouseEnter += (s,e) => Enter();
        Control.MouseLeave += (s,e) => Leave();
    }

    public static void SetValueAnimated(UIElement Element, DependencyProperty dp, dynamic value, TimeSpan time)
    {
        DoubleAnimation anim = new(value, time);
        Element.BeginAnimation(dp, anim);
    }
}

internal static class _Extensions
{
    // Strings
    public static bool IsEmpty(this string str) =>
        string.IsNullOrEmpty(str);

    // Storyboard
    public static void Add(this Storyboard storyboard, Timeline Element) =>
        storyboard.Children.Add(Element);

    // Grid
    public static void Add(this Grid grid, UIElement Element) =>
        grid.Children.Add(Element);
    public static void Remove(this Grid grid, UIElement Element) =>
        grid.Children.Remove(Element);
    public static bool Contains(this Grid grid, UIElement Element) =>
        grid.Children.Contains(Element);
}