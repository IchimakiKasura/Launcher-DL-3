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
        Control.MouseEnter += delegate { Enter(); };
        Control.MouseLeave += delegate { Leave(); };
        GC.Collect();
    }
}