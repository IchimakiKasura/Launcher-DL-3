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
        int MenuItemsIteration = 0,
            MenuItemChildIteration = 0;

        ContextMenu contextMenu = GetResources<ContextMenu>("OpenFolderCM");

        while(MenuItemsIteration < contextMenu.Items.Count)
        {
            var menuItemVar = (MenuItem)contextMenu.Items[MenuItemsIteration];
            string menuItemPath = Path.Combine(FolderButton.FolderDirectory(), menuItemVar.Uid);

            menuItemVar.IsEnabled = Directory.Exists(menuItemPath);

            while(MenuItemChildIteration < menuItemVar.Items.Count)
            {
                var childMenuItemVar = (MenuItem)menuItemVar.Items[MenuItemChildIteration];
                string childMenuItemPath = Path.Combine(FolderButton.FolderDirectory(), childMenuItemVar.Uid);

                childMenuItemVar.IsEnabled = Directory.Exists(childMenuItemPath);
                MenuItemChildIteration++;
            }
            MenuItemsIteration++;
        }
    }
}