namespace LauncherDL.Core;

[AttributeUsage(AttributeTargets.Property)]
public class MainWindowStaticMemberAttribute : Attribute
{
    public MainWindowStaticMemberAttribute() {}

    public MainWindowStaticProperty GetProperty<T>(string Name, BindingFlags Flags)
    {
        var _Field = typeof(T).GetField(Name, Flags);
        var _Item = _Field.GetValue(MainWindowStatic);
        var _HasValue = false;

        if(_Item is not null)
            _HasValue = true;
        
        return new()
        {
            HasValue = _HasValue,
            Value = _Item
        };
    }

    public void SetValue<T>(MemberInfo obj, object value) =>
        typeof(T).GetProperty(obj.Name).SetValue(obj, value);
}

public class MainWindowStaticProperty
{
    public object Value     { get; set; }
    public bool HasValue    { get; set; }
}