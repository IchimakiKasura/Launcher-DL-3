namespace LauncherDL.Core.Metadata;

public partial class MetadataWindow
{
    private void GetOldText(string Old, TextBoxControl Element) =>
        Element.Text = Old;

    private void SetOldText(ref string Old, TextBoxControl Element) =>
        Old = Element.Text is "" ? null : Element.Text;
    

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