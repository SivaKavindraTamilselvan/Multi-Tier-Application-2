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
        string query = $"INSERT INTO Users(userId,Name,PhoneNumber,Email) VALUES({user.userId},'{user.Name}','{user.PhoneNumber}','{user.Email}')";

        NpgsqlCommand command = new NpgsqlCommand(query,connection);
        try
        {
            connection.Open();
            int result = command.ExecuteNonQuery();
            if(result > 0)
            {
                Console.WriteLine("User created Successfully");
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
        
        items.Add(userId,user);
        return user;
    }
}