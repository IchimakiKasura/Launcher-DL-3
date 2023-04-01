namespace LauncherDL.Core.Attributes;

[AttributeUsage(AttributeTargets.Field, Inherited = false)]
public class WindowStaticRefAttribute : Attribute
{
    public WindowStaticRefAttribute() { }
    
    public static dynamic InitiateAttribute<T1, T2>()
        where T2 : new()
    {
        foreach(FieldInfo GlobalFields in typeof(T2).GetFields())
        {
            var FieldAttribute = GlobalFields.GetCustomAttribute<WindowStaticRefAttribute>();
            
            if(FieldAttribute is not null)
                if(typeof(T1) == GlobalFields.FieldType)
                    return GlobalFields.GetValue(new T2());
        }
        return null;
    }
}