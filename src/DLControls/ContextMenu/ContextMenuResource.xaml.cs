namespace DLControls;

public partial class ContextMenuResource
{
    public static TextBoxControl Link;
    public static ComboBoxControl Format;
    public static TextBoxControl Name;
    public static string CONTEXTMENU_configDefaultDirectory;

    void OpenFolderProcess(object s, RoutedEventArgs e)
    {
        string FolderName = ((MenuItem)s).Uid;

        var CurrentDirectory = Path.Combine(CONTEXTMENU_configDefaultDirectory, FolderName);

        if(!Directory.Exists(CurrentDirectory))
            CurrentDirectory = Directory.GetCurrentDirectory();

        System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo()
        {
            FileName = "explorer.exe",
            Arguments = CurrentDirectory
        });
    }

    void ClearText(object s, RoutedEventArgs e)
    {
        if (Link.isTextBoxFocused) Link.Text = null;
        if (Format.isTextFocused)  Format.Text = null;
        if (Name.isTextBoxFocused) Name.Text = null;
    }
}