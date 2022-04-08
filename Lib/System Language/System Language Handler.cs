﻿namespace Launcher_DL_v6;

internal class System_Language_Handler : MainWindow
{
    public static string DefaultInputLinkUID = "Valid Link";
    public static string DefaultLinkContent = "Link:";
    public static string DefaultNameInput = "optional";
    public static string DefaultInputLinkUIDTwo = "File Location";
    public static string DefaultLinkContentTwo = "File:";
    public static string DefaultNameInputTwo = "Required";

    public static void LoadLanguage()
    {
        switch (MW.Config.SystemLanguage.ToLower())
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
        DefaultNameInputTwo = "所要";
        DefaultInputLinkUIDTwo = "ファイルの場所";
        DefaultLinkContentTwo = "ファイル:";
        MW.Button_Download.Content = "ダウンロード";
        MW.Button_Format.Content = "ファイルフォーマット";
        MW.Button_Update.Content = "アップデート";
        MW.Text_DownloadType.Content = "ダウンロードタイプ:";
        MW.Text_Format.Content = "フォーマット";
        MW.Text_Name.Content = "名前";
        MW.ComboBox_Label_Custom.Content = "カスタム";
        MW.ComboBox_Label_Video.Content = "ビデオ";
        MW.ComboBox_Label_Audio.Content = "オーディオ";
        MW.Text_Link.Content = DefaultLinkContent = "リンク:";
        DefaultInputLinkUID = MW.Input_Link.Uid = "有効なリンク";
        MW.Open_File.Content = "ファイルを開く";
        MW.Input_Name.Uid = DefaultNameInput ="オプショナル";
        MW.Open_Folder.Content = "フォルダ開ける";
        MW.OpenDir_Video.Header = "ビデオ開ける";
        MW.OpenDir_Audio.Header = "オーディオ開ける";
        MW.OpenDir_Convert.Header = "変換済みを開く";
        MW.OpenDir_Formatted.Header = "フォーマット済み";
        MW.OpenDir_mFourA.Header = "ｍ４ａ";
        MW.OpenDir_mpThree.Header = "ｍｐ３";
        MW.OpenDir_mpFour.Header = "ｍｐ４";
        MW.OpenDir_webm.Header = "ｗｅｂｍ";
        MW.OpenDir_threeGP.Header = "３ｇｐ";
        MW.OpenDir_flv.Header = "ｆｌｖ";
        MW.OpenDir_mkv.Header = "ｍｋｖ";
        MW.VideoType = new() { "ｍｐ４", "ｍｋｖ", "ｗｅｂｍ", "ｆｌｖ", "３ｇｐ" };
        MW.AudioType = new() { "ｍｐ３", "ｗｅｂｍ", "ｍ４ａ", "ｍｐ４"};
    }

    public static void Tagalog(string LineType = default)
    {
        DefaultNameInputTwo = "Kailangan";
        DefaultInputLinkUIDTwo = "Lokasyon ng File";
        DefaultLinkContentTwo = "Ang File:";
        MW.Button_Download.Content = "I-Download";
        MW.Button_Format.Content = "Pormat ng File";
        MW.Button_Update.Content = "I-Update";
        MW.Text_DownloadType.Content = "Uri ng I-dodownload:";
        MW.Text_Format.Content = "Pormat";
        MW.Text_Name.Content = "Pangalan";
        MW.ComboBox_Label_Custom.Content = "Sariling paraan?";
        MW.ComboBox_Label_Video.Content = "Bidyo";
        MW.ComboBox_Label_Audio.Content = "Musika";
        MW.Text_Link.Content = DefaultLinkContent = "Ang link:";
        DefaultInputLinkUID = MW.Input_Link.Uid = "Totoong Link";
        MW.Open_File.Content = "Buksan ang File";
        MW.Input_Name.Uid = DefaultNameInput ="Opsyonal";
        MW.Open_Folder.Content = "Buksan ang Paniklop";
        MW.OpenDir_Video.Header = "Buksan ang Bidyo Polder";
        MW.OpenDir_Audio.Header = "Buksan ang Musika Polder";
        MW.OpenDir_Convert.Header = "Buksan ang na-convert";
        MW.OpenDir_Formatted.Header = "Pormado";
    }

    public static void bruh(string LineType = default)
    {
        DefaultNameInputTwo = "Name this fucker";
        DefaultInputLinkUIDTwo = "The file location okay?";
        DefaultLinkContentTwo = "Where did you hide the file:";
        MW.Button_Download.Content = "Fucken Download";
        MW.Button_Format.Content = "U gonna format Akira?";
        MW.Button_Update.Content = "Update this archon fuck";
        MW.Text_DownloadType.Content = "What fucken type:";
        MW.Text_Format.Content = "For-fucking-mat";
        MW.Text_Name.Content = "Name the fuck?";
        MW.ComboBox_Label_Custom.Content = "Custom?!?";
        MW.ComboBox_Label_Video.Content = "Vid...";
        MW.ComboBox_Label_Audio.Content = "Illegal audio";
        MW.Text_Link.Content = DefaultLinkContent = "Bruh you illiterate?:";
        DefaultInputLinkUID = MW.Input_Link.Uid = "Real Link you fuck";
        MW.Open_File.Content = "Open File?";
        MW.Input_Name.Uid = DefaultNameInput = "Name it if you fucking want to name it";
        MW.Open_Folder.Content = "Open Fuck";
        MW.OpenDir_Video.Header = "Open the fucking video folder";
        MW.OpenDir_Audio.Header = "Open the fucking audio folder";
        MW.OpenDir_Convert.Header = "Open the fucking converted folder";
        MW.OpenDir_Formatted.Header = "Those other 4 formats because you picked Custom";
        MW.OpenDir_mFourA.Header = "M4A1";
        MW.OpenDir_mpThree.Header = "MP3-S";
        MW.OpenDir_mpFour.Header = "MP4EASADAWDKASLDORJGR";
        MW.OpenDir_webm.Header = "WEBENEMENEMBEMENB";
        MW.OpenDir_threeGP.Header = "gpgpgp";
        MW.OpenDir_flv.Header = "feleve";
        MW.OpenDir_mkv.Header = "mkvvkmkv";
        MW.VideoType = new() { "MP4EASADAWDKASLDORJGR", "mkvvkmkv", "WEBENEMENEMBEMENB", "feleve", "gpgpgp" };
        MW.AudioType = new() { "MP3-S", "WEBENEMENEMBEMENB", "M4A1", "MP4EASADAWDKASLDORJGR"};
    }

}

