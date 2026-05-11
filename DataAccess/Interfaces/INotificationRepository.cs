using NotificationAppDataAccessLibrary.Interfaces;
using NotificationAppModelLibrary;

//interfcae for notification repo additional repo other tha IRepo
public interface INotificationRepository : IRepository<int, Notification>
{
    public List<Notification> GetNotificationByUserId(int userId);
    public List<Notification> GetNotificationsByUserIdAndService(int userId, string service);
    public List<Notification> GetNotificationsByService(string service);
}