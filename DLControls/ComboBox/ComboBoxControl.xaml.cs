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

		public ComboBox UserControlMain { get; set; }

		public bool isTextFocused { get; set; }
		public bool TextEditable
		{
			get => (bool)GetValue(TextEditableProperty);
			set => SetValue(TextEditableProperty, value);
		}

		TextBox Placeholder;
		public TextBox MainText;

		public ComboBoxControl()
		{
			InitializeComponent();

			UserControlMain = UserComboBox;
		}

		private void ContentLoad(object s, RoutedEventArgs e)
		{
			SetupTextBox();
			SetBorderStoryboard();
			ContentPresenter Content = (ContentPresenter)UserComboBox.Template.FindName("ContentSite", UserComboBox);
			Grid comboBoxGRID = (Grid)UserComboBox.Template.FindName("ComboBoxGRID", UserComboBox);

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
			Border border = (Border)((ToggleButton)UserComboBox.Template.FindName("ToggleButton", UserComboBox)).Template.FindName("ToggleButtonBorder", (ToggleButton)UserComboBox.Template.FindName("ToggleButton", UserComboBox));

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