using NotificationAppDataAccessLibrary.Interfaces;
using NotificationAppDataAccessLibrary.DBContext;
using Npgsql;

namespace NotificationAppDataAccessLibrary.Repositories;

public abstract class AbstractRepository<K, T> : IRepository<K, T> where T : class, new() where K : notnull
{
    public abstract T Create(T item);
    protected readonly DataConnection dataConnection = new();
    // Get the details of the tables by id
    public T? Get(K key)
    {
        string tableName = typeof(T).Name;
        string id = tableName.ToLower() + "Id";
        //open the connection
        NpgsqlConnection connection = dataConnection.GetConnection();
        try
        {
            string query = $"SELECT * FROM {tableName + "s"} Where {id} = {key}";
            if (tableName == "Notification")
            {
                query = $"select n.notificationId,n.userId,u.Name,n.userEmail,u.PhoneNumber,n.message,n.service,n.status,n.datetime from Notifications n join Users u on u.userId = n.userId";
            }
            //command for the query
            NpgsqlCommand command = new NpgsqlCommand(query, connection);
            //connection is open the connection
            connection.Open();
            //the reader execute the sql query
            NpgsqlDataReader reader = command.ExecuteReader();
            //access the database content
            if (reader.Read())
            {
                T item = new T();
                //for loop to store the object values that is returned
                foreach (var prop in typeof(T).GetProperties())
                {
                    prop.SetValue(item, reader[prop.Name]);
                }
                return item;
            }
        }
        //catch any of the exception including the sql query failures
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        //close the connection
        finally
        {
            connection.Close();
        }
        return null;
    }

    public List<T> GetAll()
    {
        string tableName = typeof(T).Name;
        //open the connection
        NpgsqlConnection connection = dataConnection.GetConnection();
        List<T> list = new List<T>();
        try
        {
            string query = $"SELECT * FROM {tableName + "s"}";
            if (tableName == "Notification")
            {
                query = $"select n.notificationId,n.userId,u.Name,n.userEmail,u.PhoneNumber,n.message,n.service,n.status,n.datetime from Notifications n join Users u on u.userId = n.userId";
            }
            //command for the query
            NpgsqlCommand command = new NpgsqlCommand(query, connection);
            //connection is open the connection
            connection.Open();
            //the reader execute the sql query
            NpgsqlDataReader reader = command.ExecuteReader();
            //access the database content
            while (reader.Read())
            {
                T item = new T();
                //for loop to store the object values that is returned
                foreach (var prop in typeof(T).GetProperties())
                {
                    prop.SetValue(item, reader[prop.Name]);
                }
                list.Add(item);
            }

        }
        //catch any of the exception including the sql query failures
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        //close the connection
        finally
        {
            connection.Close();
        }
        return list;
    }

    public T? Update(K key, T item)
    {
        string tableName = typeof(T).Name;
        string id = tableName.ToLower() + "Id";
        //open the connection
        NpgsqlConnection connection = dataConnection.GetConnection();
        //command for the query
        string query = $"UPDATE {tableName + "s"} SET ";
        string set = "";
        foreach (var prop in typeof(T).GetProperties())
        {
            set = set + $"{prop.Name} = '{prop.GetValue(item)}' ,";
        }
        set = set.TrimEnd(',');
        query = query + set + $"WHERE {id} = {key} RETURNING *";

        NpgsqlCommand command = new NpgsqlCommand(query, connection);
        try
        {
            //connection is open the connection
            connection.Open();
            //the reader execute the sql query
            NpgsqlDataReader reader = command.ExecuteReader();
            //access the database content
            if (reader.Read())
            {
                T updatedItem = new T();
                //for loop to store the object values that is returned
                foreach (var prop in typeof(T).GetProperties())
                {
                    prop.SetValue(updatedItem, reader[prop.Name]);
                }
                Console.WriteLine("User Updated Successfully");
                return updatedItem;
            }
        }
        //catch any of the exception including the sql query failures
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        //close the connection
        finally
        {
            connection.Close();
        }
        return null;
    }

    public T? Delete(K key)
    {
        string tableName = typeof(T).Name;
        string id = tableName.ToLower() + "Id";
        //open the connection
        NpgsqlConnection connection = dataConnection.GetConnection();
        string query = $"DELETE FROM {tableName + "s"} WHERE {id} = {key} RETURNING *";
        //command for the query
        NpgsqlCommand command = new NpgsqlCommand(query, connection);
        try
        {
            //connection is open the connection
            connection.Open();
            //the reader execute the sql query
            NpgsqlDataReader reader = command.ExecuteReader();
            //access the database content
            if (reader.Read())
            {
                T item = new T();
                foreach (var prop in typeof(T).GetProperties())
                {
                    prop.SetValue(item, reader[prop.Name]);
                }
                return item;
            }
        }
        //catch any of the exception including the sql query failures
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        //close the connection
        finally
        {
            connection.Close();
        }
        return null!;
    }
}