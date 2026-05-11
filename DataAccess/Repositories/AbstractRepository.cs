using NotificationAppDataAccessLibrary.Interfaces;
namespace NotificationAppDataAccessLibrary.Repositories;

public abstract class AbstractRepository<K,T> : IRepository<K,T> where T : class where K : notnull
{
    protected Dictionary<K,T> items = new();
    public abstract T Create(T item);

    public T? Get(K key)
    {
        //return null if not present
        return items.Where(x=>x.Key.Equals(key)).Select(x=>x.Value).FirstOrDefault();
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