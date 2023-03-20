namespace LauncherDL.Core.Attributes;

[AttributeUsage(AttributeTargets.Property, Inherited = false)]
public class ToolTipTextsAttribute : Attribute
{
    public string Description { get; private set; }
    public ToolTipTextsAttribute(string _Description) =>
        Description = _Description;

    public void SetToolTipText(string Name, string _Desc, BindingFlags Flags)
    {
        var _Field = typeof(MainWindow).GetField($"_{Name}", Flags);

        if (_Field is null)
        {
            MainWindow.comboBoxQuality.MouseMove += (s,e) => Follow(s,e,_Desc);
            return;
        }

        dynamic _Item = _Field.GetValue(MainWindowStatic);

        // Fixes the ToolTip disappearing when mouse moved on CustomControls
        if(_Item.Content.GetType() == typeof(Canvas))
            ((UIElement)_Item.UICanvas).MouseMove += (s,e) => Follow(s,e, _Desc);
        else ((UIElement)_Item).MouseMove += (s,e) => Follow(s, e, _Desc);
    }

    public static void Follow(object sender, MouseEventArgs eventargs, string Content)
    {
        FrameworkElement TooltipElement = (FrameworkElement)sender;
        
        if (TooltipElement.ToolTip is null)
            TooltipElement.ToolTip = new ToolTip() { Placement = System.Windows.Controls.Primitives.PlacementMode.Relative };
            
        var tip = (TooltipElement.ToolTip as ToolTip);
        tip.Content = Content;
        tip.HorizontalOffset = eventargs.GetPosition(TooltipElement).X + 10;
        tip.VerticalOffset = eventargs.GetPosition(TooltipElement).Y + 10;
    }
}