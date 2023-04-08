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
        IEnumerable<MemberInfo> _PropertyInfo =
        typeof(WindowType) == typeof(MainWindow)  ?
        typeof(WindowType).GetRuntimeProperties() :
        typeof(WindowType).GetRuntimeFields()     ;

        foreach(MemberInfo ToolTipField in _PropertyInfo)
        {
            var FieldAttribute = ToolTipField.GetCustomAttribute<ToolTipTextsAttribute>();
            if(FieldAttribute is not null)
                FieldAttribute.SetValue<WindowType>(FieldAttribute.Description, ToolTipField);
        }
    }

    // Sets the value on selected Attribute
    private void SetValue<WindowType>(string PropertyDescription, MemberInfo memberInfo)
    {
        WindowType SelectedWindow = WindowStaticRefAttribute.InitiateAttribute<WindowType, Global>();

        object propertyValue = memberInfo is PropertyInfo       ?
        (memberInfo as PropertyInfo).GetValue(SelectedWindow)   :
        (memberInfo as FieldInfo).GetValue(SelectedWindow)      ;

        if(propertyValue is IDLControls)
            (propertyValue as IDLControls).UICanvas.MouseMove += (s,e) =>
                Follow(s,e, PropertyDescription);

        if(propertyValue is UIElement)
            (propertyValue as UIElement).MouseMove += (s,e) =>
                Follow(s,e, PropertyDescription);
    }

    public static void Follow(object sender, MouseEventArgs eventargs,in string Content)
    {
        FrameworkElement TooltipElement = (FrameworkElement) sender;
        
        if (TooltipElement.ToolTip is null)
            TooltipElement.ToolTip = new ToolTip() { Placement = System.Windows.Controls.Primitives.PlacementMode.Relative };
            
        ToolTip tip = (ToolTip) TooltipElement.ToolTip;
        tip.Content = Content;
        tip.CacheMode = new BitmapCache();
        tip.HorizontalOffset = eventargs.GetPosition(TooltipElement).X + 10;
        tip.VerticalOffset = eventargs.GetPosition(TooltipElement).Y + 10;
    }
}