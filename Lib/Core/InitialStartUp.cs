namespace Launcher_DL.Lib.Core;

sealed class InitialStartUp : Global
{
    public static void Initialize()
    {
        CancellationTokenSource newSource = new CancellationTokenSource();
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

        #region Output Log Startup Texts
        Output_text.AddFormattedText("<Gray%15>堂主の私に何か用かな？あれ、知らなかった？私が往生堂七十七代目堂主、胡桃だよ！でもあなた、ツヤのある髪に健康そうな体してる･･･そっか！仕事以外で私に用があるってことだね？<>");
        Output_text.Break("Gray");

        Output_text.AddFormattedText("<>welcome, <#ff4747%20|ExtraBlack>Hutao <>here!");
        if (Config.ShowSystemOutput) Output_text.AddFormattedText($"<#a85192%14>[SYSTEM] <Gray%14>Changed TYPE to \"{((ComboBoxItem)Input_Type.SelectedItem).Content}\"");
        #endregion

        // Loads the config and Language.
        ConfigComp.LoadConfig(newSource.Token).GetAwaiter();
        System_Language_Handler.LoadLanguage(newSource.Token).GetAwaiter();


        MainWindowStatic.Show();
        MainWindowStatic.ShowActivated = true;
        MainWindowStatic.Topmost = true;
    }

    public static Color ClrConv(string color) { return (Color)ColorConverter.ConvertFromString(color); }
}