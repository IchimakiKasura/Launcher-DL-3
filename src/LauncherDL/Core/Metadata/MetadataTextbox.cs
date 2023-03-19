namespace LauncherDL.Core.Metadata;

public partial class MetadataWindow
{
    private void TextBoxFocused(object s, RoutedEventArgs e)
    {
        var _textbox = (TextBox)e.OriginalSource;
        
        if(_textbox.Text == _textbox.Uid)
            _textbox.Text = "";

        _textbox.Foreground = Brushes.Black;
        _textbox.FontStyle = default;
    }

    private void TextBoxUnFocused(object s, RoutedEventArgs e)
    {
        var _textbox = (TextBox)e.OriginalSource;
        if(_textbox.Text is "" or null)
        {
            _textbox.Text = _textbox.Uid;
            _textbox.Foreground = Brushes.Gray;
            _textbox.FontStyle = FontStyles.Italic;
        }
    }
}