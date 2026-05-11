using NotificationAppDataAccessLibrary.Interfaces;
using NotificationAppDataAccessLibrary.DBContext;
using Npgsql;

namespace NotificationAppDataAccessLibrary.Repositories;

public abstract class AbstractRepository<K,T> : IRepository<K,T> where T : class,new() where K : notnull
{
    protected Dictionary<K,T> items = new();
    public abstract T Create(T item);

    protected readonly DataConnection dataConnection = new();
    public T? Get(K key)
    {
        string tableName = typeof(T).Name;
        string id = tableName.ToLower() + "Id";

        try
        {
            NpgsqlConnection connection = dataConnection.GetConnection();
            string query = $"SELECT * FROM {tableName+"s"} Where {id} = {key}";
            NpgsqlCommand command = new NpgsqlCommand(query,connection);

            connection.Open();
            NpgsqlDataReader reader = command.ExecuteReader();
            
            if(reader.Read())
            {
                T item = new T();
                foreach(var prop in typeof(T).GetProperties())
                {
                    prop.SetValue(item,reader[prop.Name]);
                }
                return item;
            }
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        //return null if not present
        //return items.Where(x=>x.Key.Equals(key)).Select(x=>x.Value).FirstOrDefault();
    }

    public List<T> GetAll()
    {
        //return empty list
        return items.Values.ToList();
    }

    public T? Update(K key,T item)
    {
        //return null
        if(!items.Any(x => x.Key.Equals(key)))
        {
            return null;
        }

        items[key] = item;
        return item;
    }

    public T? Delete(K key)
    {
        //return null
        if(items.TryGetValue(key, out T? item))
        {
            items.Remove(key);
            return item;
        }
        return null;
    }
} 