namespace LauncherDL.StartUp;

partial class OnStartUp
{
    private static void InitiateProgressBar()
    {
        progressBar = new() { Width = 555 };
        Canvas.SetLeft(progressBar, 300);
        Canvas.SetTop(progressBar, 490);
    }
}