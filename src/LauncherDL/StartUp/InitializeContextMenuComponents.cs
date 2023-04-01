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
        ContextMenu contextMenu = GetResources<ContextMenu>("OpenFolderCM");

        foreach(MenuItem menuItem in contextMenu.Items)
        {
            string menuItemPath = Path.Combine(FolderButton.FolderDirectory(), menuItem.Uid);
            bool hasFolder = Directory.Exists(menuItemPath);

            // Disable the menu item if there is no folder
            menuItem.IsEnabled = hasFolder;

            // Disable the menu item if there is no folder
            foreach(MenuItem childMenuItem in menuItem.Items)
            {
                string childMenuItemPath = Path.Combine(FolderButton.FolderDirectory(), childMenuItem.Uid); 
                bool childHasFolder = Directory.Exists(childMenuItemPath);
                childMenuItem.IsEnabled = childHasFolder;
            }
        }
    }
}