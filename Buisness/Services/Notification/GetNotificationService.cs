using NotificationAppBuisnessLayerLibrary.Interfaces;
using NotificationAppModelLibrary;
using NotificationAppModelLibrary.Exceptions;

namespace NotificationAppBuisnessLayerLibrary.Services;

public partial class NotificationService : INotificationService
{
    //get notification by notification id
    // the notification include creation,deletion,updation
    public Notification? GetNotificationsById(int id)
    {
        //call data access layer
        return notificationRepo.Get(id);
    }

    //get all list of notification by user id
    // the notification include creation,deletion,updation
    public void GetNotificationsByUserId(int id)
    {
        //call data access layer
        var notification = notificationRepo.GetNotificationByUserId(id);
        if (notification.Count == 0)
        {
            throw new NotificationNotFoundException();
        }
        foreach (var item in notification)
        {
            Console.WriteLine("Notification Information");
            Console.WriteLine(item);
            Console.WriteLine();
        }
    }

    //get all list of notification by user id and service
    // the notification include creation,deletion,updation
    public void GetNotificationsByUserIdAndService(int userId, string service)
    {
        //call data access layer
        var notification = notificationRepo.GetNotificationsByUserIdAndService(userId, service);
        if (notification.Count == 0)
        {
            throw new NotificationNotFoundException();
        }
        foreach (var item in notification)
        {
            Console.WriteLine("Notification Information");
            Console.WriteLine(item);
            Console.WriteLine();
        }
    }

    //get all list of notification by service
    // the notification include creation,deletion,updation
    public void GetNotificationsByService(string service)
    {
        //call data access layer
        var notification = notificationRepo.GetNotificationsByService(service);
        if (notification.Count == 0)
        {
            throw new NotificationNotFoundException();
        }
        foreach (var item in notification)
        {
            Console.WriteLine("Notification Information");
            Console.WriteLine(item);
            Console.WriteLine();
        }
    }
}