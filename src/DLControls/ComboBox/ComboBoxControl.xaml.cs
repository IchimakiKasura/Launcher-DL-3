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
    readonly static DependencyProperty PlaceholderUnavailableProperty =
        DependencyProperty.Register("PlaceholderUnavailable", typeof(string), typeof(ComboBoxControl), new("Unavailable"));
    readonly static DependencyProperty PlaceholderAlignmentProperty =
        DependencyProperty.Register("PlaceholderAlignment", typeof(HorizontalAlignment), typeof(ComboBoxControl));
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
    public string PlaceholderUnavailable
    {
        get => (string)(GetValue(PlaceholderUnavailableProperty));
        set => SetValue(PlaceholderUnavailableProperty, value);
    }
    public HorizontalAlignment PlaceholderAlignment
    {
        get => (HorizontalAlignment)(GetValue(PlaceholderAlignmentProperty));
        set
        {
            SetValue(PlaceholderAlignmentProperty, value);
            Placeholder.HorizontalContentAlignment = value;
        }
    }
    public HorizontalAlignment ContentAlignment
    {
        get => (HorizontalAlignment)(GetValue(ContentAlignmentProperty));
        set
        {
            SetValue(ContentAlignmentProperty, value);
            UserComboBox.HorizontalContentAlignment = value;
        }
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
    public string GetItemContent
    {
        get => ((ComboBoxItem)UserComboBox.SelectedItem).Content as String;
    }

    public bool isTextFocused { get; set; }
    public RoutedEventHandler OnItemChange;
    public TextBox MainText;
    TextBox Placeholder;
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
        Contents.Uid = "NotEditable";

        if (TextEditable)
        {
            AddChildGRID(comboBoxGRID, true);	 
            Contents.Visibility = Visibility.Hidden;
            Contents.Uid = "Editable";
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
                    UserComboBox.Foreground = Brushes.White;
                    if(TextEditable)
                    {
                        AddChildGRID(comboBoxGRID, true);
                        Contents.Visibility = Visibility.Hidden;
                        Contents.HorizontalAlignment = HorizontalAlignment.Left;
                        if(!string.IsNullOrEmpty(MainText.Text))
                            comboBoxGRID.Children.Remove(Placeholder);
                    }
                    break;

                case false:
                    UserComboBox.Foreground = Brushes.Red;
                    Contents.Uid = "NotEditable";
                    if(TextEditable)
                    {
                        AddChildGRID(comboBoxGRID, false);
                        Contents.Visibility = Visibility.Visible;
                        Contents.HorizontalAlignment = HorizontalAlignment.Center;
                        Contents.Uid = "Editable";
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
            BorderBrush = Brushes.Transparent,
            Focusable = true,
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

        Placeholder.HorizontalScrollBarVisibility = 
        Placeholder.VerticalScrollBarVisibility =
        MainText.HorizontalScrollBarVisibility = 
        MainText.VerticalScrollBarVisibility = ScrollBarVisibility.Disabled;

        Placeholder.Background = MainText.Background = Brushes.Transparent;

        Placeholder.Margin = MainText.Margin = new(3, 3, 23, 3);
    }

    public void AddChildGRID(Grid grid, bool Add)
    {
        grid.Children.Remove(Placeholder);
        grid.Children.Remove(MainText);

        if(Add)
        {
            grid.Children.Add(Placeholder);
            grid.Children.Add(MainText);

            if(!string.IsNullOrEmpty(MainText.Text))
                comboBoxGRID.Children.Remove(Placeholder);
        }
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
        GC.Collect();
    }
}