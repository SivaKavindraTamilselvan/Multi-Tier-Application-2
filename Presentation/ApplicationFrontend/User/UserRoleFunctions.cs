using NotificationAppBuisnessLayerLibrary.Interfaces;
using NotificationAppBuisnessLayer.Inputs;
using NotificationAppModelLibrary.Exceptions;

namespace NotificationAppPresentationLayer.Application;

public partial class UserRole
{
    public void GetNotificationsByUserId()
    {
        int userid = inputCheck.IdInputs();
        notificationService.GetNotificationsByUserId(userid);
    }
    public void GetNotificationsByUserIdAndService(string service)
    {
        int userid = inputCheck.IdInputs();
        notificationService.GetNotificationsByUserIdAndService(userid, service);
    }

}