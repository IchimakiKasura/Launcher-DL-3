namespace LauncherDL.Core.Metadata;

public partial class MetadataWindow
{
    private void SetupToolTips()
    {
		BindingFlags MainWindowFieldFlags = BindingFlags.Instance|BindingFlags.Public|BindingFlags.CreateInstance|BindingFlags.NonPublic;

        foreach(var MainWindowField in typeof(MetadataWindow).GetRuntimeFields())
        {
            var ToolTipTextAttribute = MainWindowField.GetCustomAttribute<ToolTipTextsAttribute>();
            var Name = MainWindowField.Name;
            
            // Sets all Tooltips
            if(ToolTipTextAttribute is not null)
                ToolTipTextAttribute.SetToolTipText<MetadataWindow>(Name, ToolTipTextAttribute.Description, MainWindowFieldFlags);
            
        }
    }
}