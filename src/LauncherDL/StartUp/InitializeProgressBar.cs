namespace LauncherDL.StartUp;

partial class OnStartUp
{
    private static void InitiateProgressBar()
    {
        progressBar = new() { Width = 502 };
        Canvas.SetLeft(progressBar, 300);
        Canvas.SetTop(progressBar, 434);
    }
}