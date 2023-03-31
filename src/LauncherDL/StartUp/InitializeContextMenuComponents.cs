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

    // Code was 100% refactored by one and only ChatGPT ☠️☠️
    public static void UpdateContexButtons()
    {
        ContextMenu contextMenu = (ContextMenu)MainWindowStatic.FindResource("OpenFolderCM");

        foreach(MenuItem menuItem in contextMenu.Items)
        {
            bool hasFolder = Directory.Exists($"{FolderButton.FolderDirectory()}\\{menuItem.Uid}");

            // Disable the menu item if there is no folder
            menuItem.IsEnabled = hasFolder;

            // Disable the menu item if there is no folder
            foreach(MenuItem childMenuItem in menuItem.Items)
            {
                bool childHasFolder = Directory.Exists($"{FolderButton.FolderDirectory()}\\{childMenuItem.Uid}");
                childMenuItem.IsEnabled = childHasFolder;
            }
        }
    }
}