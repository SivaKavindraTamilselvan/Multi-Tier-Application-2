using NotificationAppModelLibrary.Exceptions;

namespace NotificationAppPresentationLayer.Application;

public partial class AdminSendNotificationRole
{
    public void DeliverNotificationByEmail()
    {
        Console.WriteLine("Enter The Email To Send the Message");
        string email = inputCheck.EmailInputs();
        var user = userService.GetUserByEmail(email);
        if (user == null)
        {
            throw new UserNotFoundException();
        }
        string message = inputCheck.MessageInputs(email, "Email");
        notificationService.SendNotificationToUsers(message, user, "Email");
    }
    public void DeliverNotificationByPhoneNumber()
    {
        Console.WriteLine("Enter The Phone Number To Send the Message");
        string phone = inputCheck.PhoneNumberInputs();
        var user = userService.GetUserByPhoneNumber(phone);
        if (user == null)
        {
            throw new UserNotFoundException();
        }
        string message = inputCheck.MessageInputs(phone, "SMS");
        notificationService.SendNotificationToUsers(message, user, "SMS");
    }
}