using NotificationAppDataAccessLibrary.Interfaces;
using NotificationAppDataAccessLibrary.DBContext;
using Npgsql;

namespace NotificationAppDataAccessLibrary.Repositories;

public abstract class AbstractRepository<K, T> : IRepository<K, T> where T : class, new() where K : notnull
{
    protected Dictionary<K, T> items = new();
    public abstract T Create(T item);

    protected readonly DataConnection dataConnection = new();
    public T? Get(K key)
    {
        string tableName = typeof(T).Name;
        string id = tableName.ToLower() + "Id";
        NpgsqlConnection connection = dataConnection.GetConnection();

        try
        {

            string query = $"SELECT * FROM {tableName + "s"} Where {id} = {key}";
            NpgsqlCommand command = new NpgsqlCommand(query, connection);

            connection.Open();
            NpgsqlDataReader reader = command.ExecuteReader();

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
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            connection.Close();
        }

        return null;
        //return null if not present
        //return items.Where(x=>x.Key.Equals(key)).Select(x=>x.Value).FirstOrDefault();
    }

    public List<T> GetAll()
    {
        string tableName = typeof(T).Name;
        NpgsqlConnection connection = dataConnection.GetConnection();
        List<T> list = new List<T>();

        try
        {
            string query = $"SELECT * FROM {tableName + "s"}";
            NpgsqlCommand command = new NpgsqlCommand(query, connection);
            connection.Open();

            NpgsqlDataReader reader = command.ExecuteReader();


            while (reader.Read())
            {
                T item = new T();
                foreach (var prop in typeof(T).GetProperties())
                {
                    prop.SetValue(item, reader[prop.Name]);
                }
                list.Add(item);
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

        return list;
        //return empty list
        //return items.Values.ToList();
    }

    public T? Update(K key, T item)
    {
        string tableName = typeof(T).Name;
        string id = tableName.ToLower() + "Id";
        NpgsqlConnection connection = dataConnection.GetConnection();

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
            connection.Open();
            NpgsqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                T updatedItem = new T();
                foreach(var prop in typeof(T).GetProperties())
                {
                    prop.SetValue(updatedItem,reader[prop.Name]);
                }
                Console.WriteLine("User Updated Successfully");
                return updatedItem;
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
        /*
        //return null
        if (!items.Any(x => x.Key.Equals(key)))
        {
            return null;
        }

        items[key] = item;
        return item;
        */
        return null;
    }

    public T? Delete(K key)
    {
        //return null
        if (items.TryGetValue(key, out T? item))
        {
            items.Remove(key);
            return item;
        }
        return null;
    }
}