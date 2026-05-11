using NotificationAppModelLibrary;

namespace NotificationAppDataAccessLibrary.Repositories;

public class NotificationRepository : AbstractRepository<int,Notification>,INotificationRepository
{
    static int notificationId = 0;
    public override Notification Create(Notification item)
    {
        //return notifiction class
        item.notificationId = ++notificationId;
        items.Add(notificationId,item);
        return item;
    }
    public List<Notification> GetNotificationByUserId(int userId)
    {
        //return empty list
        return items.Values.Where(x => x.userId == userId).ToList();
    }
    public List<Notification> GetNotificationsByUserIdAndService(int userId,string service)
    {
        //return empty list
        return items.Values.Where(x=>x.userId == userId && x.service == service).ToList();
    }
    public List<Notification> GetNotificationsByService(string service)
    {
        //return empty list
        return items.Values.Where(x=>x.service == service).ToList();
    }
}