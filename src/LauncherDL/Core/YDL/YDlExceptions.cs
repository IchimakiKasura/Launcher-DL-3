namespace LauncherDL.Core.YTDLP;

internal class UpdateMethodException : Exception
{
    public UpdateMethodException()
        : base("Upload boolean is not set!") { }
}

public class FileFormatMethodException : Exception
{
    public FileFormatMethodException()
        : base("FileFormat boolean is not set!") { }
}

public class DownloadMethodException : Exception
{
    public DownloadMethodException()
        : base("FileFormat or Update boolean is set to true!") { }
}

public class ConvertMethodException : Exception
{
    public ConvertMethodException()
        : base("FileFormat or Update boolean is set to true!") { }
}