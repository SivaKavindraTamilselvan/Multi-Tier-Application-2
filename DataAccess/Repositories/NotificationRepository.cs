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
                int id = Convert.ToInt32(reader["notificationId"]);
                Notification? notification = Get(id);
                return notification!;
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
    }
    public List<Notification> GetNotificationByUserId(int userId)
    {
        NpgsqlConnection connection = dataConnection.GetConnection();

        string query = $"select n.notificationId,n.userId,u.Name,n.userEmail,u.PhoneNumber,n.message,n.service,n.status,n.datetime from Notifications n join Users u on u.userId = n.userId WHERE n.userId = {userId}";
        NpgsqlCommand command = new NpgsqlCommand(query, connection);
        List<Notification> notifications = new List<Notification>();

        try
        {
            connection.Open();
            NpgsqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Notification notification = new Notification();
                notification.message = reader["message"].ToString() ?? "";
                notification.datetime = reader["datetime"] as DateTime?;
                notification.notificationId = Convert.ToInt32(reader["notificationId"]);
                notification.userId = Convert.ToInt32(reader["userId"]);
                notification.userEmail = reader["userEmail"].ToString() ?? "";
                notification.PhoneNumber = reader["PhoneNumber"].ToString() ?? "";
                notification.Name = reader["Name"].ToString() ?? "";
                notification.service = reader["service"].ToString() ?? "";
                notification.status = reader["status"].ToString() ?? "";
                notifications.Add(notification);
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

        return notifications;
    }
    public List<Notification> GetNotificationsByUserIdAndService(int userId, string service)
    {
        NpgsqlConnection connection = dataConnection.GetConnection();

        string query = $"select n.notificationId,n.userId,u.Name,n.userEmail,u.PhoneNumber,n.message,n.service,n.status,n.datetime from Notifications n join Users u on u.userId = n.userId WHERE userId = {userId} AND service = '{service}'";

        NpgsqlCommand command = new NpgsqlCommand(query, connection);
        List<Notification> notifications = new List<Notification>();

        try
        {
            connection.Open();
            NpgsqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Notification notification = new Notification();
                notification.message = reader["message"].ToString() ?? "";
                notification.datetime = reader["datetime"] as DateTime?;
                notification.notificationId = Convert.ToInt32(reader["notificationId"]);
                notification.userId = Convert.ToInt32(reader["userId"]);
                notification.userEmail = reader["userEmail"].ToString() ?? "";
                notification.PhoneNumber = reader["PhoneNumber"].ToString() ?? "";
                notification.Name = reader["Name"].ToString() ?? "";
                notification.service = reader["service"].ToString() ?? "";
                notification.status = reader["status"].ToString() ?? "";
                notifications.Add(notification);
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

        return notifications;
    }
    public List<Notification> GetNotificationsByService(string service)
    {
        NpgsqlConnection connection = dataConnection.GetConnection();

        string query = $"select n.notificationId,n.userId,u.Name,n.userEmail,u.PhoneNumber,n.message,n.service,n.status,n.datetime from Notifications n join Users u on u.userId = n.userId WHERE service = '{service}'";

        NpgsqlCommand command = new NpgsqlCommand(query, connection);
        List<Notification> notifications = new List<Notification>();

        try
        {
            connection.Open();
            NpgsqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Notification notification = new Notification();
                notification.message = reader["message"].ToString() ?? "";
                notification.datetime = reader["datetime"] as DateTime?;
                notification.notificationId = Convert.ToInt32(reader["notificationId"]);
                notification.userId = Convert.ToInt32(reader["userId"]);
                notification.userEmail = reader["userEmail"].ToString() ?? "";
                notification.PhoneNumber = reader["PhoneNumber"].ToString() ?? "";
                notification.Name = reader["Name"].ToString() ?? "";
                notification.service = reader["service"].ToString() ?? "";
                notification.status = reader["status"].ToString() ?? "";
                notifications.Add(notification);
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

        return notifications;
    }
}