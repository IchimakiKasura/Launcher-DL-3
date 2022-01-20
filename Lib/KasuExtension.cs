namespace Launcher_DL_v6;

class LauncherDefaultConfig
{
    public string BackgroundName { get; set; } = "background.png";
    public string BackgroundColor { get; set; } = "#A31F0000";
    public string GlowColor { get; set; } = "#FFFF8282";
    public string DefaultOutput { get; set; } = "output";
    public int DefaultFileTypeOnStartUp { get; set; } = 0;
    public bool AlwayDownloadInMP3 { get; set; } = true;
    public bool ShowSystemOutput { get; set; } = true;
    public bool EnablePlaylist { get; set; } = false;
}

public partial class MainWindow
{
    LauncherDefaultConfig Config = new();
    private async void LoadConfig()
    {
        string Data = await File.ReadAllTextAsync("Config.kasu");

        
            foreach(Match match in LauncherDL_Regex.KasuExtension.Matches(Data))
		    {
                if (match.Groups["BackgroundName"].Success) Config.BackgroundName = match.Groups["BackgroundName"].Value.Trim();
                if (match.Groups["GlowColor"].Success) Config.GlowColor = match.Groups["GlowColor"].Value.Trim();
                if (match.Groups["DefaultOutput"].Success) Config.DefaultOutput = match.Groups["DefaultOutput"].Value.Trim();
                if (match.Groups["DefaultFileTypeOnStartUp"].Success) Config.DefaultFileTypeOnStartUp = int.Parse(match.Groups["DefaultFileTypeOnStartUp"].Value.Trim());
                if (match.Groups["AlwayDownloadInMP3"].Success) Config.AlwayDownloadInMP3 = bool.Parse(match.Groups["AlwayDownloadInMP3"].Value.Trim());
                if (match.Groups["ShowSystemOutput"].Success) Config.ShowSystemOutput = bool.Parse(match.Groups["ShowSystemOutput"].Value.Trim());
                if (match.Groups["EnablePlaylist"].Success) Config.EnablePlaylist = bool.Parse(match.Groups["EnablePlaylist"].Value.Trim());
            }

            Window_BackgroundName.ImageSource = new BitmapImage(new Uri($"Images/{Config.BackgroundName}", UriKind.Relative));
            Window_DropShadow.Color = (Color)ColorConverter.ConvertFromString(Config.GlowColor);


    }
}