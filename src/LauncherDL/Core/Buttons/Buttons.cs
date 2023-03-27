namespace LauncherDL.Core.Buttons;

public abstract class BodyButton
{
    private static bool IsFailed;

    public static async Task<bool> CheckLinkValidation()
    {
        // Resets the static variable
        IsFailed = false;

        // Check if link missing
        if (textBoxLink.Text.IsEmpty())
        {
            ConsoleOutputMethod.NoLinkOutputComment();
            IsFailed = true;
        }
        else // Checks if link is valid
        {
            Uri uriResult;
            bool result = Uri.TryCreate(textBoxLink.Text, UriKind.Absolute, out uriResult) 
                && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);

            if(!result)
            {
                ConsoleOutputMethod.NoLinkOutputComment();
                IsFailed = true;
            }
        }

        // Checks on Name characters
        if(!textBoxName.Text.IsEmpty())
        {
            string UnwantedChars    = "\\/*:?\"<>|";
            char[] arr              = UnwantedChars.ToCharArray();

            foreach (char ch in arr)
                if (textBoxName.Text.Contains(ch) && !IsFailed)
                {
                    MessageBox.Show("File name cannot contain the following characters:"+
                                    "\n                             \\ / * : ? \" < > |",
                                    "Error",
                                    MessageBoxButton.OK,
                                    MessageBoxImage.Error);
                    IsFailed = true;
               }
        }

        // Avoids being fired when the link validation already failed
        // because it'll take more time
        if(!IsFailed)
        {
            console.DLAddConsole(CONSOLE_INFO_STRING, $"Fetching Link..$nl$<Gray%10>{textBoxLink.Text}");
            var ValidateLink = await new LauncherDL.Core.TaskProcess.LinkValidate(textBoxLink.Text).Validate();

            if(!config.EnablePlaylist && ValidateLink.HasPlaylist)
            {
                console.DLAddConsole(CONSOLE_INFO_STRING, $"Playlist was found! please enable the playlist on th config!");
                IsFailed = true;
            }

            if(!ValidateLink.IsValid)
                IsFailed = true;
        }
        

        if(!IsFailed) return true;
        else return false;
    }
};