namespace LauncherDL.Core.Attributes;

public class AttributeProperty
{
    public object Value { get; set; }
    public bool HasValue { get; set; }
}

[AttributeUsage(AttributeTargets.Property, Inherited = false)]
public class MainWindowStaticMemberAttribute : Attribute
{
    public MainWindowStaticMemberAttribute() { }

    public AttributeProperty GetProperty<T>(string Name, BindingFlags Flags)
    {
        var _Field = typeof(T).GetField($"_{Name}", Flags);
        var _Item = _Field.GetValue(MainWindowStatic);
        var _HasValue = false;

        if (_Item is not null)
            _HasValue = true;

        return new()
        {
            HasValue = _HasValue,
            Value = _Item
        };
    }

    public void SetValue<T>(MemberInfo obj, AttributeProperty Value)
    {
        if (Value.HasValue)
            typeof(T).GetProperty(obj.Name).SetValue(obj, Value.Value);
    }
}