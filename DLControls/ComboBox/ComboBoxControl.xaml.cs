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
		public RoutedEventHandler OnItemChange;
		public bool isTextFocused { get; set; }
		public static Style comboBoxStyle;
		private TextBox TextBoxTemplate = new()
		{
			Background = Brushes.Transparent,
			Focusable = true,
			Margin = new(3, 3, 23, 3),
			HorizontalScrollBarVisibility = ScrollBarVisibility.Disabled,
			VerticalScrollBarVisibility = ScrollBarVisibility.Disabled,
		};
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
				UserComboBox.Foreground = Brushes.Red;
				
				/// This fixes the Font color being darker than the others
				/// when the control is disabled
				if(TextEditable)
				{
					comboBoxGRID.Children.Remove(Placeholder);
					comboBoxGRID.Children.Remove(MainText);
					Content.Visibility = Visibility.Visible;
					Content.Content = PlaceholderUnavailable;
					Content.HorizontalAlignment = HorizontalAlignment.Center;
				}

				if(IsEnabled)
				{
					UserComboBox.Foreground = Brushes.White;

					if(TextEditable)
					{
						comboBoxGRID.Children.Add(Placeholder);
						comboBoxGRID.Children.Add(MainText);
						Content.Visibility = Visibility.Hidden;
						Content.HorizontalAlignment = HorizontalAlignment.Left;
						Content.Content = string.Empty;
					}
				}
			};

		}

		private void SetupTextBox()
		{
			// Placeholder
			Placeholder = TextBoxTemplate;
			Placeholder.Foreground = Brushes.DimGray;
			Placeholder.BorderBrush = Brushes.Transparent;
			Placeholder.Focusable = true;
			Placeholder.Margin = new(3, 3, 23, 3);
			Placeholder.Text = PlaceholderText;
			Placeholder.IsHitTestVisible = false;
			
			// MainText
			MainText = TextBoxTemplate;
			MainText.Foreground = Brushes.White;
			MainText.BorderThickness = new(0);
			MainText.SelectionBrush = (Brush)new BrushConverter().ConvertFromString("#FFFF9C9C");
			MainText.CaretBrush = (Brush)new BrushConverter().ConvertFromString("#FFFF9C9C");
			MainText.Width = root.Width;
			MainText.ContextMenu = (ContextMenu)root.FindResource("TextBoxMenu");
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

		public string GetItemContent(List<ComboBoxItem> Items)
		{
			int index = UserComboBox.SelectedIndex;
			if (!TextEditable && index == -1) index = ItemIndex;
			return Items[index].Content as String;
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
}