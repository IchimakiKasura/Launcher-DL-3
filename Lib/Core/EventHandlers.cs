namespace Launcher_DL.Lib.Core;

/// <summary>The class name says it all</summary>
sealed class EventHandlers : Global
{
    public static void SetupEvents()
    {
        MainWindowStatic.Loaded += WindowsComp.Window_Loaded;
        MainWindowStatic.Closing += WindowsComp.Window_Close;
        MainWindowStatic.KeyDown += WindowsComp.Window_PreviewKeyDown;
        WindowDrag.MouseDown += WindowsComp.Window_Drag;
        Input_Type.SelectionChanged += ComboBoxComp.SelectedInputType;
        Button_Format.Click += Buttons.FileFormat;
        Button_Download.Click += Buttons.Download;
        Button_Update.Click += Buttons.Update;
        Open_File.Click += Buttons.OpenFile;

        Input_Format.DropDownOpened += delegate
        {
            if (Input_Format.Items.Count == 0)
                Input_Format.IsDropDownOpen = false;
        };

        WindowBG.MouseDown += delegate
        {
            Keyboard.ClearFocus();

            // remove the focus from the textbox
            FocusManager.SetFocusedElement(FocusManager.GetFocusScope(Input_Link), null);
            FocusManager.SetFocusedElement(FocusManager.GetFocusScope(Input_Name), null);
            FocusManager.SetFocusedElement(FocusManager.GetFocusScope(Input_Format), null);
        };

        #region Inputs
        Input_Link.MouseUp += delegate (object s, MouseButtonEventArgs e) { if (e.ChangedButton == MouseButton.Right) IsLink = true; IsName = IsFormat = false; };
        Input_Name.MouseUp += delegate (object s, MouseButtonEventArgs e) { if (e.ChangedButton == MouseButton.Right) IsName = true; IsLink = IsFormat = false; };
        Input_Format.MouseUp += delegate (object s, MouseButtonEventArgs e) { if (e.ChangedButton == MouseButton.Right) IsFormat = true; IsLink = IsName = false; };
        Input_Link.LostFocus += delegate (object s, RoutedEventArgs e) { if (string.IsNullOrWhiteSpace(Input_Link.Text.Trim())) Input_Link.Text = string.Empty; };
        Input_Name.LostFocus += delegate (object s, RoutedEventArgs e) { if (string.IsNullOrWhiteSpace(Input_Name.Text.Trim())) Input_Name.Text = string.Empty; };
        Input_Format.LostFocus += delegate (object s, RoutedEventArgs e) { if (string.IsNullOrWhiteSpace(Input_Format.Text.Trim())) Input_Format.Text = string.Empty; };
        #endregion

        #region Open Folder thing
        Open_Folder.Click += delegate { Buttons.OpenFolder(Config.DefaultOutput); };
        OpenDir_Audio.Click += delegate { Buttons.OpenFolder($"{Config.DefaultOutput}\\Audio"); };
        OpenDir_Video.Click += delegate { Buttons.OpenFolder($"{Config.DefaultOutput}\\Video"); };
        OpenDir_Convert.Click += delegate { Buttons.OpenFolder($"{Config.DefaultOutput}\\Convert"); };
        OpenDir_Logs.Click += delegate { Buttons.OpenFolder("Logs"); };

        OpenDir_webm.Click += delegate { Buttons.OpenFolder($"{Config.DefaultOutput}\\formatted\\webm"); };
        OpenDir_mFourA.Click += delegate { Buttons.OpenFolder($"{Config.DefaultOutput}\\formatted\\m4a"); };
        OpenDir_mpFour.Click += delegate { Buttons.OpenFolder($"{Config.DefaultOutput}\\formatted\\mp4"); };
        OpenDir_mpThree.Click += delegate { Buttons.OpenFolder($"{Config.DefaultOutput}\\formatted\\mp3"); };
        OpenDir_threeGP.Click += delegate { Buttons.OpenFolder($"{Config.DefaultOutput}\\formatted\\3gp"); };
        OpenDir_flv.Click += delegate { Buttons.OpenFolder($"{Config.DefaultOutput}\\formatted\\flv"); };
        OpenDir_mkv.Click += delegate { Buttons.OpenFolder($"{Config.DefaultOutput}\\formatted\\mkv"); };
        #endregion


        Input_Type.MouseMove += delegate (object s, MouseEventArgs e) { Follow(s, e, "Select a type of download."); };
        Input_Format.MouseMove += delegate (object s, MouseEventArgs e) { Follow(s, e, "Format?"); };
        Input_Link.MouseMove += delegate (object s, MouseEventArgs e) { Follow(s, e, "Link?"); };
        Input_Name.MouseMove += delegate (object s, MouseEventArgs e) { Follow(s, e, "Name?"); };
        Button_Format.MouseMove += delegate (object s, MouseEventArgs e) { Follow(s, e, "Fetch file formats"); };
        Button_Update.MouseMove += delegate (object s, MouseEventArgs e) { Follow(s, e, "Update"); };
        CloseButton.MouseMove += delegate (object s, MouseEventArgs e) { Follow(s, e, "Close"); };
        Minimize.MouseMove += delegate (object s, MouseEventArgs e) { Follow(s, e, "Minimize"); };
        Open_Folder.MouseMove += delegate (object s, MouseEventArgs e) { Follow(s, e, "Open downloaded files."); };
        ComboBox_Label_Custom.MouseMove += delegate (object s, MouseEventArgs e) { Follow(s, e, "Customize settings before downloading."); };
        ComboBox_Label_Video.MouseMove += delegate (object s, MouseEventArgs e) { Follow(s, e, "Download the Video format."); };
        ComboBox_Label_Audio.MouseMove += delegate (object s, MouseEventArgs e) { Follow(s, e, "Download the Audio format."); };
        ComboBox_Label_Convert.MouseMove += delegate (object s, MouseEventArgs e) { Follow(s, e, "Convert a file to another format type."); };
        Output_text.MouseMove += delegate (object s, MouseEventArgs e) { Follow(s, e, "Console Output"); };
        Window_Hidden.MouseMove += delegate (object s, MouseEventArgs e) { Follow(s, e, "Like bruh what's this Ⓒ thing? Isn't just I made CLI have a GUI?"); };
        Button_Download.MouseMove += delegate (object s, MouseEventArgs e)
        {
            Follow(s, e, "Download");
            if (Input_Type.SelectedIndex == 3) Follow(s, e, "Convert");
        };

    }

    static void Follow(object s, MouseEventArgs e, string Content)
    {
        if ((s as FrameworkElement).ToolTip == null)
            (s as FrameworkElement).ToolTip = new ToolTip() { Placement = System.Windows.Controls.Primitives.PlacementMode.Relative };
        var tip = ((s as FrameworkElement).ToolTip as ToolTip);
        tip.Foreground = Brushes.White;
        tip.Content = Content;
        tip.HorizontalOffset = e.GetPosition((s as FrameworkElement)).X + 10;
        tip.VerticalOffset = e.GetPosition((s as FrameworkElement)).Y + 10;
    }
}