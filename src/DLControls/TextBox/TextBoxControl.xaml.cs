namespace DLControls;

public partial class TextBoxControl : UserControl, IDLControls
{
    readonly static DependencyProperty TextPlaceholderProperty =
        DependencyProperty.Register("TextPlaceholder", typeof(string), typeof(TextBoxControl), new("Placeholder"));
    readonly static DependencyProperty TextPlaceholderAlignmentProperty =
        DependencyProperty.Register("TextPlaceholderAlignment", typeof(HorizontalAlignment), typeof(TextBoxControl), new(HorizontalAlignment.Left));
    readonly static DependencyProperty TextProperty =
        DependencyProperty.Register("Text", typeof(string), typeof(TextBoxControl), null);
    readonly static DependencyProperty isTextBoxFocusedProperty =
        DependencyProperty.Register("isTextBoxFocusedProperty", typeof(bool), typeof(TextBoxControl));

    [Browsable(false)]
    public Thickness TextPlaceholderMargin
    {
        get => TextPlaceholderAlignment is HorizontalAlignment.Left ? new(10, 2, 0, 0) : new(0, 2, 0, 0);
    }

    public double TextPlaceholderFontSize = 20;

    public string TextPlaceholder
    {
        get => (string)GetValue(TextPlaceholderProperty);
        set => SetValue(TextPlaceholderProperty, value);
        
    }
    public HorizontalAlignment TextPlaceholderAlignment
    {
        get => (HorizontalAlignment)GetValue(TextPlaceholderAlignmentProperty);
        set => SetValue(TextPlaceholderAlignmentProperty, value);
        
    }
    public string Text
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }
    public bool isTextBoxFocused
    {
        get => (bool)GetValue(isTextBoxFocusedProperty);
        set => SetValue(isTextBoxFocusedProperty, value);
    }

    public UIElement UICanvas =>
        UserTextBox;

    public TextBoxControl() =>
        InitializeComponent();
    
    private void ContentLoaded(object sender, RoutedEventArgs e)
    {
        Grid UserGrid = GetTemplateResource<Grid>("UserTextBoxGRID", UserTextBox);
    
        var Placeholder = new TextBlock()
        {
            Foreground          = Brushes.DimGray,
            FontSize            = TextPlaceholderFontSize,
            HorizontalAlignment = TextPlaceholderAlignment,
            IsHitTestVisible    = false,
            Margin              = TextPlaceholderMargin,
            Text                = TextPlaceholder,
            VerticalAlignment   = VerticalAlignment.Center
        };

        // Prevents collusion with with the instatiated text
        if(Text.IsEmpty())
            UserGrid.Add(Placeholder);

        UserTextBox.TextChanged += delegate
        {
            if (Text.IsEmpty())
                UserGrid.Add(Placeholder);
            else UserGrid.Remove(Placeholder);
        };

        UserTextBox.IsEnabledChanged += delegate
        {
            UserTextBox.Foreground =
            Placeholder.Foreground = Brushes.Red;
            Placeholder.Text = "Unavailable";
            if (UserTextBox.IsEnabled)
            {
                UserTextBox.Foreground = Brushes.White;
                Placeholder.Foreground = Brushes.DimGray;
                Placeholder.Text = TextPlaceholder;
            }
        };

        UserTextBox.GotFocus +=(s,e)=> { isTextBoxFocused = true; };
        UserTextBox.LostFocus +=(s,e)=> { isTextBoxFocused = false; };
    }
}