namespace LauncherDL.StartUp;

internal sealed partial class OnStartUp
{
    private static void InitializeButtonsComponents()
    {
        // Button Background
        buttonFileFormat.Image          =   AkiraImage;
        buttonDownload.Image            =   AstolfoImage;
        buttonUpdate.Image              =   VentiImage;
        buttonOpenFile.Image            =   MeguminImage;
        buttonMetadata.Image            =   HimeImage;

        // Button Icons
        buttonFileFormat.Icon           =   FileFormatIcon;
        buttonDownload.Icon             =   DownloadIcon;
        buttonUpdate.Icon               =   UpdateIcon;
        buttonOpenFile.Icon             =   OpenFileIcon;
        buttonMetadata.Icon             =   MetadataIcon;

        // Button Border Color Effect
        buttonFileFormat.BorderEffect   =   Colors.Blue;
        buttonDownload.BorderEffect     =   Colors.Pink;
        buttonUpdate.BorderEffect       =   Colors.Aqua;
        buttonOpenFile.BorderEffect     =   Colors.Red;
        buttonMetadata.BorderEffect     =   Colors.PeachPuff;

        // Button Icon Heights
        buttonFileFormat.IconHeight     =
        buttonUpdate.IconHeight         =
        buttonOpenFile.IconHeight       =
        buttonMetadata.IconHeight       =   35;

        // Button Storyboards
        buttonFileFormat.IsAnimationOn  =
        buttonDownload.IsAnimationOn    =
        buttonUpdate.IsAnimationOn      =
        buttonOpenFile.IsAnimationOn    =
        buttonMetadata.IsAnimationOn    =   config.EpicAnimations;

        // Open Folder button
        SetCanvas(ButtonOpenFolder, 510, 755);
        
        if(Directory.Exists(config.DefaultOutput))
            windowCanvas.Add(ButtonOpenFolder);
    }
}