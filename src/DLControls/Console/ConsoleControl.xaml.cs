namespace DLControls;

public partial class ConsoleControl : UserControl
{
    public ConsoleControl() =>
        InitializeComponent();
        
    public double ConsoleHeight
    {
        get => UserRichTextBox.Height;
        set => UserRichTextBox.Height = value;
        
    }

    public double ConsoleWidth
    {
        get => UserRichTextBox.Width;
        set => UserRichTextBox.Width = value;
    }

    public void manualScrollToEnd() => UserRichTextBox.ScrollToEnd();
}