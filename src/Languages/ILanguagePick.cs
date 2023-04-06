namespace DLLanguages.Pick.Interface
{
    public interface ILanguagePick
    {
        public string? Button_Convert { get; }
        public string? Button_Download { get; }
        public string? Button_Format { get; }
        public string? Button_OpenFile { get; }
        public string? Button_OpenFolder { get; }
        public string? Button_Update { get; }
        public string? Button_Metadata { get; }
        public string? Formats_3gp { get; }
        public string? Formats_flv { get; }
        public string? Formats_m4a { get; }
        public string? Formats_mkv { get; }
        public string? Formats_mp3 { get; }
        public string? Formats_mp4 { get; }
        public string? Formats_webm { get; }
        public string? Label_File { get; }
        public string? Label_Format { get; }
        public string? Label_Link { get; }
        public string? Label_Name { get; }
        public string? Label_Type { get; }
        public string? OpenFolder_Audio { get; }
        public string? OpenFolder_Convert { get; }
        public string? OpenFolder_Formatted { get; }
        public string? OpenFolder_Logs { get; }
        public string? OpenFolder_Video { get; }
        public string? Placeholder_File { get; }
        public string? Placeholder_Link { get; }
        public string? Placeholder_Optional { get; }
        public string? Placeholder_Required { get; }
        public string? Types_Audio { get; }
        public string? Types_Convert { get; }
        public string? Types_Custom { get; }
        public string? Types_Video { get; }
    }
}