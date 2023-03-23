using static LauncherDL.Core.Attributes.ToolTipTextsAttribute;
namespace LauncherDL.Core.Event_Handlers;

internal class EventHandlers
{
    public static void InitializeEventHandlers()
    {
        #region windows stuffs
        MainWindowStatic.Loaded         +=      WindowsComponents.WindowLoaded;

        windowDrag.MouseDown            +=      WindowsComponents.WindowDrag;
        windowInnerBG.MouseDown         +=      (s,e) => Keyboard.ClearFocus();
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

        #endregion

        comboBoxType.OnItemChange       +=      TypeComboBox.ItemChanged;
        comboBoxFormat.OnItemChange     +=      FormatComboBox.ItemChanged;
        comboBoxQuality.OnItemChange    +=      QualityComboBox.ItemChanged;

        // ComboBox Tooltip list
        foreach(var ComboBoxTypeList in ComboBoxList.ComboBoxTypes)
            ComboBoxTypeList.MouseMove += (s,e) => Follow(s,e, ComboBoxTypeList.Content.ToString());

        foreach(var ComboBoxTypeList in ComboBoxList.ComboBoxFormatQuality)
            ComboBoxTypeList.MouseMove += (s,e) => Follow(s,e, ComboBoxTypeList.Content.ToString());
    }
}