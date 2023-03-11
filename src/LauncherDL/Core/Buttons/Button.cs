namespace LauncherDL.Core.Buttons;

public abstract class BodyButton
{
    private static bool IsFailed = false;

    public static void CheckLinkValidation()
    {
        // Check if link missing
        if (string.IsNullOrEmpty(textBoxLink.Text))
        {
            console.DLAddConsole(CONSOLE_ERROR_SOFT_STRING, " <%14>No link provided!");
            IsFailed = true;
        }
        else // Checks if link is valid
        {
            Uri uriResult;
            bool result = Uri.TryCreate(textBoxLink.Text, UriKind.Absolute, out uriResult) 
                && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);

            if(!result)
            {
                console.DLAddConsole(CONSOLE_ERROR_SOFT_STRING, " <%14>Link is invalid!");
                IsFailed = true;
            }
        }

        // Checks on Name characters
        if(!string.IsNullOrEmpty(textBoxName.Text))
        {
            string UnwantedChars = "\\/*:?\"<>|";
			char[] arr = UnwantedChars.ToCharArray();

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
            WindowsComponents.FreezeComponents();
    }
};