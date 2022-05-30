namespace Launcher_DL.Lib.ConsoleOutput;

/// <summary>Comment</summary>
sealed class ConsoleComment : Global
{
	public static void UserCommentDetect()
	{
		Input_Link.KeyDown += delegate (object s, KeyEventArgs e)
		{
			if (e.Key == Key.Enter)
			{
				if (Input_Link.Text.Contains(":?comment>"))
				{
					var Text = Input_Link.Text.Replace(":?comment>", "");
					Output_text.AddFormattedText(Text);
					Input_Link.Text = string.Empty;
				}

				if (Input_Link.Text.Contains(":?help>"))
				{
					Input_Link.Text = string.Empty;
					Output_text.AddFormattedText("<White%12>[help] <Gray%12>Welcome to help command!");
					Output_text.AddFormattedText("<Gray%12>Here are the available options:");
					Output_text.AddFormattedText("<Gray%12>1.) \":?help$gt$\" - will bring this up.");
					Output_text.AddFormattedText("<Gray%12>2.) \":?comment$gt$>\"   - will let you add your own text in the console.");
					Output_text.AddFormattedText("<Gray%12>Here are the comment formatting:\r$lt$COLOR$perc$SIZE$vbar$FONTWEIGHT$gt$TEXT");
					Output_text.AddFormattedText("<Gray%12>ex: $lt$Yellow%12$gt$Hello");
				}
			}
		};
	}
}