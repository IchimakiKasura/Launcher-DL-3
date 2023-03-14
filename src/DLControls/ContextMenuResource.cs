namespace DLControls;

public partial class ContextMenuResource
{
    public static TextBoxControl Link;
    public static ComboBoxControl Format;
    public static TextBoxControl Name;

    void ClearText(object s, RoutedEventArgs e)
    {
        if (Link.isTextBoxFocused) Link.Text = null;
        if (Format.isTextFocused) Format.MainText.Text = null;
        if (Name.isTextBoxFocused) Name.Text = null;
    }
}