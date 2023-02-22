namespace DLControls;

public partial class ConsoleControl
{
	[GeneratedRegex(@"<(?<color>.*?)(?:%(?:(?<size>.*?)\|(?<weight>.*?))|%(?<sizeOnly>.*?)|)>(?<text>.*?)(?=<|$)", RegexOptions.Compiled)]
	private static partial Regex MyRegex();
	readonly private static Regex RTBregex = MyRegex();

	// I don't know why I even add this cuz I know I only used he AddFormatedText cuz I can add colours lol
	public void AddText(string text, string color = default)
	{
		if (color == default) color = "White";
		TextRange tr = new(UserRichTextBox.Document.ContentEnd, UserRichTextBox.Document.ContentEnd) {Text = text + "\r"};
		tr.ApplyPropertyValue(TextElement.ForegroundProperty, new BrushConverter().ConvertFromString(color));
	}

	///<inheritdoc cref="AddFormattedText(string, bool)"/>
	public void AddFormattedText(string Input)
	{
		AddFormattedText(Input, false);
	}

	/// <summary id="1" >
	/// Append a Text with Format.<br/>
	/// <see langword="&lt;[COLOR / HEX] % [FONT SIZE?] | [FONT WEIGHT?]&gt; [TEXT]"/> <br/><br/>
	/// Example:<br/>
	/// <see langword="&quot;&lt;Red&gt;Hello &lt;Green&gt;World!&quot;"/><br/><br/>
	/// other Examples: <br/>
	/// <see langword="&quot;&lt;##ff0000&gt;Hello &lt;#00ff00&gt;World!&quot;"/><br/>
	/// <see langword="&quot;&lt;Red%15|Black&gt;Hello &lt;Green%15|Thin&gt;World!&quot;"/><br/>
	/// <see langword="&quot;&lt;Red%10&gt;Hello &lt;Green%5&gt;World!&quot;"/> <br/><br/>
	/// For escape characters Do this:<br/>
	/// for "&lt;" do <see langword="$lt$"/><br/>for "&gt;" do <see langword="$gt$"/><br/>
	/// for "%" do <see langword="$perc$"/><br/>for "|" than <see langword="$vbar$"/>
	/// </summary>
	/// <param name="Input">Input Text</param>
	/// <param name="DontAddNewline">Don't Automatically line?<br/>Default: <see langword="false"/></param>
	/// <exception cref="ForegroundPropertyException"/>
	/// <exception cref="FontSizePropertyException"/>
	/// <exception cref="FontWeightPropertyException"/>
	public void AddFormattedText(string Input, bool DontAddNewline)
	{
		// resets the Format
		Input += "<>";

		if (Input[..] != "<") Input = "<>" + Input;

		if (!DontAddNewline) Input += "\r";
		TextRange range;

		foreach (Match textMatch in RTBregex.Matches(Input).Cast<Match>()) 
		{
			range = new(UserRichTextBox.Document.ContentEnd, UserRichTextBox.Document.ContentEnd);

			// yes i'm not normal :D
			string color = string.IsNullOrEmpty(textMatch.Groups["color"].Value) ? "White" : textMatch.Groups["color"].Value;
			// bruh
			string size = string.IsNullOrEmpty(textMatch.Groups["size"].Value) ? string.IsNullOrEmpty(textMatch.Groups["sizeOnly"].Value) ? "19" : textMatch.Groups["sizeOnly"].Value : textMatch.Groups["size"].Value;
			string weight = string.IsNullOrEmpty(textMatch.Groups["weight"].Value) ? "Normal" : textMatch.Groups["weight"].Value;
			string text = textMatch.Groups["text"].Value;

			text = text.Replace("$lt$", "<");
			text = text.Replace("$gt$", ">");
			text = text.Replace("$perc$", "%");
			text = text.Replace("$vbar$", "|");

			try
			{
				range.Text = text;
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);
			}

			try { range.ApplyPropertyValue(TextElement.ForegroundProperty, new BrushConverter().ConvertFromString(color)); } catch { throw new ForegroundPropertyException("The Entered Color or Hex are Invalid."); };
			try { range.ApplyPropertyValue(Control.FontSizeProperty, size); } catch {  throw new FontSizePropertyException("The Entered font size are Invalid."); };
			try { range.ApplyPropertyValue(Control.FontWeightProperty, weight); } catch { throw new FontWeightPropertyException("The Entered font weight are Invalid."); };
		}
	}

	///<inheritdoc cref="SaveText(string)"/>
	public MemoryStream SaveText()
	{
		return SaveText(default);
	}

	/// <summary>
	/// Save text to <see cref="MemoryStream"/>
	/// </summary>
	/// <param name="format">Input string?</param>
	/// <returns><see cref="MemoryStream"/></returns>
	public MemoryStream SaveText(string format)
	{
		format ??= DataFormats.Xaml;

		FlowDocument doc = UserRichTextBox.Document;
		TextRange range = new(doc.ContentStart, doc.ContentEnd);
		MemoryStream TextStream = new();

		range.Save(TextStream, format);
		TextStream.Flush();
		TextStream.Seek(0, SeekOrigin.Begin);

		return TextStream;
	}

	/// <summary>Load text</summary>
	public void LoadText(MemoryStream Stream)
	{
		LoadText(Stream, default);
	}

	/// <summary>Load text</summary>
	public void LoadText(MemoryStream Stream, string format)
	{
		format ??= DataFormats.Xaml;

		FlowDocument doc = new();
		new TextRange(doc.ContentStart, doc.ContentEnd).Load(Stream, format);

		UserRichTextBox.Document = doc;
	}

	///<inheritdoc cref="Break(string)"/>
	public void Break()
	{
		Break("White");
	}

	/// <summary>
	/// Add line "==========================================="
	/// </summary>
	/// <param name="color">color</param>
	public void Break(string color)
	{
		TextRange tr = new(UserRichTextBox.Document.ContentEnd, UserRichTextBox.Document.ContentEnd) { Text = "===========================================\r" };
		tr.ApplyPropertyValue(TextElement.ForegroundProperty, new BrushConverter().ConvertFromString(color));
		//tr.ApplyPropertyValue(Control.FontSizeProperty, size);
	}

	/// <summary>
	/// Scroll To End alternative
	/// </summary>
	/// <param name="rt"></param>
	public void ScrollEndEvent(object s, EventArgs e)
	{
		if (!UserRichTextBox.IsInitialized) return;

		try
		{
			UserRichTextBox.ScrollToEnd();
		}
		catch
		{
			return;
		}
	}
}
