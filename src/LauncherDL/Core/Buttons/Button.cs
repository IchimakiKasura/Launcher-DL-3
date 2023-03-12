namespace LauncherDL.Core.Buttons;

public abstract class BodyButton
{
    private static bool IsFailed;

    public static bool CheckLinkValidation()
    {
        // Resets the static variable
        IsFailed = false;

        // Check if link missing
        if (string.IsNullOrEmpty(textBoxLink.Text))
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
        if(!string.IsNullOrEmpty(textBoxName.Text))
        {
            string UnwantedChars    = "\\/*:?\"<>|";
            char[] arr              = UnwantedChars.ToCharArray();

            foreach (char ch in arr)
            {
                if (textBoxLink.Text.Contains(ch))
                {
                    MessageBox.Show("File name cannot contain the following characters:"+
                                    "\n                             \\ / * : ? \" < > |",
                                    "Error",
                                    MessageBoxButton.OK,
                                    MessageBoxImage.Error);
                    IsFailed = true;
               }
           }
        }

        if(!IsFailed)
        {
            WindowsComponents.FreezeComponents();
            return true;
        } else return false;
    }
};