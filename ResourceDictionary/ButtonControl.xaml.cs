namespace Launcher_DL.ResourceDictionary
{

	/// <summary>
	/// Interaction logic for ButtonControl.xaml
	/// </summary>
	public partial class ButtonControl : UserControl
	{
		public static readonly DependencyProperty DLImageProperty =
			DependencyProperty.Register("DL_Image", typeof(string), typeof(ButtonControl));
		public static readonly DependencyProperty DLEffectColorProperty =
			DependencyProperty.Register("DL_EffectColor", typeof(Color), typeof(ButtonControl));
		public static readonly DependencyProperty TextProperty =
			DependencyProperty.Register("Text", typeof(string), typeof(ButtonControl));

		public RoutedEventHandler Click;

		public string DL_Image
		{
			get { return (string)GetValue(DLImageProperty); }
			set { SetValue(DLImageProperty, value); }
		}
		public Color DL_EffectColor
		{
			get { return (Color)GetValue(DLEffectColorProperty); }
			set { SetValue(DLEffectColorProperty, value); }
		}
		public string Text
		{
			get { return (string)GetValue(TextProperty); }
			set { SetValue(TextProperty, value); }
		}

		public ButtonControl()
		{
			InitializeComponent();
		}

		protected virtual void OnClicked(RoutedEventArgs e)
		{
			RoutedEventHandler eh = Click;
			if (eh != null)
			{
				eh(this, e);
			}
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			OnClicked(e);
		}
	}
}
