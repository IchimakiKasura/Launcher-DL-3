namespace Launcher_DL.Lib.Language;

sealed class System_Language_Handler : Global
{
    public static string Button_Convert = "Convert";
    public static string Placeholder_Link = "Valid Link";
    public static string Placeholder_Optional = "optional";
    public static string Placeholder_File = "File Location";
    public static string Placeholder_Required = "Required";
    public static string Label_Link = "Link:";
    public static string Label_File = "File:";
    public static string Button_Download_Default = "ダウンロード";

    public static async Task LoadLanguage(CancellationToken ct)
    {
        if (!File.Exists(KasuLangName))
        {
            MessageBox.Show("LanguagePack is missing!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            MainWindowStatic.Close();
        };

        string json = await File.ReadAllTextAsync(KasuLangName, ct);

        for (int i = 0; i < 5; i++) json = Encoding.UTF8.GetString(Convert.FromBase64String(json));

        kasuNhentaiCS.Json.JsonDeserializer Text = new(json);

        switch (Config.SystemLanguage.ToLower())
        {
            case "english":     English(); break;

            case "japanese":    AppLanguage(Text, 0); break;

            case "tagalog":     AppLanguage(Text, 1); break;

            case "bruh":        AppLanguage(Text, 2); break;
        }
    }

    public static void English()
    {
        Button_Download.Content = "Download";
        Button_Format.Content = "File Format";
        Button_Update.Content = "Update";
    }

    public static void AppLanguage(kasuNhentaiCS.Json.JsonDeserializer Text, int Langauge)
    {
        // Labels
        Text_DownloadType.Content = Text.selector($"Counter:{Langauge}>Label>Type");
        Text_Format.Content = Text.selector($"Counter:{Langauge}>Label>Format");
        Text_Link.Content = Label_Link = Text.selector($"Counter:{Langauge}>Label>Link");
        Text_Name.Content = Text.selector($"Counter:{Langauge}>Label>Name");
        Label_File = Text.selector($"Counter:{Langauge}>Label>File");

        // Placeholder
        Input_Link.Uid = Placeholder_Link = Text.selector($"Counter:{Langauge}>Placeholder>Link");
        Input_Link.Uid = Placeholder_File = Text.selector($"Counter:{Langauge}>Placeholder>File");
        Input_Name.Uid = Placeholder_Optional = Text.selector($"Counter:{Langauge}>Placeholder>Optional");
        Input_Name.Uid = Placeholder_Required = Text.selector($"Counter:{Langauge}>Placeholder>Required");

        // Buttons
        Button_Format.Content = Text.selector($"Counter:{Langauge}>Button>Format");
        Button_Download.Content = Button_Download_Default = Text.selector($"Counter:{Langauge}>Button>Download");
        Button_Update.Content = Text.selector($"Counter:{Langauge}>Button>Update");
        Open_Folder.Content = Text.selector($"Counter:{Langauge}>Button>OpenFolder");
        Open_File.Content = Text.selector($"Counter:{Langauge}>Button>OpenFile");
        Button_Convert = Text.selector($"Counter:{Langauge}>Button>Convert");

        // Types
        ComboBox_Label_Custom.Content = Text.selector($"Counter:{Langauge}>Types>Custom");
        ComboBox_Label_Video.Content = Text.selector($"Counter:{Langauge}>Types>Video");
        ComboBox_Label_Audio.Content = Text.selector($"Counter:{Langauge}>Types>Audio");
        ComboBox_Label_Convert.Content = Text.selector($"Counter:{Langauge}>Types>Convert");

        // Open Folder Context Menu
        OpenDir_Video.Header = Text.selector($"Counter:{Langauge}>OpenFolder>Video");
        OpenDir_Audio.Header = Text.selector($"Counter:{Langauge}>OpenFolder>Audio");
        OpenDir_Convert.Header = Text.selector($"Counter:{Langauge}>OpenFolder>Convert");
        OpenDir_Formatted.Header = Text.selector($"Counter:{Langauge}>OpenFolder>Formatted");
        OpenDir_Logs.Header = Text.selector($"Counter:{Langauge}>OpenFolder>Logs");

        // Formatted Context Menu
        if (Langauge != 1)
        {
            OpenDir_mFourA.Header = Text.selector($"Counter:{Langauge}>OpenFolder>Formats>m4a");
            OpenDir_mpThree.Header = Text.selector($"Counter:{Langauge}>OpenFolder>Formats>mp3");
            OpenDir_mpFour.Header = Text.selector($"Counter:{Langauge}>OpenFolder>Formats>mp4");
            OpenDir_webm.Header = Text.selector($"Counter:{Langauge}>OpenFolder>Formats>webm");
            OpenDir_mkv.Header = Text.selector($"Counter:{Langauge}>OpenFolder>Formats>mkv");
            OpenDir_threeGP.Header = Text.selector($"Counter:{Langauge}>OpenFolder>Formats>3gp");
            OpenDir_flv.Header = Text.selector($"Counter:{Langauge}>OpenFolder>Formats>flv");
        }

    }

}