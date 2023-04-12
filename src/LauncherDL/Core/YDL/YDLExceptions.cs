namespace LauncherDL.Core.YTDLP;

public class YTDLException : Exception
{
    public YTDLException(string message) : base(message) { }
}

internal class UpdateMethodException : YTDLException
{
    public UpdateMethodException()
        : base("Upload boolean is not set!") { }
}

internal class FileFormatMethodException : YTDLException
{
    public FileFormatMethodException()
        : base("FileFormat boolean is not set!") { }
}

internal class DownloadMethodException : YTDLException
{
    public DownloadMethodException()
        : base("FileFormat or Update boolean is set to true!") { }
}

internal class ConvertMethodException : YTDLException
{
    public ConvertMethodException()
        : base("FileFormat or Update boolean is set to true!") { }
}