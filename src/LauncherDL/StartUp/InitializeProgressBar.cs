namespace LauncherDL.StartUp;

internal sealed partial class OnStartUp
{
    // Progress bar looking loneley 🥲
    private static void InitiateProgressBar()
    {
        progressBar = new() { Width = 555 };
        SetCanvas(progressBar, 490, 300);
    }
}