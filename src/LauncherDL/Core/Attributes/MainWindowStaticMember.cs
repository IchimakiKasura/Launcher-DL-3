namespace LauncherDL.Core.Attributes;

[AttributeUsage(AttributeTargets.Property, Inherited = false)]
public class MainWindowStaticMemberAttribute : Attribute
{
    public MainWindowStaticMemberAttribute() { }
    public void SetValue(string Name, BindingFlags Flags, MemberInfo obj)
    {
        var _Field = typeof(MainWindow).GetField($"_{Name}", Flags);
        var _Item = _Field.GetValue(MainWindowStatic);

        if (_Item is null) return;
        
        typeof(MainWindow).GetProperty(obj.Name).SetValue(obj, _Item);
    }
}