namespace LauncherDL.StartUp;

partial class OnStartUp
{
    private static void InitializeLanguage()
    {
        Language = new(config.Language);
        AdjustFontSize();

        // Buttons
        buttonFileFormat.Text                                       =   Language.Button_Format;
        buttonDownload.Text                                         =   Language.Button_Download;
        buttonUpdate.Text                                           =   Language.Button_Update;
        buttonOpenFile.Text                                         =   Language.Button_OpenFile;
        buttonMetadata.Text                                         =   Language.Button_Metadata;

		// Placeholders
		textBoxLink.TextPlaceholder                                 =   Language.Placeholder_Link;
        textBoxName.TextPlaceholder                                 =   Language.Placeholder_Optional;

        // ComboBox
        ComboBoxList.ComboBoxTypes[TypeList.CustomType ].Content    =   Language.Types_Custom;
        ComboBoxList.ComboBoxTypes[TypeList.VideoType  ].Content    =   Language.Types_Video;
        ComboBoxList.ComboBoxTypes[TypeList.AudioType  ].Content    =   Language.Types_Audio;
        ComboBoxList.ComboBoxTypes[TypeList.ConvertType].Content    =   Language.Types_Convert;

        textBlockLink.Text                                          =   Language.Label_Link;
        textBlockFormat.Text                                        =   Language.Label_Format;
        textBlockName.Text                                          =   Language.Label_Name;
        textBlockType.Text                                          =   Language.Label_Type;
    }

    private static async void AdjustFontSize()
    {
        await WindowsComponents.WindowAwaitLoad(buttonFileFormat.IsLoaded);
        
        switch(config.Language)
        {
            case DLLanguages.Pick.LanguageName.Default:
                buttonFileFormat.TextSize      =    16;
                break;

            case DLLanguages.Pick.LanguageName.Japanese:
                buttonFileFormat.TextSize      =    16;
                break;

            case DLLanguages.Pick.LanguageName.bruh:
                buttonFileFormat.TextSize      =    14;
                buttonDownload.TextSize        =    18;
                buttonUpdate.TextSize          =    13;
                break;
        };
    }
}