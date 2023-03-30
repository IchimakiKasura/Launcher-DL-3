namespace LauncherDL.StartUp;

partial class OnStartUp
{
    private static void InitializeContextMenuComponents()
    {
        ContextMenuResource.CONTEXTMENU_configDefaultDirectory = FolderButton.FolderDirectory();

        ContextMenuResource.Link = textBoxLink;
        ContextMenuResource.Format = comboBoxFormat;
        ContextMenuResource.Name = textBoxName;

        UpdateContexButtons();
    }

    public static void UpdateContexButtons()
    {
        // Disables buttons that has no folders
        foreach (MenuItem menuItems in ((ContextMenu)MainWindowStatic.FindResource("OpenFolderCM")).Items)
        {
            if (!Directory.Exists($"{FolderButton.FolderDirectory()}\\{menuItems.Uid}"))
            {
                if(menuItems.Items.Count is 0)
                    menuItems.IsEnabled = false;
            }
            else menuItems.IsEnabled = true;

            if (menuItems.Items.Count > 1)
                foreach (MenuItem formatExtItems in menuItems.Items)
                    if (!Directory.Exists($"{FolderButton.FolderDirectory()}\\{formatExtItems.Uid}"))
                        formatExtItems.IsEnabled = false;
                    else formatExtItems.IsEnabled = true;
        }
    }
}