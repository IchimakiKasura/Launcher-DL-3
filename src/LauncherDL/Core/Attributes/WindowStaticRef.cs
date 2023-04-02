namespace LauncherDL.Core.Attributes;

[AttributeUsage(AttributeTargets.Field, Inherited = false)]
public class WindowStaticRefAttribute : Attribute
{
    public WindowStaticRefAttribute() { }
    
    public static dynamic InitiateAttribute<TargetType, GlobalType>()
    {
        foreach(FieldInfo GlobalFields in typeof(GlobalType).GetFields())
        {
            var FieldAttribute = GlobalFields.GetCustomAttribute<WindowStaticRefAttribute>();
            
            if(FieldAttribute is not null)
                if(typeof(TargetType) == GlobalFields.FieldType)
                    return GlobalFields.GetValue(null);
        }
        return null;
    }
}