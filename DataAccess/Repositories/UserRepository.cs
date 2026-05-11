using NotificationAppModelLibrary;
using Npgsql;
namespace NotificationAppDataAccessLibrary.Repositories;

public class UserRepository : AbstractRepository<int,User>
{
    static int userId = 0;
    //override the create function
    public override User Create(User user)
    {
        NpgsqlConnection connection = dataConnection.GetConnection();
        user.userId = ++userId;
        string query = $"INSERT INTO Users(Name,PhoneNumber,Email) VALUES('{user.Name}','{user.PhoneNumber}','{user.Email}') RETURNING *";

        NpgsqlCommand command = new NpgsqlCommand(query,connection);

        try
        {
            connection.Open();
            NpgsqlDataReader reader = command.ExecuteReader();
            if(reader.Read())
            {
                User createdUser = new User();
                createdUser.userId =Convert.ToInt32(reader["userId"]);
                createdUser.Email = reader["Email"].ToString() ?? "";
                createdUser.PhoneNumber = reader["PhoneNumber"].ToString() ?? "";
                createdUser.Name = reader["Name"].ToString() ?? "";
                Console.WriteLine("User created Successfully");
                return createdUser;
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
        
        //items.Add(userId,user);
        return null!;
    }
}