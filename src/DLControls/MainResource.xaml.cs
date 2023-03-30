namespace DLControls;

public partial class MainResource
{
    public static T GetTemplateResource<T>(string Name, dynamic TemplatedParent) =>
        (T)TemplatedParent.Template.FindName(Name, TemplatedParent);

    public static void SetStoryboardAuto(DependencyObject element, DependencyObject value, PropertyPath path)
    {
        Storyboard.SetTargetProperty(element, path);
        Storyboard.SetTarget(element, value);
    }

    public static void SetMouseEnterLeave(UIElement Control, Action Enter, Action Leave)
    {
        Control.MouseEnter += (s,e) => Enter();
        Control.MouseLeave += (s,e) => Leave();
    }
}

internal static class _Extensions
{
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