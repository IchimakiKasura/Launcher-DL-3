namespace LauncherDL.Core.Extensions;

internal static class _Core_Extensions
{
    #region Canvas
    /// <summary>
    /// Add UIElement to the Canvas. <br/>
    /// Automatically cancels if the Canvas already contains the Element.
    /// </summary>
    public static void Add(this Canvas _canvas, UIElement Element)
    {
        if(!_canvas.Contains(Element))
            _canvas.Children.Add(Element);
    }
    /// <summary>
    /// Remove UIElement to the Canvas. <br/>
    /// Automatically cancels if the Canvas already removed.
    /// </summary>
    public static void Remove(this Canvas _canvas, UIElement Element)
    {
        if(_canvas.Contains(Element))
            _canvas.Children.Remove(Element);
    }
    public static bool Contains(this Canvas _canvas, UIElement Element) =>
        _canvas.Children.Contains(Element);
    #endregion

    #region Process
    /// <summary>
    /// Starts the process Asynchronously without freezing the UI.
    /// </summary>
    /// <param name="_proc"></param>
    /// <returns><see langword="true"/> if resource is started; <see langword="false"/> if no new resource process is started </returns>
    public static async Task<bool> StartAsync(this Process _proc) =>
        await Task.Run(()=>_proc.Start());
    public static async Task<Process> StartAsync(this Process _proc, ProcessStartInfo _procStartInfo) =>
        await Task.Run(()=>Process.Start(_procStartInfo));
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