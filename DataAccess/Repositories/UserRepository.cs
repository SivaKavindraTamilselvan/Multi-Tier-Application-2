using NotificationAppModelLibrary;
using Npgsql;
namespace NotificationAppDataAccessLibrary.Repositories;

public class UserRepository : AbstractRepository<int, User>, IUserRepository
{
    //override the create function
    public override User Create(User user)
    {
        //connection is created
        NpgsqlConnection connection = dataConnection.GetConnection();
        string query = $"INSERT INTO Users(Name,PhoneNumber,Email) VALUES('{user.Name}','{user.PhoneNumber}','{user.Email}') RETURNING *";
        //command is created
        NpgsqlCommand command = new NpgsqlCommand(query, connection);

        try
        {
            //connection is opened
            connection.Open();
            //the reader execute the sql query
            NpgsqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                //new object is created
                User createdUser = new User();
                createdUser.userId = Convert.ToInt32(reader["userId"]);
                createdUser.Email = reader["Email"].ToString() ?? "";
                createdUser.PhoneNumber = reader["PhoneNumber"].ToString() ?? "";
                createdUser.Name = reader["Name"].ToString() ?? "";
                Console.WriteLine("User created Successfully");
                return createdUser;
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

    public User? DeleteUserByEmail(string email)
    {
        //connection is created
        NpgsqlConnection connection = dataConnection.GetConnection();
        //delete query created
        string query = $"DELETE From User WHERE Email = '{email}' RETURNING *";
        //command is created
        NpgsqlCommand command = new NpgsqlCommand(query, connection);

        try
        {
            //connection is opened
            connection.Open();
            int result = command.ExecuteNonQuery();
            //if deleted then returns a user
            if (result > 0)
            {
                Console.WriteLine("User Deleted Successfully");
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

    public User? DeleteByEmail(string email)
    {
        //connection is created
        NpgsqlConnection connection = dataConnection.GetConnection();
        //delete query created by email
        string query = $"DELETE FROM Users WHERE Email = '{email}' RETURNING *";
        //command is created
        NpgsqlCommand command = new NpgsqlCommand(query, connection);

        try
        {
            connection.Open();
            //the reader execute the sql query
            NpgsqlDataReader reader = command.ExecuteReader();
            //access the database content
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
    public List<User> DeleteByPhoneNumber(string PhoneNumber)
    {
        List<User> list = new List<User>();
        //connection is created
        NpgsqlConnection connection = dataConnection.GetConnection();
        //delete query created by phone number
        string query = $"DELETE FROM Users WHERE PhoneNumber = '{PhoneNumber}' RETURNING *";
        //command is created
        NpgsqlCommand command = new NpgsqlCommand(query, connection);

        try
        {
            connection.Open();
            //the reader execute the sql query
            NpgsqlDataReader reader = command.ExecuteReader();
            //access the database content
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
}