namespace DLLanguages.Pick.Interface
{
    public interface ILanguagePick
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
    }
}