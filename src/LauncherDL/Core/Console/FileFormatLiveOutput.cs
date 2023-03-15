namespace LauncherDL.Core.ConsoleDL;

internal partial class ConsoleLive
{
    string id,res,size,bit,fps,fmt,codec,ao;

    public static void FileFormatLiveOutputComment(object s, DataReceivedEventArgs e)
    {
        string StringData = e.Data;
        if (string.IsNullOrEmpty(StringData)) return;

        DL_Dispatch.Invoke(()=>FileFormat_Invoked(StringData));
    }

    static void FileFormat_Invoked(string StringData)
    {
        
    }
}