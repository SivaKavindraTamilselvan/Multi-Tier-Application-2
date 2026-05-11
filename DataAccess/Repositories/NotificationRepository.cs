using NotificationAppModelLibrary;
using Npgsql;

namespace NotificationAppDataAccessLibrary.Repositories;

public class NotificationRepository : AbstractRepository<int, Notification>, INotificationRepository
{
    //static int notificationId = 0;
    public override Notification Create(Notification item)
    {
        NpgsqlConnection connection = dataConnection.GetConnection();
        DateTime dateTime = item.datetime ?? DateTime.Now;

        string query = $"INSERT INTO Notifications(userId,userEmail,service,status,message,datetime) VALUES({item.userId},'{item.userEmail}','{item.service}','{item.status}','{item.message}','{dateTime:yyyy-MM-dd HH:mm:ss}') RETURNING *";

        NpgsqlCommand command = new NpgsqlCommand(query, connection);

        try
        {
            connection.Open();
            NpgsqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                Notification notification = new Notification();
                notification.message = reader["message"].ToString() ?? "";
                notification.datetime = reader["datetime"] as DateTime?;
                notification.notificationId = Convert.ToInt32(reader["notificationId"]);
                notification.userId = Convert.ToInt32(reader["userId"]);
                notification.userEmail = reader["userEmail"].ToString() ?? "";
                notification.service = reader["service"].ToString() ?? "";
                notification.status = reader["status"].ToString() ?? "";
                Console.WriteLine("Notification created Successfully");
                return notification;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            connection.Close();
        }

        return null!;
        /*
        //return notifiction class
        item.notificationId = ++notificationId;
        items.Add(notificationId, item);
        return item;
        */
    }
    public List<Notification> GetNotificationByUserId(int userId)
    {
        NpgsqlConnection connection = dataConnection.GetConnection();

        string query = $"SELECT * FROM Notifications WHERE userId = {userId}";
        NpgsqlCommand command = new NpgsqlCommand(query, connection);
        List<Notification> notifications = new List<Notification>();

        try
        {
            connection.Open();
            NpgsqlDataReader reader = command.ExecuteReader();
            while(reader.Read())
            {
                Notification notification = new Notification();
                notification.message = reader["message"].ToString() ?? "";
                notification.datetime = reader["datetime"] as DateTime?;
                notification.notificationId = Convert.ToInt32(reader["notificationId"]);
                notification.userId = Convert.ToInt32(reader["userId"]);
                notification.userEmail = reader["userEmail"].ToString() ?? "";
                notification.service = reader["service"].ToString() ?? "";
                notification.status = reader["status"].ToString() ?? "";
                notifications.Add(notification);
            }
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            connection.Close();
        }

        return notifications;
        //return empty list
        //return items.Values.Where(x => x.userId == userId).ToList();
    }
    public List<Notification> GetNotificationsByUserIdAndService(int userId, string service)
    {
        NpgsqlConnection connection = dataConnection.GetConnection();

        string query = $"SELECT * FROM Notifications WHERE userId = {userId} AND service = '{service}'";

        NpgsqlCommand command = new NpgsqlCommand(query,connection);
        List<Notification> notifications = new List<Notification>();

        try
        {
            connection.Open();
            NpgsqlDataReader reader = command.ExecuteReader();
            while(reader.Read())
            {
                Notification notification = new Notification();
                notification.message = reader["message"].ToString() ?? "";
                notification.datetime = reader["datetime"] as DateTime?;
                notification.notificationId = Convert.ToInt32(reader["notificationId"]);
                notification.userId = Convert.ToInt32(reader["userId"]);
                notification.userEmail = reader["userEmail"].ToString() ?? "";
                notification.service = reader["service"].ToString() ?? "";
                notification.status = reader["status"].ToString() ?? "";
                notifications.Add(notification);
            }

        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            connection.Close();
        }

        return notifications;
        //return empty list
        //return items.Values.Where(x => x.userId == userId && x.service == service).ToList();
    }
    public List<Notification> GetNotificationsByService(string service)
    {
        NpgsqlConnection connection = dataConnection.GetConnection();

        string query = $"SELECT * FROM Notifications WHERE service = '{service}'";

        NpgsqlCommand command = new NpgsqlCommand(query,connection);
        List<Notification> notifications = new List<Notification>();

        try
        {
            connection.Open();
            NpgsqlDataReader reader = command.ExecuteReader();
            while(reader.Read())
            {
                Notification notification = new Notification();
                notification.message = reader["message"].ToString() ?? "";
                notification.datetime = reader["datetime"] as DateTime?;
                notification.notificationId = Convert.ToInt32(reader["notificationId"]);
                notification.userId = Convert.ToInt32(reader["userId"]);
                notification.userEmail = reader["userEmail"].ToString() ?? "";
                notification.service = reader["service"].ToString() ?? "";
                notification.status = reader["status"].ToString() ?? "";
                notifications.Add(notification);
            }

        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            connection.Close();
        }

        return notifications;

        //return empty list
        //return items.Values.Where(x => x.service == service).ToList();
    }
}