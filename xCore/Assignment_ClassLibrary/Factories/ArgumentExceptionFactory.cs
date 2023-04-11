namespace Assignment_ClassLibrary.Factories;

public class ArgumentExceptionFactory
{
    public static ArgumentException Create(string message)
    {
        return new ArgumentException(message);
    }
}
