namespace Launcher_DL_v6;

public class LauncherDefaultConfig
{
    public string   BackgroundName { get; set; }            = "background.png";
    public string   BackgroundColor { get; set; }           = "#A31F0000";
    public string   GlowColor { get; set; }                 = "#FFFF8282";
    public string   DefaultOutput { get; set; }             = "output";
    public string   SystemLanguage { get; set; }            = "default";
    public int      DefaultFileTypeOnStartUp { get; set; }  = 0;
    public bool     ShowSystemOutput { get; set; }          = true;
    public bool     EnablePlaylist { get; set; }            = false;
}

public partial class MainWindow
{
    // should've used JSON but damn,I don't want to add System.Text.Json or Newtonsoft.Json
    private async Task LoadConfig()
    {
        string Data = string.Empty;

        try
        {
            Data = await File.ReadAllTextAsync("Config.kasu");
        }
        catch
        {
            MessageBox.Show("Config.kasu is Missing!\nPlease create a Config.kasu to avoid this message", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        int TotalDetected = 0;

        try
        {
            foreach (Match match in LauncherDL_Regex.KasuExtension.Matches(Data))
            {
                DebugOutput.LoadConfig_Debug(match);
                if (match.Groups["BackgroundName"].Success) Config.BackgroundName = match.Groups["BackgroundName"].Value.Trim();
                if (match.Groups["BackgroundColor"].Success) Config.BackgroundColor = match.Groups["BackgroundColor"].Value.Trim();
                if (match.Groups["GlowColor"].Success) Config.GlowColor = match.Groups["GlowColor"].Value.Trim();
                if (match.Groups["DefaultOutput"].Success) Config.DefaultOutput = match.Groups["DefaultOutput"].Value.Trim();
                if (match.Groups["DefaultFileTypeOnStartUp"].Success) Config.DefaultFileTypeOnStartUp = int.Parse(match.Groups["DefaultFileTypeOnStartUp"].Value.Trim());
                if (match.Groups["ShowSystemOutput"].Success) Config.ShowSystemOutput = bool.Parse(match.Groups["ShowSystemOutput"].Value.Trim());
                if (match.Groups["EnablePlaylist"].Success) Config.EnablePlaylist = bool.Parse(match.Groups["EnablePlaylist"].Value.Trim());
                if (match.Groups["Language"].Success) Config.SystemLanguage = match.Groups["Language"].Value.Trim();

                if (match.Success) ++TotalDetected;
            }

            if (!File.Exists($"Images/{Config.BackgroundName}")) throw new Exception();
            if (Config.DefaultFileTypeOnStartUp >= 3) throw new Exception();
            if (TotalDetected != 8) throw new Exception();

            DebugOutput.Selected_Language(Config.SystemLanguage.ToLower());

            // Check if BackgroundColor input is valid.
            Color BackgroundColor = ClrConv(Config.BackgroundColor);

            Window_BackgroundName.ImageSource = new BitmapImage(new Uri($"Images/{Config.BackgroundName}", UriKind.Relative));
            Window_DropShadow.Color = ClrConv(Config.GlowColor);

            DebugOutput.LoadConfig_Done(false);
            if (Config.ShowSystemOutput) Output_text.AddFormattedText($"<#a85192%14>[SYSTEM] <DarkGreen%14>SUCCESS <gray%14>\"Config.kasu\" loaded!");
        }
        catch
        {
            DebugOutput.LoadConfig_Done(true);
            Config.BackgroundColor = new LauncherDefaultConfig().BackgroundColor;
            if (Config.ShowSystemOutput) Output_text.AddFormattedText($"<#a85192%14>[SYSTEM] <DarkRed%14>FAILED <gray%14>to load \"Config.kasu\"");
        }

        Input_Type.SelectedIndex = Config.DefaultFileTypeOnStartUp;
    }
}