using NotificationAppBuisnessLayerLibrary.Interfaces;
using NotificationAppModelLibrary;
using NotificationAppBuisnessLayerLibrary.Validation;
using NotificationAppBuisnessLayerLibrary.Delegates;

namespace NotificationAppBuisnessLayerLibrary.Services;

public abstract class NotificationSenderService : INotificationSender
{
    protected string message = "";
    protected User user = null!;
    protected string service = "";
    protected string status = "";
    protected DateTime? dateTime;
    NotificationOperation? notificationOperation;
    private readonly INotificationRepository notificationRepo;
    public NotificationSenderService(INotificationRepository _notificationRepo)
    {
        notificationRepo = _notificationRepo;
    }

    public abstract void SendNotification();
    public abstract void LogNotification();
    public void Send(string message, User user, string service)
    {
        this.message = message;
        this.user = user;
        this.service = service;

        // Clear old delegates
        notificationOperation = null;

        notificationOperation += ValidationOfMessage;
        notificationOperation += SendNotification;
        notificationOperation += SaveNotification;
        notificationOperation += LogNotification;

        notificationOperation?.Invoke();
    }
    public void ValidationOfMessage()
    {
        MessageValidation.ValidateMessage(message, service);
    }

    //save the notification only after sending the notification
    //to store even if status is not sent
    public void SaveNotification()
    {
        Notification notification = new Notification
        {
            userId = user.userId,
            message = message,
            service = service,
            status = status,
            datetime = DateTime.Now
        };

        notificationRepo.Create(notification);
    }
}