using NotificationAppBuisnessLayerLibrary.Interfaces;
using NotificationAppBuisnessLayer.Inputs;
using NotificationAppModelLibrary.Exceptions;

namespace NotificationAppPresentationLayer.Application;

public partial class AdminGetNotificationRole
{
    public void GetNotificationsById()
    {
        int notificationId = inputCheck.IdInputs();
        var notification = notificationService.GetNotificationsById(notificationId);
        if (notification == null)
        {
            throw new NotificationNotFoundException();
        }
        Console.WriteLine(notification);
    }
    public void GetNotificationsByUserId()
    {
        int userid = inputCheck.IdInputs();
        notificationService.GetNotificationsByUserId(userid);
    }
    public void GetAllNotification()
    {
        notificationService.PrintAllNotification();
    }
}