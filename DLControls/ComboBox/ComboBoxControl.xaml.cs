﻿using System.Windows.Controls.Primitives;
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
				if(value) ScrollViewer.SetVerticalScrollBarVisibility(UserComboBox, ScrollBarVisibility.Visible);
			}
		}
		public string GetItemContent
		{
			get
			{
				int index = UserComboBox.SelectedIndex;
				if (!TextEditable && index == -1) index = ItemIndex;
				return ComboBoxTypes[index].Content as String;
			}
		}
		public RoutedEventHandler OnItemChange;
		public bool isTextFocused { get; set; }
		public TextBox MainText;
		TextBox Placeholder;
		public List<ComboBoxItem> ComboBoxTypes = new List<ComboBoxItem>() { new(),new(),new(),new() };

		public ComboBoxControl()
		{
			InitializeComponent();
			SetupTextBox();
		}

		public void ItemsAdd()
		{
			foreach (var (value, index) in ComboBoxTypes.Select((value, i) => (value, i)))
			{
				ComboBoxTypes[index].Style = (Style)UserComboBox.FindResource("DownloadType");
				UserComboBox.Items.Add(ComboBoxTypes[index]);
			}

		}

		private void ContentLoad(object s, RoutedEventArgs e)
		{
			SetBorderStoryboard();

			ContentPresenter Content = GetTemplateResource<ContentPresenter>("ContentSite", UserComboBox);
			Grid comboBoxGRID = GetTemplateResource<Grid>("ComboBoxGRID", UserComboBox);

			if (TextEditable)
			{
				AddChildGRID(comboBoxGRID, true);
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
				switch(IsEnabled)
				{
					case true:
						UserComboBox.Foreground = Brushes.White;
						if(TextEditable)
						{
							AddChildGRID(comboBoxGRID, true);
							Content.Visibility = Visibility.Hidden;
							Content.HorizontalAlignment = HorizontalAlignment.Left;
							Content.Content = string.Empty;
							if(MainText.Text != null)
								comboBoxGRID.Children.Remove(Placeholder);
						}
					break;

					case false:
						UserComboBox.Foreground = Brushes.Red;
						if(TextEditable)
						{
							AddChildGRID(comboBoxGRID, false);
							Content.Visibility = Visibility.Visible;
							Content.Content = PlaceholderUnavailable;
							Content.HorizontalAlignment = HorizontalAlignment.Center;
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
			switch(Add)
			{
				case true: 
					grid.Children.Add(Placeholder);
					grid.Children.Add(MainText);
				break;

				case false:
					grid.Children.Remove(Placeholder);
					grid.Children.Remove(MainText);
				break;
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
}