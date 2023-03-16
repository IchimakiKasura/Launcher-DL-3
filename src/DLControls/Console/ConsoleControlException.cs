namespace DLControls;

public class ForegroundPropertyException : Exception
{
    public ForegroundPropertyException()
        : base("The Entered Color or Hex are Invalid.") { }
}

public class FontSizePropertyException : Exception
{
    public FontSizePropertyException()
        : base("The Entered font size are Invalid.") { }
}
public class FontWeightPropertyException : Exception
{
    public FontWeightPropertyException()
        : base("The Entered font weight are Invalid.") { }
}
public class TextPropertyException : Exception
{
    public TextPropertyException()
        : base("Entered text are invalid.") { }
}