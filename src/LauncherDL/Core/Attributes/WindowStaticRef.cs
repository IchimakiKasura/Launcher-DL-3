namespace LauncherDL.Core.Attributes;

[AttributeUsage(AttributeTargets.Field, Inherited = false)]
public class WindowStaticRefAttribute : Attribute
{
    public WindowStaticRefAttribute() { }
    public static dynamic InitiateAttribute<T>()
    {
        foreach(FieldInfo GlobalFields in typeof(Global).GetFields())
        {
            var FieldAttribute = GlobalFields.GetCustomAttribute<WindowStaticRefAttribute>();
            
            if(FieldAttribute is not null)
                if(typeof(T) == GlobalFields.FieldType)
                    return GlobalFields.GetValue(new Global());
        }
        
        return null;
    }
}