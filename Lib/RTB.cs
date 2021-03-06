using System.Linq;
namespace Launcher_DL.Lib;

/// <summary>
/// From build ver5.0
/// </summary>
public static class LauncherDL_RichTextBoxHandler
{
	readonly private static Regex RTBregex = new(@"<(?<color>.*?)(?:%(?:(?<size>.*?)\|(?<weight>.*?))|%(?<sizeOnly>.*?)|)>(?<text>.*?)(?=<|$)", RegexOptions.Compiled);

	// I don't know why I even add this cuz I know I only used he AddFormatedText cuz I can add colours lol
	public static void AddText(this RichTextBox box, string text, string color = default)
	{
		if (color == default) color = "White";
		TextRange tr = new(box.Document.ContentEnd, box.Document.ContentEnd);
		tr.Text = text + "\r";
		tr.ApplyPropertyValue(TextElement.ForegroundProperty, new BrushConverter().ConvertFromString(color));
	}

	/// <summary>
	/// <see langword="&lt;[COLOR / HEX] % [FONT SIZE?] | [FONT WEIGHT?]&gt; [TEXT]"/> <br/>
	/// Append a Text with Format.<br/>
	/// Example:<br/>
	/// <see langword="&quot;&lt;Red&gt;Hello &lt;Green&gt;World!&quot;"/><br/>
	/// other Examples: <br/>
	/// <see langword="&quot;&lt;##ff0000&gt;Hello &lt;#00ff00&gt;World!&quot;"/><br/>
	/// <see langword="&quot;&lt;Red%15|Black&gt;Hello &lt;Green%15|Thin&gt;World!&quot;"/><br/>
	/// <see langword="&quot;&lt;Red%10&gt;Hello &lt;Green%5&gt;World!&quot;"/> <br/>
	/// For escape characters Do this:<br/>
	/// for "&lt;" do <see langword="$lt$"/><br/>for "&gt;" do <see langword="$gt$"/><br/>
	/// for "%" do <see langword="$perc$"/><br/>for "|" than <see langword="$vbar$"/>
	/// </summary>
	/// <param name="Input">Input Text</param>
	/// <param name="DontAddNewline">Don't Automatically line?<br/>Default: <see langword="false"/></param>
	/// <exception cref="ForegroundPropertyException"/>
	/// <exception cref="FontSizePropertyException"/>
	/// <exception cref="FontWeightPropertyException"/>
	public static void AddFormattedText(this RichTextBox rt, string Input, bool DontAddNewline = false)
	{
		// resets the Format
		Input = Input + "<>";

		if (Input.Substring(0) != "<") Input = "<>" + Input;

		if (!DontAddNewline) Input = Input + "\r";
		TextRange range;
		foreach (Match textMatch in RTBregex.Matches(Input))
		{
			range = new(rt.Document.ContentEnd, rt.Document.ContentEnd);

			// "??" OPERATOR WONT WORK??
			string color = textMatch.Groups["color"].ToString();
			string size = textMatch.Groups["size"].ToString();
			string weight = textMatch.Groups["weight"].ToString();
			string text = textMatch.Groups["text"].ToString();

			#region THE "??" OPERATOR WONT WORK HELP
			if (size == string.Empty) size = textMatch.Groups["sizeOnly"].ToString();
			if (color == string.Empty) color = "White";
			if (size == string.Empty) size = "19";
			if (weight == string.Empty) weight = "Normal";
			#endregion

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
			try { range.ApplyPropertyValue(Control.FontSizeProperty, size); } catch { throw new FontSizePropertyException("The Entered font size are Invalid."); };
			try { range.ApplyPropertyValue(Control.FontWeightProperty, weight); } catch { throw new FontWeightPropertyException("The Entered font weight are Invalid."); };
		}
	}

	/// <summary>
	/// Save text to <see cref="MemoryStream"/>
	/// </summary>
	/// <returns><see cref="MemoryStream"/></returns>
	public static MemoryStream SaveText(this RichTextBox rt, string format = default)
	{
		if (format == null) format = DataFormats.Xaml;

		FlowDocument doc = rt.Document;
		TextRange range = new(doc.ContentStart, doc.ContentEnd);
		MemoryStream TextStream = new();

		range.Save(TextStream, format);
		TextStream.Flush();
		TextStream.Seek(0, SeekOrigin.Begin);

		return TextStream;
	}

	/// <summary>
	/// Load text
	/// </summary>
	public static void LoadText(this RichTextBox rt, MemoryStream Stream, string format = default)
	{
		if (format == null) format = DataFormats.Xaml;

		FlowDocument doc = new();
		new TextRange(doc.ContentStart, doc.ContentEnd).Load(Stream, format);

		rt.Document = doc;
	}

	/// <summary>
	/// Add line "================================="
	/// </summary>
	/// <param name="color"></param>
	public static void Break(this RichTextBox rt, string color = default)
	{
		if (color == default) color = "White";
		TextRange tr = new(rt.Document.ContentEnd, rt.Document.ContentEnd);
		tr.Text = "=================================\r";
		tr.ApplyPropertyValue(TextElement.ForegroundProperty, new BrushConverter().ConvertFromString(color));
		//tr.ApplyPropertyValue(Control.FontSizeProperty, size);
	}

	/// <summary>
	/// Scroll To End alternative
	/// </summary>
	/// <param name="rt"></param>
	public static void ScrollEndEvent(this RichTextBox rt, object s, EventArgs e)
	{
		if(!rt.IsInitialized) return;
		
		try
		{
			rt.ScrollToEnd();
		}
		catch {
			//MessageBox.Show("ass");
			return;
		}
	}
}

[Serializable]
public class ForegroundPropertyException : Exception
{
	public ForegroundPropertyException() { }
	public ForegroundPropertyException(string message)
		: base(message) { }
}

[Serializable]
public class FontSizePropertyException : Exception
{
	public FontSizePropertyException() { }
	public FontSizePropertyException(string message)
		: base(message) { }
}

[Serializable]
public class FontWeightPropertyException : Exception
{
	public FontWeightPropertyException() { }
	public FontWeightPropertyException(string message)
		: base(message) { }
}
