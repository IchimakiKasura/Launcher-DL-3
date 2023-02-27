using System.Windows.Controls.Primitives;
using System.Windows.Media.Animation;

namespace DLControls
{
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
		readonly static DependencyProperty ItemIndexProperty =
			DependencyProperty.Register("ItemIndex", typeof(int), typeof(ComboBoxControl));
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
			get => (int)GetValue(ItemIndexProperty);
			set
			{
				SetValue(ItemIndexProperty, value);
				UserComboBox.SelectedIndex = value;
			}
		}
		public bool ShowVerticalScrollbar
		{
			get => (bool)GetValue(ShowVerticalScrollbarProperty);
			set
			{
				SetValue(ShowVerticalScrollbarProperty, value);
				
				ScrollViewer.SetVerticalScrollBarVisibility(UserComboBox, ScrollBarVisibility.Disabled);

				if(value)
					ScrollViewer.SetVerticalScrollBarVisibility(UserComboBox, ScrollBarVisibility.Visible);
			}
		}
		public bool isTextFocused { get; set; }
		public static Style comboBoxStyle;
		public TextBox MainText;
		TextBox Placeholder;

		public ComboBoxControl()
		{
			InitializeComponent();

			comboBoxStyle = (Style)UserComboBox.FindResource("DownloadType");
		}

		public void ItemsAdd(object Element)
		{
			UserComboBox.Items.Add(Element);
		}

		private void ContentLoad(object s, RoutedEventArgs e)
		{
			SetupTextBox();
			SetBorderStoryboard();

			ContentPresenter Content = GetTemplateResource<ContentPresenter>("ContentSite", UserComboBox);
			Grid comboBoxGRID = GetTemplateResource<Grid>("ComboBoxGRID", UserComboBox);

			if (TextEditable)
			{
				comboBoxGRID.Children.Add(Placeholder);
				comboBoxGRID.Children.Add(MainText);
				Content.Visibility = Visibility.Hidden;
			}

			MainText.TextChanged += delegate
			{
				if (MainText.Text == string.Empty)
					comboBoxGRID.Children.Add(Placeholder);
				else comboBoxGRID.Children.Remove(Placeholder);
			};

			IsEnabledChanged += delegate
			{
				UserComboBox.Foreground = Brushes.White;
				Placeholder.Foreground = Brushes.DimGray;
				Placeholder.Text = PlaceholderText;

				if(!IsEnabled)
				{
					UserComboBox.Foreground =
					Placeholder.Foreground = Brushes.Red;
					Placeholder.Text = PlaceholderUnavailable;
				}
			};

		}

		private void SetupTextBox()
		{

			Placeholder = new()
			{
				Foreground = Brushes.DimGray,
				Background = Brushes.Transparent,
				BorderBrush = Brushes.Transparent,
				Focusable = true,
				Margin = new(3, 3, 23, 3),
				Text = PlaceholderText,
				IsHitTestVisible = false,
				HorizontalScrollBarVisibility = ScrollBarVisibility.Disabled,
				VerticalScrollBarVisibility = ScrollBarVisibility.Disabled,
			};

			MainText = new()
			{
				Foreground = Brushes.White,
				BorderThickness = new(0),
				Margin = new(3, 3, 23, 3),
				Focusable = true,
				Background = Brushes.Transparent,
				SelectionBrush = (Brush)new BrushConverter().ConvertFromString("#FFFF9C9C"),
				CaretBrush = (Brush)new BrushConverter().ConvertFromString("#FFFF9C9C"),
				Width = root.Width,
				ContextMenu = (ContextMenu)root.FindResource("TextBoxMenu"),
				HorizontalScrollBarVisibility = ScrollBarVisibility.Disabled,
				VerticalScrollBarVisibility = ScrollBarVisibility.Disabled,
			};

		}


		private void SetBorderStoryboard()
		{
			ToggleButton TB = GetTemplateResource<ToggleButton>("ToggleButton", UserComboBox);
			Border border = GetTemplateResource<Border>("ToggleButtonBorder", TB);

			MainText.GotFocus += delegate { isTextFocused = true; };
			MainText.LostFocus += delegate { isTextFocused = false; };

			void setStoryboard(bool IsEnter)
			{
				ColorAnimation BorderBrush;
				Storyboard STYB_BorderBrush = new();

				if (IsEnter)
				{
					BorderBrush = new(Colors.Blue, TimeSpan.FromMilliseconds(100));
				}
				else BorderBrush = new((Color)ColorConverter.ConvertFromString("#FF011F4C"), TimeSpan.FromMilliseconds(100));

				Storyboard.SetTargetProperty(BorderBrush, new("(Control.BorderBrush).(SolidColorBrush.Color)"));
				Storyboard.SetTarget(BorderBrush, border);
				STYB_BorderBrush.Children.Add(BorderBrush);
				STYB_BorderBrush.Begin();

			}

			UserComboBox.MouseEnter += delegate { setStoryboard(true); };
			UserComboBox.MouseLeave += delegate { setStoryboard(false); };
		}
	}
}