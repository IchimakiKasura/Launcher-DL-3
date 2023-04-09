namespace LauncherDL                                                                                                                                                    .
          Core                                                                                                                                                          .
          ConsoleDL                                                                                                                                                     ;/*

Yes this is very unforgivable :D                                                                                                                                        */
internal sealed partial class ConsoleLive                                                                                                                               {/*
    
    0 = File format                                                                                                                         
    1 = Download                                                                                                                            
    2 = Validation                                                                                                                                                      
    3 = Convert                                                                                                                                                         */
    public static int SelectedError = 0                                                                                                                                 ;/*
    
    Avoid multiple instances of error outputs when
    it spews tons of errors so yeah                                                                                                                                     */
    public static bool SingleErrorInstance = false                                                                                                                      ;
    
    public static void ErrorOutputComment(object s, DataReceivedEventArgs e)                                                                                            =>
        DL_Dispatch.Invoke(()=>Error_Invoked(e.Data))                                                                                                                   ;

    public static void Error_Invoked(string StringData)                                                                                                                 {
        if (!SingleErrorInstance && !StringData.IsEmpty() && !Regex.IsMatch(StringData,@"\[(twitter|generic)\]"))
            switch(SelectedError)                                                                                                                                       {
                case 0                                                                                                                                                  :
                    console.DLAddConsole(CONSOLE_ERROR_STRING,
                    $"URL cannot be fetched! {ERROR_MESSAGE_HINT}")                                                                                                     ;
                    SingleErrorInstance = true                                                                                                                          ;
                break                                                                                                                                                   ;
                
                case 1                                                                                                                                                  :
                    console.DLAddConsole(CONSOLE_ERROR_STRING,
                    $"Download failed! {ERROR_MESSAGE_HINT}")                                                                                                           ;
                    SingleErrorInstance = true                                                                                                                          ;
                break                                                                                                                                                   ;
                
                case 2                                                                                                                                                  :
                    console.DLAddConsole(CONSOLE_ERROR_STRING,
                    $"Validation failed! {ERROR_MESSAGE_HINT}")                                                                                                         ;
                    SingleErrorInstance = true                                                                                                                          ;
                break                                                                                                                                                   ;

                case 3                                                                                                                                                  :
                    console.DLAddConsole(CONSOLE_ERROR_STRING, ERROR_MESSAGE_CONVERT)                                                                                   ;
                    SingleErrorInstance = true                                                                                                                          ;
                break                                                                                                                                                   ;}}}