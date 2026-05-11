namespace NotificationAppPresentationLayer.Application;

public class AdminChoices
{
    public void DisplayAdminChoices()
    {
        Console.WriteLine("------------------------------------------------");
        Console.WriteLine("Enter 1 To Add The User");
        Console.WriteLine("Enter 2 To Get The User");
        Console.WriteLine("Enter 3 To Update The User");
        Console.WriteLine("Enter 4 To Delete The User");
        Console.WriteLine("Enter 5 To Deliver The Notification User");
        Console.WriteLine("Enter 6 To Get The Notification");
        Console.WriteLine("Enter 0 To Quit The Loop");
        Console.WriteLine("------------------------------------------------");
    }
    public void DisplayGetAdminChoices()
    {
        Console.WriteLine("------------------------------------------------");
        Console.WriteLine("Enter 1 To Get User By Id");
        Console.WriteLine("Enter 2 To Get The User By Email");
        Console.WriteLine("Enter 3 To Get The User By PhoneNumber");
        Console.WriteLine("Enter 4 To Display All The Users");
        Console.WriteLine("Enter 0 To Quit The Loop");
        Console.WriteLine("------------------------------------------------");
    }
    public void DisplayAdminNotificationChoices()
    {
        Console.WriteLine("------------------------------------------------");
        Console.WriteLine("Enter 1 To Display The Notification By Id");
        Console.WriteLine("Enter 2 To Display The Notification By User Id");
        Console.WriteLine("Enter 3 To Display All The Notification");
        Console.WriteLine("Enter 0 To Quit The Loop");
        Console.WriteLine("------------------------------------------------");
    }
    public void DisplayAdminDeliverMessageChoices()
    {
        Console.WriteLine("------------------------------------------------");
        Console.WriteLine("Enter 1 To Deliver The Message To A User By Email");
        Console.WriteLine("Enter 2 To Deliver The Message To A User By Phone Number");
        Console.WriteLine("Enter 0 To Quit The Loop");
        Console.WriteLine("------------------------------------------------");
    }
    public void DisplayDeleteAdminChoices()
    {
        Console.WriteLine("------------------------------------------------");
        Console.WriteLine("Enter 1 To Delete User By Id");
        Console.WriteLine("Enter 2 To Delete The User By Email");
        Console.WriteLine("Enter 3 To Delete The User By PhoneNumber");
        Console.WriteLine("Enter 0 To Quit The Loop");
        Console.WriteLine("------------------------------------------------");
    }
}