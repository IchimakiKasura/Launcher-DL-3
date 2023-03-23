namespace LauncherDL                                                                                                                                .
          Core                                                                                                                                      .
          ConsoleDL                                                                                                                                 ;

internal partial class ConsoleLive                                                                                                                  {/*
    
    0 = File format                                                                                                                         
    1 = Download                                                                                                                            
    2 = Convert                                                                                                                                    */
    public static int SelectedError = 0                                                                                                             ;
    
    public static void ErrorOutputComment(object s, DataReceivedEventArgs e)                                                                        =>
        DL_Dispatch.Invoke(()=>Error_Invoked(),e.Data)                                                                                              ;

    static void Error_Invoked()                                                                                                                     {
        switch(SelectedError)                                                                                                                       {
            case 0                                                                                                                                  :
                console.DLAddConsole(CONSOLE_ERROR_STRING,
                "URL cannot be fetched!$nl$1. Link is unavailable$nl$2. Link is invalid$nl$3. Check internet connection.$nl$"                       +
                "4.YT-DLP might be outdated please update it first! ")                                                                              ;
            break                                                                                                                                   ;
            
            case 1                                                                                                                                  :
                console.DLAddConsole(CONSOLE_ERROR_STRING,
                "Download failed!$nl$$nl$1. Link is unavailable$nl$2. Link is invalid$nl$3. Check internet connection.$nl$"                         +
                "4.YT-DLP might be outdated please update it first! ")                                                                              ;
            break                                                                                                                                   ;
            
            case 2                                                                                                                                  :
                console.DLAddConsole(CONSOLE_ERROR_STRING,
                "Convert failed! If error is consistent please report it to the author")                                                            ;
            break                                                                                                                                   ;}}}