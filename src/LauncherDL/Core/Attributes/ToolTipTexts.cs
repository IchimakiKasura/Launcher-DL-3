namespace LauncherDL.Core.Attributes;

[AttributeUsage(AttributeTargets.Property, Inherited = false)]
public class ToolTipTextsAttribute : Attribute
{
    public string Description { get; private set; }
    public ToolTipTextsAttribute(string _Description) =>
        Description = _Description;

    public void SetToolTipText<T>(string __Description, string Name, BindingFlags Flags)
    {
        var _Field = typeof(T).GetField($"_{Name}", Flags);

        if (_Field is null)
        {
            MainWindow.comboBoxQuality.MouseMove += (s, e) => Follow(s, e, __Description);
            return;
        }

        UIElement _Item = (UIElement)_Field.GetValue(MainWindowStatic);

        _Item.MouseMove += (s, e) => Follow(s, e, __Description);
    }

    public static void Follow(object s, MouseEventArgs e, string Content)
    {
        FrameworkElement TooltipElement = (FrameworkElement)s;
        if (TooltipElement.ToolTip is null)
            TooltipElement.ToolTip = new ToolTip() { Placement = System.Windows.Controls.Primitives.PlacementMode.Relative };
        var tip = (TooltipElement.ToolTip as ToolTip);
        tip.Content = Content;
        tip.HorizontalOffset = e.GetPosition(TooltipElement).X + 10;
        tip.VerticalOffset = e.GetPosition(TooltipElement).Y + 10;
    }

}