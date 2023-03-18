namespace DLLanguages.Pick
{
	public enum LanguageName
	{
		Default,
		English,
		Japanese,
		Tagalog,
		bruh
	};

	public class LanguagePick
	{
		public string? Button_Convert { get; set; }
		public string? Button_Download { get; set; }
		public string? Button_Format { get; set; }
		public string? Button_OpenFile { get; set; }
		public string? Button_OpenFolder { get; set; }
		public string? Button_Update { get; set; }
		public string? Button_Metadata { get; set; }
		public string? Formats_3gp { get; set; }
		public string? Formats_flv { get; set; }
		public string? Formats_m4a { get; set; }
		public string? Formats_mkv { get; set; }
		public string? Formats_mp3 { get; set; }
		public string? Formats_mp4 { get; set; }
		public string? Formats_webm { get; set; }
		public string? Label_File { get; set; }
		public string? Label_Format { get; set; }
		public string? Label_Link { get; set; }
		public string? Label_Name { get; set; }
		public string? Label_Type { get; set; }
		public string? OpenFolder_Audio { get; set; }
		public string? OpenFolder_Convert { get; set; }
		public string? OpenFolder_Formatted { get; set; }
		public string? OpenFolder_Logs { get; set; }
		public string? OpenFolder_Video { get; set; }
		public string? Placeholder_File { get; set; }
		public string? Placeholder_Link { get; set; }
		public string? Placeholder_Optional { get; set; }
		public string? Placeholder_Required { get; set; }
		public string? Types_Audio { get; set; }
		public string? Types_Convert { get; set; }
		public string? Types_Custom { get; set; }
		public string? Types_Video { get; set; }


		public LanguagePick(LanguageName language)
		{
			switch (language)
			{
				case LanguageName.Default:	_Default();		break;
				case LanguageName.English:	_English();		break;
				case LanguageName.Japanese:	_Japanese();	break;
				case LanguageName.Tagalog:	_Tagalog();		break;
				case LanguageName.bruh:		_Bruh();		break;
			}
		}

		private void _Default()
		{
			Button_Convert = Default.Button_Convert;
			Button_Download = Default.Button_Download;
			Button_Format = Default.Button_Format;
			Button_OpenFile = Default.Button_OpenFile;
			Button_OpenFolder = Default.Button_OpenFolder;
			Button_Update = Default.Button_Update;
			Button_Metadata = Default.Button_Metadata;
			Formats_3gp = Default.Formats_3gp;
			Formats_flv = Default.Formats_flv;
			Formats_m4a = Default.Formats_m4a;
			Formats_mkv = Default.Formats_mkv;
			Formats_mp3 = Default.Formats_mp3;
			Formats_mp4 = Default.Formats_mp4;
			Formats_webm = Default.Formats_webm;
			Label_File = Default.Label_File;
			Label_Format = Default.Label_Format;
			Label_Link = Default.Label_Link;
			Label_Name = Default.Label_Name;
			Label_Type = Default.Label_Type;
			OpenFolder_Audio = Default.OpenFolder_Audio;
			OpenFolder_Convert = Default.OpenFolder_Convert;
			OpenFolder_Formatted = Default.OpenFolder_Formatted;
			OpenFolder_Logs = Default.OpenFolder_Logs;
			OpenFolder_Video = Default.OpenFolder_Video;
			Placeholder_File = Default.Placeholder_File;
			Placeholder_Link = Default.Placeholder_Link;
			Placeholder_Optional = Default.Placeholder_Optional;
			Placeholder_Required = Default.Placeholder_Required;
			Types_Audio = Default.Types_Audio;
			Types_Convert = Default.Types_Convert;
			Types_Custom = Default.Types_Custom;
			Types_Video = Default.Types_Video;
		}

		private void _Japanese()
		{
			Button_Convert = Japanese.Button_Convert;
			Button_Download = Japanese.Button_Download;
			Button_Format = Japanese.Button_Format;
			Button_OpenFile = Japanese.Button_OpenFile;
			Button_OpenFolder = Japanese.Button_OpenFolder;
			Button_Update = Japanese.Button_Update;
			Button_Metadata = Japanese.Button_Metadata;
			Formats_3gp = Japanese.Formats_3gp;
			Formats_flv = Japanese.Formats_flv;
			Formats_m4a = Japanese.Formats_m4a;
			Formats_mkv = Japanese.Formats_mkv;
			Formats_mp3 = Japanese.Formats_mp3;
			Formats_mp4 = Japanese.Formats_mp4;
			Formats_webm = Japanese.Formats_webm;
			Label_File = Japanese.Label_File;
			Label_Format = Japanese.Label_Format;
			Label_Link = Japanese.Label_Link;
			Label_Name = Japanese.Label_Name;
			Label_Type = Japanese.Label_Type;
			OpenFolder_Audio = Japanese.OpenFolder_Audio;
			OpenFolder_Convert = Japanese.OpenFolder_Convert;
			OpenFolder_Formatted = Japanese.OpenFolder_Formatted;
			OpenFolder_Logs = Japanese.OpenFolder_Logs;
			OpenFolder_Video = Japanese.OpenFolder_Video;
			Placeholder_File = Japanese.Placeholder_File;
			Placeholder_Link = Japanese.Placeholder_Link;
			Placeholder_Optional = Japanese.Placeholder_Optional;
			Placeholder_Required = Japanese.Placeholder_Required;
			Types_Audio = Japanese.Types_Audio;
			Types_Convert = Japanese.Types_Convert;
			Types_Custom = Japanese.Types_Custom;
			Types_Video = Japanese.Types_Video;
		}

		private void _English()
		{
			Button_Convert = English.Button_Convert;
			Button_Download = English.Button_Download;
			Button_Format = English.Button_Format;
			Button_OpenFile = English.Button_OpenFile;
			Button_OpenFolder = English.Button_OpenFolder;
			Button_Update = English.Button_Update;
			Button_Metadata = English.Button_Metadata;
			Formats_3gp = English.Formats_3gp;
			Formats_flv = English.Formats_flv;
			Formats_m4a = English.Formats_m4a;
			Formats_mkv = English.Formats_mkv;
			Formats_mp3 = English.Formats_mp3;
			Formats_mp4 = English.Formats_mp4;
			Formats_webm = English.Formats_webm;
			Label_File = English.Label_File;
			Label_Format = English.Label_Format;
			Label_Link = English.Label_Link;
			Label_Name = English.Label_Name;
			Label_Type = English.Label_Type;
			OpenFolder_Audio = English.OpenFolder_Audio;
			OpenFolder_Convert = English.OpenFolder_Convert;
			OpenFolder_Formatted = English.OpenFolder_Formatted;
			OpenFolder_Logs = English.OpenFolder_Logs;
			OpenFolder_Video = English.OpenFolder_Video;
			Placeholder_File = English.Placeholder_File;
			Placeholder_Link = English.Placeholder_Link;
			Placeholder_Optional = English.Placeholder_Optional;
			Placeholder_Required = English.Placeholder_Required;
			Types_Audio = English.Types_Audio;
			Types_Convert = English.Types_Convert;
			Types_Custom = English.Types_Custom;
			Types_Video = English.Types_Video;
		}

		private void _Tagalog()
		{
			Button_Convert = Tagalog.Button_Convert;
			Button_Download = Tagalog.Button_Download;
			Button_Format = Tagalog.Button_Format;
			Button_OpenFile = Tagalog.Button_OpenFile;
			Button_OpenFolder = Tagalog.Button_OpenFolder;
			Button_Update = Tagalog.Button_Update;
			Button_Metadata = Tagalog.Button_Metadata;
			Formats_3gp = Tagalog.Formats_3gp;
			Formats_flv = Tagalog.Formats_flv;
			Formats_m4a = Tagalog.Formats_m4a;
			Formats_mkv = Tagalog.Formats_mkv;
			Formats_mp3 = Tagalog.Formats_mp3;
			Formats_mp4 = Tagalog.Formats_mp4;
			Formats_webm = Tagalog.Formats_webm;
			Label_File = Tagalog.Label_File;
			Label_Format = Tagalog.Label_Format;
			Label_Link = Tagalog.Label_Link;
			Label_Name = Tagalog.Label_Name;
			Label_Type = Tagalog.Label_Type;
			OpenFolder_Audio = Tagalog.OpenFolder_Audio;
			OpenFolder_Convert = Tagalog.OpenFolder_Convert;
			OpenFolder_Formatted = Tagalog.OpenFolder_Formatted;
			OpenFolder_Logs = Tagalog.OpenFolder_Logs;
			OpenFolder_Video = Tagalog.OpenFolder_Video;
			Placeholder_File = Tagalog.Placeholder_File;
			Placeholder_Link = Tagalog.Placeholder_Link;
			Placeholder_Optional = Tagalog.Placeholder_Optional;
			Placeholder_Required = Tagalog.Placeholder_Required;
			Types_Audio = Tagalog.Types_Audio;
			Types_Convert = Tagalog.Types_Convert;
			Types_Custom = Tagalog.Types_Custom;
			Types_Video = Tagalog.Types_Video;
		}

		private void _Bruh()
		{
			Button_Convert = bruh.Button_Convert;
			Button_Download = bruh.Button_Download;
			Button_Format = bruh.Button_Format;
			Button_OpenFile = bruh.Button_OpenFile;
			Button_OpenFolder = bruh.Button_OpenFolder;
			Button_Update = bruh.Button_Update;
			Button_Metadata = bruh.Button_Metadata;
			Formats_3gp = bruh.Formats_3gp;
			Formats_flv = bruh.Formats_flv;
			Formats_m4a = bruh.Formats_m4a;
			Formats_mkv = bruh.Formats_mkv;
			Formats_mp3 = bruh.Formats_mp3;
			Formats_mp4 = bruh.Formats_mp4;
			Formats_webm = bruh.Formats_webm;
			Label_File = bruh.Label_File;
			Label_Format = bruh.Label_Format;
			Label_Link = bruh.Label_Link;
			Label_Name = bruh.Label_Name;
			Label_Type = bruh.Label_Type;
			OpenFolder_Audio = bruh.OpenFolder_Audio;
			OpenFolder_Convert = bruh.OpenFolder_Convert;
			OpenFolder_Formatted = bruh.OpenFolder_Formatted;
			OpenFolder_Logs = bruh.OpenFolder_Logs;
			OpenFolder_Video = bruh.OpenFolder_Video;
			Placeholder_File = bruh.Placeholder_File;
			Placeholder_Link = bruh.Placeholder_Link;
			Placeholder_Optional = bruh.Placeholder_Optional;
			Placeholder_Required = bruh.Placeholder_Required;
			Types_Audio = bruh.Types_Audio;
			Types_Convert = bruh.Types_Convert;
			Types_Custom = bruh.Types_Custom;
			Types_Video = bruh.Types_Video;
		}

	}
}
