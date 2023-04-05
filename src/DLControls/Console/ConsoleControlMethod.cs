namespace DLControls;

public partial class ConsoleControl
{
    [GeneratedRegex(@"<(?<color>.*?)(?:%(?:(?<size>.*?)\|(?<weight>.*?))|%(?<sizeOnly>.*?)|)>(?<text>.*?)(?=<|$)", RegexOptions.Compiled)]
    private static partial Regex MyRegex();
    readonly private static Regex RTBregex = MyRegex();

    // I don't know why I even add this cuz I know I only used he AddFormatedText cuz I can add colours lol
    public void AddText(string text, string color = null)
    {
        if (color is "" or null) color = "White";
        TextRange tr = new(UserRichTextBox.Document.ContentEnd, UserRichTextBox.Document.ContentEnd) {Text = text + "\r"};
        tr.ApplyPropertyValue(TextElement.ForegroundProperty, new BrushConverter().ConvertFromString(color));
    }


    ///<inheritdoc cref="AddFormattedText(string, bool, bool)"/>
    public void AddFormattedText(string Input) => AddFormattedText(ref Input, false, false);

    ///<inheritdoc cref="AddFormattedText(ref string, bool, bool)"/>
    public void AddFormattedText(string Input, bool isItalic) => AddFormattedText(ref Input,isItalic, false);
    ///<inheritdoc cref="AddFormattedText(ref string, bool, bool)"/>
    public void AddFormattedText(ref string Input) => AddFormattedText(ref Input, false, false);

    ///<inheritdoc cref="AddFormattedText(ref string, bool, bool)"/>
    public void AddFormattedText(ref string Input, bool isItalic) => AddFormattedText(ref Input,isItalic, false);

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
    /// for "%" do <see langword="$perc$"/><br/>for "|" than <see langword="$vbar$"/><br/>
    /// for "tabs" or "\t" do <see langword="$tab$"/><br/>for "new line" or "/n" do <see langword="$nl$"/>
    /// </summary>
    /// <param name="Input">Input Text</param>
    /// <param name="isItalic">add that sweet leaning type of shit</param>
    /// <param name="DontAddNewline">Don't Automatically line?<br/>Default: <see langword="false"/></param>
    /// <exception cref="ForegroundPropertyException"/>
    /// <exception cref="FontSizePropertyException"/>
    /// <exception cref="FontWeightPropertyException"/>
    public void AddFormattedText(ref string Input, bool isItalic, bool DontAddNewline)
    {
        // resets the Format
        Input += "<>";

        if (Input[..] != "<") Input = "<>" + Input;

        if (!DontAddNewline) Input += "\r";
        TextRange range;
        FontStyle _FontStyle = FontStyles.Normal;
        MatchCollection textMatches = RTBregex.Matches(Input);
        int index = 0;

        while(index < textMatches.Count)
        {
            Match textMatch = textMatches[index];

            range = new(UserRichTextBox.Document.ContentEnd, UserRichTextBox.Document.ContentEnd);

            // yes i'm not normal :D
            string color = textMatch.Groups["color"].Value.IsEmpty() ? "White" : textMatch.Groups["color"].Value;
            // bruh
            string size = textMatch.Groups["size"].Value.IsEmpty() ? textMatch.Groups["sizeOnly"].Value.IsEmpty() ? "19" : textMatch.Groups["sizeOnly"].Value : textMatch.Groups["size"].Value;
            string weight = textMatch.Groups["weight"].Value.IsEmpty() ? "Normal" : textMatch.Groups["weight"].Value;
            string text = textMatch.Groups["text"].Value;

            if (isItalic) _FontStyle = FontStyles.Italic;

            text = text.Replace("$lt$", "<")
            .Replace("$gt$", ">")
            .Replace("$perc$", "%")
            .Replace("$vbar$", "|")
            .Replace("$tab$", "\t")
            .Replace("$nl$", "\r");

            try { range.Text = text; } catch { throw new TextPropertyException(); };
            range.ApplyPropertyValue(Control.FontStyleProperty, _FontStyle);
            try { range.ApplyPropertyValue(TextElement.ForegroundProperty   , new BrushConverter().ConvertFromString(color) ); } catch { throw new ForegroundPropertyException();   };
            try { range.ApplyPropertyValue(Control.FontSizeProperty         , size                                          ); } catch { throw new FontSizePropertyException();     };
            try { range.ApplyPropertyValue(Control.FontWeightProperty       , weight                                        ); } catch { throw new FontWeightPropertyException();   };
            index++;
        }
    }

    /// <summary>
    /// Save text to <see cref="MemoryStream"/>
    /// </summary>
    /// <param name="format">Input string?</param>
    /// <returns><see cref="MemoryStream"/></returns>
    public void SaveText(in MemoryStream stream)
    {
        FlowDocument doc = UserRichTextBox.Document;
        TextRange range = new(doc.ContentStart, doc.ContentEnd);

        range.Save(stream, DataFormats.Xaml);
        stream.Flush();
        stream.Seek(0, SeekOrigin.Begin);
    }

    /// <summary>Load text</summary>
    public void LoadText(in MemoryStream stream)
    {
        FlowDocument doc = new();
        new TextRange(doc.ContentStart, doc.ContentEnd).Load(stream, DataFormats.Xaml);

        UserRichTextBox.Document = doc;
    }

    ///<inheritdoc cref="Break(string)"/>
    public void Break() => Break("White");

    /// <summary>
    /// Add line "==============================================="
    /// </summary>
    /// <param name="color">color</param>
    public void Break(string color)
    {
        TextRange tr = new(UserRichTextBox.Document.ContentEnd, UserRichTextBox.Document.ContentEnd) { Text = "===============================================\r" };
        tr.ApplyPropertyValue(TextElement.ForegroundProperty, new BrushConverter().ConvertFromString(color));
        //tr.ApplyPropertyValue(Control.FontSizeProperty, size);
    }

    /// <summary>
    /// Scroll To End alternative
    /// </summary>
    public void ScrollEndEvent(object s, EventArgs e)
    {
        if (!UserRichTextBox.IsInitialized) return;
        UserRichTextBox.ScrollToEnd();
    }
}
