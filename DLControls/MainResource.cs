namespace DLControls;

public partial class MainResource
{
    public static T GetTemplateResource<T>(string Name, dynamic TemplatedParent)
    {
        return (T)TemplatedParent.Template.FindName(Name, TemplatedParent);
    }
}