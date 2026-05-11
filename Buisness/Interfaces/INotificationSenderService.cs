using NotificationAppModelLibrary;
namespace NotificationAppBuisnessLayerLibrary.Interfaces;

public interface INotificationSender
{
    //Send notification common for SMS and Email
    public void Send(string message,User user,string service);
}