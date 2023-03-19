namespace DLControls;

public partial class ConsoleControl : UserControl
{
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
    
    public ConsoleControl() =>
        InitializeComponent();
        

    public void manualScrollToEnd() => UserRichTextBox.ScrollToEnd();
}