using NotificationAppBuisnessLayerLibrary.Interfaces;
using NotificationAppModelLibrary;
using NotificationAppModelLibrary.Exceptions;

namespace NotificationAppBuisnessLayerLibrary.Services;

public partial class NotificationService : INotificationService
{
    private readonly INotificationRepository notificationRepo;
    private readonly INotificationSender email;
    private readonly INotificationSender sms;
    public NotificationService(INotificationRepository _notificationRepo, INotificationSender _email, INotificationSender _sms)
    {
        notificationRepo = _notificationRepo;
        email = _email;
        sms = _sms;
    }

    //send notification by checking the type of service and send
    public void SendNotificationToUsers(string message, User user, string service)
    {
        if (service == "Email")
        {
            Console.WriteLine("Wait Untill the Email Notification is Sent");
            email.Send(message, user, service);
        }
        else if (service == "SMS")
        {
            Console.WriteLine("Wait Untill the SMS Notification is Sent");
            sms.Send(message, user, service);
        }
        else
        {
            Console.WriteLine("No Valid Service method entered");
        }
    }

    // list all the notification
    // the notification include creation,deletion,updation
    public void PrintAllNotification()
    {
        var notificationList = notificationRepo.GetAll();

        if (notificationList.Count == 0)
        {
            throw new NotificationNotFoundException();
        }

        foreach (var item in notificationList)
        {
            Console.WriteLine(item);
            Console.WriteLine();
        }
    }
}