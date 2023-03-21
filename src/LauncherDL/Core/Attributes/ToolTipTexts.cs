namespace LauncherDL.Core.Attributes;

[AttributeUsage(AttributeTargets.Property, Inherited = false)]
public class ToolTipTextsAttribute : Attribute
{
    public string Description { get; private set; }
    public ToolTipTextsAttribute(string _Description) =>
        Description = _Description;

    // Initialize the Attribute
    public static void InitiateAttribute<T>()
    {
        foreach(var ToolTipField in typeof(T).GetRuntimeProperties())
        {
            var FieldAttribute = ToolTipField.GetCustomAttribute<ToolTipTextsAttribute>();
            if(FieldAttribute is not null)
                FieldAttribute.SetValue<T>(ToolTipField.Name, FieldAttribute.Description);
        }
    }

    // Sets the value on selected Attribute
    private void SetValue<T>(string Name, string PropertyDescription)
    {
        var PropertyField = typeof(T).GetField($"_{Name}", BindingFlags.Instance|BindingFlags.Public|BindingFlags.CreateInstance|BindingFlags.NonPublic);

        dynamic PropertyItem = PropertyField.GetValue(WindowStaticRefAttribute.InitiateAttribute<T>());

        // Checks whether the Element came from guicomp.dll or not
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