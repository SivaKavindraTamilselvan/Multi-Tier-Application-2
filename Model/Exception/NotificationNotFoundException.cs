namespace NotificationAppModelLibrary.Exceptions;
public class NotificationNotFoundException : Exception
{
    private static string message = "No Notification Is Found In The List";
    public NotificationNotFoundException() : base(message)
    {
        
    }
}