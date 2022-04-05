namespace Launcher_DL_v6;

internal class System_Language_Handler : MainWindow
{
    public static void LoadLanguage()
    {
        MW.Config.SystemLanguage = MW.Config.SystemLanguage.ToLower();

        switch (MW.Config.SystemLanguage)
        {
			case "english":		English();	break;

			case "japanese":	Japanese(); break;

			case "tagalog":		Tagalog();	break;

			case "bruh":		bruh();		break;
        }
    }

    public static void English(string LineType = default)
    {
        MW.Button_Download.Content = "Download";
        MW.Button_Format.Content = "File Format";
        MW.Button_Update.Content = "Update";
    }

    public static void Japanese(string LineType = default)
    {
        MW.Button_Download.Content = "ダウンロード";
        MW.Button_Format.Content = "ファイルフォーマット";
        MW.Button_Update.Content = "アップデート";
        MW.Text_DownloadType.Content = "ダウンロードタイプ:";
        MW.Text_Format.Content = "フォーマット";
        MW.Text_Name.Content = "名前";
        MW.ComboBox_Label_Custom.Content = "カスタム";
        MW.ComboBox_Label_Video.Content = "ビデオ";
        MW.ComboBox_Label_Audio.Content = "オーディオ";
        MW.Input_MpThreeFormat.Content = "ｍｐ３形式を強制する";
        MW.Text_Link.Content = "リンク:";
        MW.Input_Link.Uid = "有効なリンク";
        MW.Input_Name.Uid = "オプショナル";
        MW.Open_Folder.Content = "フォルダ開ける";
        MW.OpenDir_Video.Header = "ビデオ開ける";
        MW.OpenDir_Audio.Header = "オーディオ開ける";
        MW.OpenDir_Formatted.Header = "フォーマット済み";
        MW.OpenDir_mFourA.Header = "ｍ４ａ";
        MW.OpenDir_mpThree.Header = "ｍｐ３";
        MW.OpenDir_mpFour.Header = "ｍｐ４";
        MW.OpenDir_webm.Header = "ｗｅｂｍ";
        MW.OpenDir_threeGP.Header = "３ｇｐ";
        MW.OpenDir_flv.Header = "ｆｌｖ";
    }

    public static void Tagalog(string LineType = default)
    {
        MW.Button_Download.Content = "I-Download";
        MW.Button_Format.Content = "Pormat ng File";
        MW.Button_Update.Content = "I-Update";
        MW.Text_DownloadType.Content = "Uri ng I-dodownload:";
        MW.Text_Format.Content = "Pormat";
        MW.Text_Name.Content = "Pangalan";
        MW.ComboBox_Label_Custom.Content = "Sariling paraan?";
        MW.ComboBox_Label_Video.Content = "Bidyo";
        MW.ComboBox_Label_Audio.Content = "Musika";
        MW.Input_MpThreeFormat.Content = "Gawing Mp3 pormat.";
        MW.Text_Link.Content = "Ang link:";
        MW.Input_Link.Uid = "Totoong Link";
        MW.Input_Name.Uid = "Opsyonal";
        MW.Open_Folder.Content = "Buksan Paniklop";
        MW.OpenDir_Video.Header = "Buksan ang Bidyo Polder";
        MW.OpenDir_Audio.Header = "Buksan ang Musika Polder";
        MW.OpenDir_Formatted.Header = "Pormado";
        MW.OpenDir_mFourA.Header = "em-4-a";
        MW.OpenDir_mpThree.Header = "em pi 3";
        MW.OpenDir_mpFour.Header = "empi lig- em pi four";
        MW.OpenDir_webm.Header = "webem";
        MW.OpenDir_threeGP.Header = "3-geepee";
        MW.OpenDir_flv.Header = "ep-el-b";
    }

    public static void bruh(string LineType = default)
    {
        MW.Button_Download.Content = "Fucken Download";
        MW.Button_Format.Content = "U gonna format Akira?";
        MW.Button_Update.Content = "Update this archon fuck";
        MW.Text_DownloadType.Content = "What fucken type:";
        MW.Text_Format.Content = "For-fucking-mat";
        MW.Text_Name.Content = "Name the fuck?";
        MW.ComboBox_Label_Custom.Content = "Custom?!?";
        MW.ComboBox_Label_Video.Content = "Vid...";
        MW.ComboBox_Label_Audio.Content = "Illegal audio";
        MW.Input_MpThreeFormat.Content = "MP5 format";
        MW.Text_Link.Content = "Bruh you illiterate?:";
        MW.Input_Link.Uid = "Real Link you fuck";
        MW.Input_Name.Uid = "Name it if you fucking want to name it";
        MW.Open_Folder.Content = "Open Fuck";
        MW.OpenDir_Video.Header = "Open the fucking video folder";
        MW.OpenDir_Audio.Header = "Open the fucking audio folder";
        MW.OpenDir_Formatted.Header = "Those other 4 formats because you picked Custom";
        MW.OpenDir_mFourA.Header = "M4A1";
        MW.OpenDir_mpThree.Header = "MP3-S";
        MW.OpenDir_mpFour.Header = "MP4EASADAWDKASLDORJGR";
        MW.OpenDir_webm.Header = "WEBENEMENEMBEMENB";
        MW.OpenDir_threeGP.Header = "gpgpgp";
        MW.OpenDir_flv.Header = "feleve";
    }

}

