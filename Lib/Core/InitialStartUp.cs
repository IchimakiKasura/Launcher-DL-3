namespace Launcher_DL.Lib.Core;

/// <summary>Startup Class</summary>
sealed class InitialStartUp : Global
{
    /// <summary>Setups the settings and variables</summary>
    public static void Initialize()
    {
        CancellationTokenSource newSource = new();
        CancellationTokenSource oldSource = Interlocked.Exchange(ref CancelWork, newSource);
        if (oldSource != null)
        {
            oldSource.Cancel();
            oldSource.Dispose();
        }

        //idfk whats dis
        MediaTimeline.DesiredFrameRateProperty.OverrideMetadata(typeof(Timeline), new FrameworkPropertyMetadata(60));

        WindowsComp.WindowFocusAnimation();
        ConsoleComment.UserCommentDetect();
        EventHandlers.SetupEvents();
        OpenFolderCheck.OpenFolderChecks();

        // help
        // EDIT: Turns out its just my CPU (2.4Ghz) is slow thats why the animations are choppy when my CPU is on full load.
        // like If chrome is opened the animation is choppy because of chrome using too much cpu.
        // my current cpu is 12 yrs old and have no money to buy new one.
        //
        // EDIT 3/25/22: Got a new CPU which is faster (Xeon E5 2640) I know its still old but its still works,
        // 6C/12T 2.5Ghz Turbo to 3Ghz (2.8Ghz).
        //
        // EDIT 4/13/22: Disabled most of the animations so it no longer lags or becomes choppy
        // You can manually disable the animations or if it detects that you have a lower DX version
        // it'll automatically turns off the animations.
        if ((RenderCapability.Tier >> 16) != 2)
        {
            MessageBox.Show("Looks like you have a poor GPU that only supports DX8 and below?\nI require a beefy gpu for epic animations but for now the animations are\nautomatically turned off now.", "woah..", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            Config.EpicAnimations = false;
        }

        OutputComments.StartUpOutputComments();

        // Loads the config and Language.
        ConfigComp.LoadConfig(newSource.Token).GetAwaiter();
        System_Language_Handler.LoadLanguage(newSource.Token).GetAwaiter();


        MainWindowStatic.Visibility = Visibility.Visible;
        MainWindowStatic.ShowActivated = true;
    }
}