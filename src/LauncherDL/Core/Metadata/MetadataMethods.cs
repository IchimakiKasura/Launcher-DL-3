namespace LauncherDL.Core.Metadata;

public partial class MetadataWindow
{
    private void GetOldText(string Old, TextBox Element)
    {
        if(Old is null) return;
        
        Element.Text = Old;

        if(Element.Text == Element.Uid) return;
        
        Element.Foreground = Brushes.White;
        Element.FontStyle = default;
    }

    private void SetOldText(ref string Old, TextBox Element)
    {
        if(Element.Text != Element.Uid)
            Old = Element.Text;
        else Old = null;
    }

    void AddToCanvas(UIElement Element) =>
        MetadataWindowCanvas.Add(Element);

    void InitializeBorderEffect()
    {
        void Focus()
        {
            new StoryboardApplier(WindowOpacity     ,   this                ,   new(             "(Window.Effect).Opacity"        ) );
            new StoryboardApplier(WindowAnimation   ,   MetadataRoundBorder ,   new("(Control.Background).(SolidColorBrush.Color)") );
        }

        Activated += (s,e) =>
        {
            WindowOpacity       = new(1, TimeSpan.FromMilliseconds(100));
            WindowAnimation     = new(config.backgroundColor, TimeSpan.FromMilliseconds(100));
            Focus();
        };

        Deactivated += (s,e) =>
        {
            WindowOpacity       = new(0, TimeSpan.FromMilliseconds(100));
            WindowAnimation     = new(Colors.Black, TimeSpan.FromMilliseconds(100));
            Focus();
        };
    }

}