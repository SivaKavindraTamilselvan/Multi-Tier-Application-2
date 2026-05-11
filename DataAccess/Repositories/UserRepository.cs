using NotificationAppModelLibrary;
using Npgsql;
namespace NotificationAppDataAccessLibrary.Repositories;

public class UserRepository : AbstractRepository<int, User>,IUserRepository
{
    static int userId = 0;
    //override the create function
    public override User Create(User user)
    {
        NpgsqlConnection connection = dataConnection.GetConnection();
        user.userId = ++userId;
        string query = $"INSERT INTO Users(Name,PhoneNumber,Email) VALUES('{user.Name}','{user.PhoneNumber}','{user.Email}') RETURNING *";

        NpgsqlCommand command = new NpgsqlCommand(query, connection);

        try
        {
            connection.Open();
            NpgsqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                User createdUser = new User();
                createdUser.userId = Convert.ToInt32(reader["userId"]);
                createdUser.Email = reader["Email"].ToString() ?? "";
                createdUser.PhoneNumber = reader["PhoneNumber"].ToString() ?? "";
                createdUser.Name = reader["Name"].ToString() ?? "";
                Console.WriteLine("User created Successfully");
                return createdUser;
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

        //items.Add(userId,user);
        return null!;
    }

    public User? DeleteUserByEmail(string email)
    {
        NpgsqlConnection connection = dataConnection.GetConnection();
        string query = $"DELETE From User WHERE Email = {email} RETURNING *";

        NpgsqlCommand command = new NpgsqlCommand(query, connection);

        try
        {
            connection.Open();
            int result = command.ExecuteNonQuery();
            if (result > 0)
            {
                Console.WriteLine("User Deleted Successfully");
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

        //items.Add(userId,user);

        return null;
    }

    public User? DeleteByEmail(string email)
    {

        NpgsqlConnection connection = dataConnection.GetConnection();

        string query = $"DELETE FROM Users WHERE Email = {email} RETURNING *";

        NpgsqlCommand command = new NpgsqlCommand(query, connection);

        try
        {
            connection.Open();
            NpgsqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                User item = new User();
                foreach (var prop in typeof(User).GetProperties())
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

        /*
        //return null
        if (items.TryGetValue(key, out T? item))
        {
            items.Remove(key);
            return item;
        }
        return null;
        */

        return null!;
    }
    public List<User> DeleteByPhoneNumber(string PhoneNumber)
    {
        List<User> list = new List<User>();

        NpgsqlConnection connection = dataConnection.GetConnection();

        string query = $"DELETE FROM Users WHERE PhoneNumber = {PhoneNumber} RETURNING *";

        NpgsqlCommand command = new NpgsqlCommand(query, connection);

        try
        {
            connection.Open();
            NpgsqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                User item = new User();
                foreach (var prop in typeof(User).GetProperties())
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

        /*
        //return null
        if (items.TryGetValue(key, out T? item))
        {
            items.Remove(key);
            return item;
        }
        return null;
        */

        return null!;
    }
}