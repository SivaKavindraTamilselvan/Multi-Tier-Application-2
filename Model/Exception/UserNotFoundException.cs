namespace NotificationAppModelLibrary.Exceptions;

public class UserNotFoundException : Exception
{
    private static string message = "No User Is Found In The list";
    public UserNotFoundException() : base(message)
    {
        
    }
}