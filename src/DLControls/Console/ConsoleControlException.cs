namespace DLControls;

public class ForegroundPropertyException : Exception
{
    public ForegroundPropertyException() { }
    public ForegroundPropertyException(string message)
        : base(message) { }
}

public class FontSizePropertyException : Exception
{
    public FontSizePropertyException() { }
    public FontSizePropertyException(string message)
        : base(message) { }
}
public class FontWeightPropertyException : Exception
{
    public FontWeightPropertyException() { }
    public FontWeightPropertyException(string message)
        : base(message) { }
}
