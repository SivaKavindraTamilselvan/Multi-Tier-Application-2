namespace NotificationAppPresentationLayer.Application;

public class UserChoices
{
    public void DisplayUserChoices()
    {
        Console.WriteLine("------------------------------------------------");
        Console.WriteLine("Enter 1 To Disply User Email Notification");
        Console.WriteLine("Enter 2 To Deliver User SMS Notification");
        Console.WriteLine("Enter 3 To Deliver User All Notifications");
        
        Console.WriteLine("Enter 0 To Quit The Loop");
        Console.WriteLine("------------------------------------------------");
    }
}