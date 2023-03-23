namespace LauncherDL.Core.Extensions;

internal static class _Core_Extensions
{
    #region Canvas
    public static void Add(this Canvas _canvas, UIElement Element) =>
        _canvas.Children.Add(Element);
    public static void Remove(this Canvas _canvas, UIElement Element) =>
        _canvas.Children.Remove(Element);
    public static bool Contains(this Canvas _canvas, UIElement Element) =>
        _canvas.Children.Contains(Element);
    #endregion

    #region Process
    public static async Task StartAsync(this Process _proc) =>
        await Task.Run(()=>_proc.Start());
    #endregion

    #region ConsoleControl
    public static void DLAddConsole(this ConsoleControl console,string TypeString, string FormattedText, bool Italic = false, bool NoNL = false)
    {
        switch(TypeString)
        {
            case string when TypeString.Contains(CONSOLE_SYSTEM_STRING) && config.ShowSystemOutput:
                console.AddFormattedText($"{TypeString} {FormattedText}", Italic, NoNL);
            break;

            case string when !TypeString.Contains(CONSOLE_SYSTEM_STRING):
                console.AddFormattedText($"{TypeString} {FormattedText}", Italic, NoNL);
            break;
        };
    }
    #endregion

    #region Strings
    public static bool IsEmpty(this string str) =>
        string.IsNullOrEmpty(str);
    #endregion
}