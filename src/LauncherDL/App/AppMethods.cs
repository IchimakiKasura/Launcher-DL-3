namespace LauncherDL;

public sealed partial class App
{
    // F̶i̶x̶e̶s̶ ̶t̶h̶e̶ ̶d̶r̶o̶p̶ ̶m̶e̶n̶u̶s̶ ̶g̶o̶i̶n̶g̶ ̶f̶r̶o̶m̶ ̶r̶i̶g̶h̶t̶ ̶t̶o̶ ̶l̶e̶f̶t̶ ̶b̶e̶c̶a̶u̶s̶e̶ ̶i̶ ̶d̶o̶n̶'̶t̶ ̶k̶n̶o̶w̶ ̶w̶h̶a̶t̶ ̶h̶a̶p̶p̶e̶n̶e̶d̶.̶
    // S̶o̶m̶e̶ ̶s̶a̶y̶ ̶i̶t̶s̶ ̶b̶e̶c̶a̶u̶s̶e̶ ̶o̶f̶ ̶t̶h̶e̶ ̶T̶a̶b̶l̶e̶t̶ ̶b̶u̶t̶ ̶I̶ ̶d̶o̶n̶'̶t̶ ̶u̶s̶e̶ ̶T̶a̶b̶l̶e̶t̶ ̶P̶C̶ ̶o̶r̶ ̶e̶v̶e̶n̶ ̶h̶a̶v̶e̶ ̶o̶n̶e̶.
    //
    // This context menu popup problem only occurs i think on Win11 because of the Pen Tablet thing.
    // Even though the Registry MenuDropDownAlignment is defaulted its still shows Right to Left on WPF apps
    // and this method fixes that problem on win11 users.
    //
    // see more on this issue: https://github.com/dotnet/wpf/issues/5944
    private static void ContextMenuAdjust()
    {
        var menuDropAlignmentField = typeof(SystemParameters).GetField("_menuDropAlignment", BindingFlags.NonPublic | BindingFlags.Static);

        SystemParameters.StaticPropertyChanged += (sender, e) =>
            menuDropAlignmentField.SetValue(null, SystemParameters.MenuDropAlignment && menuDropAlignmentField is not null ? false : null);
    }

    private void AppDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
    {
        var CurrentDate = DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss");
        var CustomMessage = e.Exception.InnerException != null ? e.Exception.InnerException.Message : string.Empty;
        var StackTrace = e.Exception.StackTrace.Replace(@"C:\Users\Administrator\Desktop\Coding\c# projects\", null); // Removes the dir
        var Message = $"===MESSAGE===\n{e.Exception.Message}\n\n\n===STACK TRACE===\n{StackTrace}";
        var errorMessage = $"It Appears the the application encounters an Error!\n\n{e.Exception.Message}";

        if(!CustomMessage.IsEmpty())
        {
            Message += $"\n\n\n===Custom Message===\n{CustomMessage}";
            errorMessage = $"It Appears the the application encounters an Error!\n\n{CustomMessage}";
        }

        File.WriteAllText($"ErrorDumpTrace_{CurrentDate}.txt", Message );

        if (MessageBox.Show(MainWindow, errorMessage, "Launcher DL", MessageBoxButton.OK, MessageBoxImage.Error) is MessageBoxResult.OK)
            Application.Current.Shutdown();

        e.Handled = true;
    }

    // Exception Catcher and write a file because the console freaking close too fast.
    #if DEBUG
        private void AppDebugException(object s, DispatcherUnhandledExceptionEventArgs e)
        {
            var CurrentDate = DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss");
            var CustomMessage = e.Exception.InnerException != null ? e.Exception.InnerException.Message : string.Empty;
            var StackTrace = e.Exception.StackTrace.Replace(@"C:\Users\Administrator\Desktop\Coding\c# projects\", null);
            var Message = $"===MESSAGE===\n{e.Exception.Message}\n\n\n===STACK TRACE===\n{StackTrace}";
            if(!CustomMessage.IsEmpty()) Message += $"\n\n\n===CUSTOM MESSAGE===\n{CustomMessage}";

            File.WriteAllText($"DEBUG_ErrorDumpTrace_{CurrentDate}.txt", Message );

            if (MessageBox.Show(MainWindow, "Encountered some Error on debug,\nPlease check the DEBUG_ErrorDumpTrace", "Oops", MessageBoxButton.OK, MessageBoxImage.Error) is MessageBoxResult.OK)
                Application.Current.Shutdown();

            e.Handled = true;
        }
    #endif

}