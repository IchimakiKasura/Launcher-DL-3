namespace DL_Resources;

public partial class ResourcesScript
{
	public static Duration AnimationTime { get; set; }

	public ResourcesScript()
	{
		InitializeComponent();
	}

	public static void InitiateAnimation()
	{
		var Bool = Global.Config.EpicAnimations;
		AnimationTime = TimeSpan.Parse("00:00:00.1");

		if (Bool) return;

		AnimationTime = TimeSpan.Parse("0");
		Global.Button_Format.UserButton.Style = (Style)Application.Current.FindResource("UserButtonDisabledAnimation");
		Global.Button_Download.UserButton.Style = (Style)Application.Current.FindResource("UserButtonDisabledAnimation");
		Global.Button_Update.UserButton.Style = (Style)Application.Current.FindResource("UserButtonDisabledAnimation");
	}
}