using System.Reflection;

namespace LauncherDL.Core.Attributes;

[AttributeUsage(AttributeTargets.Property|AttributeTargets.Field, Inherited = false)]
public class ToolTipTextsAttribute : Attribute
{
    public string Description { get; private set; }
    public ToolTipTextsAttribute(string _Description) =>
        Description = _Description;

    // Initialize the Attribute
    public static void InitiateAttribute<WindowType>()
    {
        IEnumerable<dynamic> _PropertyInfo;

        // Checks whether if the Type is from MainWindow
        // Please refactor this future me! if possible
        if(typeof(WindowType) == typeof(MainWindow))
            _PropertyInfo = typeof(WindowType).GetRuntimeProperties();
        else _PropertyInfo = typeof(WindowType).GetRuntimeFields();

        foreach(var ToolTipField in _PropertyInfo)
        {
            var FieldAttribute = ((MemberInfo)ToolTipField).GetCustomAttribute<ToolTipTextsAttribute>();
            if(FieldAttribute is not null)
                FieldAttribute.SetValue<WindowType>(ToolTipField.Name, FieldAttribute.Description, ToolTipField);
        }
    }

    // Sets the value on selected Attribute
    private void SetValue<WindowType>(string Name, string PropertyDescription, dynamic PropertyField)
    {
        dynamic PropertyItem = PropertyField.GetValue(WindowStaticRefAttribute.InitiateAttribute<WindowType>());
        
        if(PropertyItem.GetType().Namespace is "DLControls")
            ((UIElement)PropertyItem.UICanvas).MouseMove += (s,e) =>Follow(s,e, PropertyDescription);
        else ((UIElement)PropertyItem).MouseMove += (s,e) => Follow(s, e, PropertyDescription);
    }

    public static void Follow(object sender, MouseEventArgs eventargs, string Content)
    {
        FrameworkElement TooltipElement = (FrameworkElement)sender;
        
        if (TooltipElement.ToolTip is null)
            TooltipElement.ToolTip = new ToolTip() { Placement = System.Windows.Controls.Primitives.PlacementMode.Relative };
            
        ToolTip tip = TooltipElement.ToolTip as ToolTip;
        tip.Content = Content;
        tip.HorizontalOffset = eventargs.GetPosition(TooltipElement).X + 10;
        tip.VerticalOffset = eventargs.GetPosition(TooltipElement).Y + 10;
    }
}