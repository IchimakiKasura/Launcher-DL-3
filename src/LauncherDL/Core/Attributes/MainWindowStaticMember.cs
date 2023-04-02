// I put comment all over in this file because im bored

// Namespace of this file
namespace LauncherDL.Core.Attributes;

// Attribute idk
[AttributeUsage(AttributeTargets.Property, Inherited = false)]
// Class
public class MainWindowStaticMemberAttribute : Attribute
{
    // Constructor of the class
    public MainWindowStaticMemberAttribute() { }

    // Initialize the Attribute
    public static void InitiateAttribute<TargetType>()
    {
        // Iterate to all the properties of the given type of generic
        foreach(PropertyInfo MainWindowField in typeof(TargetType).GetProperties())
        {
            // Gets the custom attribute of the iterated property
            var FieldAttribute = MainWindowField.GetCustomAttribute<MainWindowStaticMemberAttribute>();

            // Checks if the given attribute is null
            if(FieldAttribute is not null)
                // Proceed to Set the value if there's an attribute found
                FieldAttribute.SetValue<TargetType>(MainWindowField);
        }
    }

    // Sets the value on selected Attribute
    private void SetValue<TargetType>(PropertyInfo propertyInfo)
    {
        // Gets the Field from MainWindow that are non static
        var fieldInfo = typeof(TargetType).GetField($"_{propertyInfo.Name}", BindingFlags.NonPublic|BindingFlags.Instance);

        // Gets the Static object of the of the Type
        var fieldItem = fieldInfo.GetValue(WindowStaticRefAttribute.InitiateAttribute<TargetType, Global>());

        // Returns if its null
        if (fieldItem is null) return;
        
        // Sets the Static properties from non static field
        typeof(TargetType).GetProperty(propertyInfo.Name).SetValue(null, fieldItem);
    }
} 