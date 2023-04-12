namespace LauncherDL.Core.Metadata;

public interface IMetadataComponent
{
    void InitializeComponent();
    void SetupControls();
    void EventHandlers();
    MetadataClicked OpenDialog();
}