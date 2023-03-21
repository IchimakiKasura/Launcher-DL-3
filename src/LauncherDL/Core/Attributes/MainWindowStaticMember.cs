namespace LauncherDL.Core.Attributes;

[AttributeUsage(AttributeTargets.Property, Inherited = false)]
public class MainWindowStaticMemberAttribute : Attribute
{
    public MainWindowStaticMemberAttribute() { }

    // Initialize the Attribute
    public static void InitiateAttribute<T>()
    {
        foreach(PropertyInfo MainWindowField in typeof(T).GetProperties())
        {
            var FieldAttribute = MainWindowField.GetCustomAttribute<MainWindowStaticMemberAttribute>();

            if(FieldAttribute is not null)
                FieldAttribute.SetValue<T>(MainWindowField);
        }
    }

    // Sets the value on selected Attribute
    private void SetValue<T>(PropertyInfo PropertyInfo)
    {
        var PropertyField = typeof(T).GetField($"_{PropertyInfo.Name}", BindingFlags.NonPublic|BindingFlags.Instance);

        var PropertyItem = PropertyField.GetValue(WindowStaticRefAttribute.InitiateAttribute<T>());

        if (PropertyItem is null) return;
        
        typeof(T).GetProperty(PropertyInfo.Name).SetValue(PropertyInfo, PropertyItem);
    }
} 