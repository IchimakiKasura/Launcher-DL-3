namespace Launcher_DL_v6;

using kasuNhentaiCS.Json;
internal class System_Language_Handler : MainWindow
{

    public static string Button_Convert = "Convert";
    public static string Placeholder_Link = "Valid Link";
    public static string Placeholder_Optional = "optional";
    public static string Placeholder_File = "File Location";
    public static string Placeholder_Required = "Required";
    public static string Label_Link = "Link:";
    public static string Label_File = "File:";


    public static async Task LoadLanguage()
    {

        if (!File.Exists("LauncherDL_Data/LanguagePack"))
        {
            MessageBox.Show("LanguagePack is missing!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            MW.Close();
        };

        string json = await File.ReadAllTextAsync("LauncherDL_Data/LanguagePack");
        for (int i = 0; i < 5; i++) json = Encoding.UTF8.GetString(Convert.FromBase64String(json));

        JsonDeserializer Text = new (json);

        switch (MW.Config.SystemLanguage.ToLower())
        {
            case "english":     English(); break;

            case "japanese":    AppLanguage(Text, 0); break;

            case "tagalog":     AppLanguage(Text, 1); break;

            case "bruh":        AppLanguage(Text, 2); break;
        }
    }

    public static void English()
    {
        MW.Button_Download.Content = "Download";
        MW.Button_Format.Content = "File Format";
        MW.Button_Update.Content = "Update";
    }

    public static void AppLanguage(JsonDeserializer Text, int Langauge)
    {
        // Labels
        MW.Text_DownloadType.Content = Text.selector($"Counter:{Langauge}>Label>Type");
        MW.Text_Format.Content = Text.selector($"Counter:{Langauge}>Label>Format");
        MW.Text_Link.Content = Label_Link = Text.selector($"Counter:{Langauge}>Label>Link");
        MW.Text_Name.Content = Text.selector($"Counter:{Langauge}>Label>Name");
        Label_File = Text.selector($"Counter:{Langauge}>Label>File");

        // Placeholder
        MW.Input_Link.Uid = Placeholder_Link = Text.selector($"Counter:{Langauge}>Placeholder>Link");
        MW.Input_Link.Uid = Placeholder_File = Text.selector($"Counter:{Langauge}>Placeholder>File");
        MW.Input_Name.Uid = Placeholder_Optional = Text.selector($"Counter:{Langauge}>Placeholder>Optional");
        MW.Input_Name.Uid = Placeholder_Required = Text.selector($"Counter:{Langauge}>Placeholder>Required");

        // Buttons
        MW.Button_Format.Content = Text.selector($"Counter:{Langauge}>Button>Format");
        MW.Button_Download.Content = Text.selector($"Counter:{Langauge}>Button>Download");
        MW.Button_Update.Content = Text.selector($"Counter:{Langauge}>Button>Update");
        MW.Open_Folder.Content = Text.selector($"Counter:{Langauge}>Button>OpenFolder");
        MW.Open_File.Content = Text.selector($"Counter:{Langauge}>Button>OpenFile");
        Button_Convert = Text.selector($"Counter:{Langauge}>Button>Convert");

        // Types
        MW.ComboBox_Label_Custom.Content = Text.selector($"Counter:{Langauge}>Types>Custom");
        MW.ComboBox_Label_Video.Content = Text.selector($"Counter:{Langauge}>Types>Video");
        MW.ComboBox_Label_Audio.Content = Text.selector($"Counter:{Langauge}>Types>Audio");
        MW.ComboBox_Label_Convert.Content = Text.selector($"Counter:{Langauge}>Types>Convert");

        // Open Folder Context Menu
        MW.OpenDir_Video.Header = Text.selector($"Counter:{Langauge}>OpenFolder>Video");
        MW.OpenDir_Audio.Header = Text.selector($"Counter:{Langauge}>OpenFolder>Audio");
        MW.OpenDir_Convert.Header = Text.selector($"Counter:{Langauge}>OpenFolder>Convert");
        MW.OpenDir_Formatted.Header = Text.selector($"Counter:{Langauge}>OpenFolder>Formatted");

        // Formatted Context Menu
        if (Langauge != 1)
        {
            MW.OpenDir_mFourA.Header = Text.selector($"Counter:{Langauge}>OpenFolder>Formats>m4a");
            MW.OpenDir_mpThree.Header = Text.selector($"Counter:{Langauge}>OpenFolder>Formats>mp3");
            MW.OpenDir_mpFour.Header = Text.selector($"Counter:{Langauge}>OpenFolder>Formats>mp4");
            MW.OpenDir_webm.Header = Text.selector($"Counter:{Langauge}>OpenFolder>Formats>webm");
            MW.OpenDir_mkv.Header = Text.selector($"Counter:{Langauge}>OpenFolder>Formats>mkv");
            MW.OpenDir_threeGP.Header = Text.selector($"Counter:{Langauge}>OpenFolder>Formats>3gp");
            MW.OpenDir_flv.Header = Text.selector($"Counter:{Langauge}>OpenFolder>Formats>flv");
        }

    }

}

