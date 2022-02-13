namespace Launcher_DL_v6;

public partial class MainWindow
{
    private async Task StartProcess(YTDL_object YT)
    {
        DocumentTemp = Output_text.SaveText();

        if(YT.IsUpdate) await UpdateTask(YT);
    }

    private void ProcessEnds()
    {

    }

}