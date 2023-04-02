namespace LauncherDL.Core.Buttons;

internal abstract class BodyButton
{
    private static bool IsFailed;

    public static async Task<bool> CheckLinkValidation()
    {
        IsFailed = false;

        if (textBoxLink.Text.IsEmpty()
            || !Uri.TryCreate(textBoxLink.Text, UriKind.Absolute, out Uri uriResult)
            || !(uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps) )
        {
            ConsoleOutputMethod.NoLinkOutputComment();
            IsFailed = true;
        }

        // Checks on Name characters
        if(!textBoxName.Text.IsEmpty())
        {
            string UnwantedChars    = "\\/*:?\"<>|";
            char[] arr              = UnwantedChars.ToCharArray();
            var Message = new StringBuilder()
                .Append("File name cannot contain the following characters:")
                .Append("\n                             \\ / * : ? \" < > |")
                .ToString();

            foreach (char ch in arr)
                if (textBoxName.Text.Contains(ch) && !IsFailed)
                {
                    MessageBox.Show(Message,
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

            if(!ValidateLink.IsValid)
                IsFailed = true;
        }
        

        if(!IsFailed) return true;
        else return false;
    }
};