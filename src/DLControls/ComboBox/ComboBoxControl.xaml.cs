namespace DLControls;

/// <summary>
/// Interaction logic for ComboBox.xaml
/// </summary>
public partial class ComboBoxControl : UserControl
{
    readonly static DependencyProperty TextEditableProperty =
        DependencyProperty.Register("TextEditable", typeof(bool), typeof(ComboBoxControl));
    readonly static DependencyProperty PlaceholderTextProperty =
        DependencyProperty.Register("PlaceholderText", typeof(string), typeof(ComboBoxControl), new("default (Best)"));
    readonly static DependencyProperty ContentAlignmentProperty =
        DependencyProperty.Register("ContentAlignment", typeof(HorizontalAlignment), typeof(ComboBoxControl));
    readonly static DependencyProperty ShowVerticalScrollbarProperty =
        DependencyProperty.Register("ShowVerticalScrollbar", typeof(bool), typeof(ComboBoxControl));

    public bool TextEditable
    {
        get => (bool)GetValue(TextEditableProperty);
        set => SetValue(TextEditableProperty, value);
    }
    public string PlaceholderText
    {
        get => (string)GetValue(PlaceholderTextProperty);
        set => SetValue(PlaceholderTextProperty, value);
    }
    public HorizontalAlignment ContentAlignment
    {
        get => (HorizontalAlignment)(GetValue(ContentAlignmentProperty));
        set => SetValue(ContentAlignmentProperty, UserComboBox.HorizontalContentAlignment = value);
        
    }
    public int ItemIndex
    {
        get => UserComboBox.SelectedIndex;
        set => UserComboBox.SelectedIndex = value;
    }
    public bool ShowVerticalScrollbar
    {
        get => (bool)GetValue(ShowVerticalScrollbarProperty);
        set
        {
            SetValue(ShowVerticalScrollbarProperty, value);
            ScrollViewer.SetVerticalScrollBarVisibility(UserComboBox, ScrollBarVisibility.Disabled);
            if(value) ScrollViewer.SetVerticalScrollBarVisibility(UserComboBox, ScrollBarVisibility.Visible);
        }
    }
    public string GetItemContent =>
        ((ComboBoxItem)UserComboBox.SelectedItem).Content as String;

    public string GetItemUID =>
        ((ComboBoxItem)UserComboBox.SelectedItem).Uid as String;

    public bool isTextFocused;
    public RoutedEventHandler OnItemChange;
    public TextBox MainText;
    TextBlock Placeholder;
    public ContentPresenter Contents;
    public Grid comboBoxGRID;
    
    public ComboBoxControl()
    {
        InitializeComponent();
        SetupTextBox();
    }

    private void ContentLoad(object s, RoutedEventArgs e)
    {
        SetBorderStoryboard();

        Contents = GetTemplateResource<ContentPresenter>("ContentSite", UserComboBox);
        comboBoxGRID = GetTemplateResource<Grid>("ComboBoxGRID", UserComboBox);

        if (TextEditable)
        {
            comboBoxGRID.Children.Add(Placeholder);
            comboBoxGRID.Children.Add(MainText); 
            Contents.Visibility = Visibility.Hidden;
        }

        MainText.TextChanged += delegate
        {
            if (MainText.Text == string.Empty)
                comboBoxGRID.Children.Add(Placeholder);
            else comboBoxGRID.Children.Remove(Placeholder);
        };
        
        IsEnabledChanged += delegate
        {
            switch(IsEnabled)
            {
                case true:
                    Placeholder.Foreground = Brushes.DimGray;
                    MainText.Foreground =
                    UserComboBox.Foreground = Brushes.White;
                    Placeholder.HorizontalAlignment = HorizontalAlignment.Left;

                    if(TextEditable)
                    {
                        if(!comboBoxGRID.Children.Contains(MainText))
                            comboBoxGRID.Children.Add(MainText);

                        Placeholder.Text = PlaceholderText;
                    }
                    break;

                case false:
                    MainText.Foreground =
                    Placeholder.Foreground =
                    UserComboBox.Foreground = Brushes.Red;
                    Placeholder.HorizontalAlignment = HorizontalAlignment.Center;
                    
                    if(TextEditable)
                    {
                        if(string.IsNullOrEmpty(MainText.Text))
                            comboBoxGRID.Children.Remove(MainText);
                            
                        Placeholder.Text = " Unavailable";
                    }
                    break;
            }
        };
    }

    private void SetupTextBox()
    {
        Placeholder = new()
        {
            Foreground = Brushes.DimGray,
            Focusable = false,
            Text = PlaceholderText,
            IsHitTestVisible = false,
        };

        MainText = new()
        {
            Foreground = Brushes.White,
            BorderThickness = new(0),
            Focusable = true,
            SelectionBrush = (Brush)new BrushConverter().ConvertFromString("#FFFF9C9C"),
            CaretBrush = (Brush)new BrushConverter().ConvertFromString("#FFFF9C9C"),
            Width = root.Width,
            ContextMenu = (ContextMenu)root.FindResource("TextBoxMenu"),
        };

        MainText.HorizontalScrollBarVisibility = 
        MainText.VerticalScrollBarVisibility = ScrollBarVisibility.Disabled;

        Placeholder.Background = MainText.Background = Brushes.Transparent;

        Placeholder.Margin = MainText.Margin = new(3, 3, 23, 3);
    }

    private void SetBorderStoryboard()
    {
        ColorAnimation BorderBrush;
        Storyboard STYB_BorderBrush = new();

        ToggleButton TB = GetTemplateResource<ToggleButton>("ToggleButton", UserComboBox);
        Border border = GetTemplateResource<Border>("ToggleButtonBorder", TB);

        MainText.GotFocus += delegate { isTextFocused = true; };
        MainText.LostFocus += delegate { isTextFocused = false; };

        void setStoryboard(bool IsEnter)
        {
            BorderBrush = new((Color)ColorConverter.ConvertFromString("#FF011F4C"), TimeSpan.FromMilliseconds(100));
            
            if (IsEnter)
                BorderBrush = new(Colors.Blue, TimeSpan.FromMilliseconds(100));

            SetStoryboardAuto(BorderBrush, border, new("(Control.BorderBrush).(SolidColorBrush.Color)"));
            
            STYB_BorderBrush.Children.Add(BorderBrush);
            STYB_BorderBrush.Begin();

        }
        SetMouseEnterLeave(UserComboBox, ()=>setStoryboard(true), ()=>setStoryboard(false));
    }

    protected virtual void OnChange(RoutedEventArgs e)
    {
        RoutedEventHandler eh = OnItemChange;
        if (eh != null)
        {
            if (e == null) return; 
            eh(this, e);
        }
    }

    private void OnSelectChange(object s, RoutedEventArgs e)
    {
        OnChange(e);

        if(TextEditable && ((FormatList)UserComboBox.SelectedItem) != null)
            MainText.Text = ((FormatList)UserComboBox.SelectedItem).Name;

        GC.Collect();
    }
}