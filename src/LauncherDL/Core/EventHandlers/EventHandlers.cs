using static LauncherDL.Core.Attributes.ToolTipTextsAttribute;
namespace LauncherDL.Core.Event_Handlers;

internal sealed class EventHandlers
{
    public static void InitializeEventHandlers()
    {
        #region windows stuffs
        MainWindowStatic.Loaded         +=      WindowsComponents.WindowLoaded;
        MainWindowStatic.Closing        +=      WindowsComponents.WindowOnClose;

        windowDrag.MouseDown            +=      WindowsComponents.WindowDrag;
        windowInnerBG.MouseDown         +=      (s,e) => Keyboard.ClearFocus();

        textBlockFooter.MouseDown       +=      (s,e) => MessageBox.Show(hidden, "Huzuaah!", MessageBoxButton.OK, MessageBoxImage.Information);
        #endregion

        #region Buttons

        // Top buttons
        Minimize.Click                  +=      TopButtons.MinimizeWindow;
        CloseButton.Click               +=      TopButtons.CloseWindow;

        // Body buttons
        buttonFileFormat.Click          +=      FileFormatButton.ButtonClicked;
        buttonDownload.Click            +=      DownloadButton.ButtonClicked;
        buttonUpdate.Click              +=      UpdateButton.ButtonClicked;
        buttonOpenFile.Click            +=      FileButton.ButtonClicked;
        buttonMetadata.Click            +=      MetadataButton.ButtonClicked;
        ButtonOpenFolder.Click          +=      FolderButton.ButtonClicked;

        #endregion

        comboBoxType.OnItemChange       +=      TypeComboBox.ItemChanged;
        comboBoxFormat.OnItemChange     +=      FormatComboBox.ItemChanged;
        comboBoxQuality.OnItemChange    +=      QualityComboBox.ItemChanged;

        // lmaooooooo
        #pragma warning disable CS8848

        #region ComboBox Tooltip List (CTL)
        
        void AttachToolTip(ComboBoxItem CTL, string text) =>
            CTL.MouseMove += (s,e) => Follow(s,e, CTL.Content as string + text);

        Dictionary<ImmutableList<ComboBoxItem>, string> CTL_ToolTip = new()
        {
            {ComboBoxList.ComboBoxTypes, " Type?"},
            {ComboBoxList.ComboBoxVideoFormats, " Format"},
            {ComboBoxList.ComboBoxAudioFormats, " Format"},
            {ComboBoxList.ComboBoxFormatQuality, " Quality"}
        };

        foreach(var Dictionary_CTL in CTL_ToolTip)
            foreach(var CTL in Dictionary_CTL.Key)
                AttachToolTip(CTL, Dictionary_CTL.Value);
        #endregion

        #pragma warning restore CS8848
    }
}