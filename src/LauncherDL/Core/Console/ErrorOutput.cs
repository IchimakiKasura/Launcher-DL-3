namespace LauncherDL.Core.ConsoleDL                                                                                             ;
internal partial class ConsoleLive                                                                                              {
    public static int SelectedError = 0                                                                                         ;
    public static void ErrorOutputComment(object s, DataReceivedEventArgs e)                                                    {
        switch(SelectedError)                                                                                                   {
            case 0                                                                                                              :
                console.DLAddConsole(CONSOLE_ERROR_STRING,
                $"<%14>1. Link is unavailable$nl$2. Link is invalid$nl$3. Check internet connection.")                          ;
            break                                                                                                               ;
            case 1                                                                                                              :
                console.DLAddConsole(CONSOLE_ERROR_STRING,
                $"<%14>Download failed! Please check your connection and retry again.")                                         ;
            break                                                                                                               ;}}}