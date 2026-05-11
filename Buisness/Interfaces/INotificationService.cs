using NotificationAppModelLibrary;
namespace NotificationAppBuisnessLayerLibrary.Interfaces;

// notification service interface
public interface INotificationService
{
    public Notification? GetNotificationsById(int id);
    public void PrintAllNotification();
    public void GetNotificationsByUserId(int id);
    public void SendNotificationToUsers(string message,User user,string service);
    public void GetNotificationsByUserIdAndService(int userId,string service);
    public void GetNotificationsByService(string service);
}