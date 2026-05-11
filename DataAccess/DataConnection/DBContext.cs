using Npgsql;

namespace NotificationAppDataAccessLibrary.DBContext;

public class DataConnection
{
    //database connection string created
    private readonly string db_connection_string = Environment.GetEnvironmentVariable("ConnectionString") ?? string.Empty;
    public NpgsqlConnection GetConnection()
    {
        return new NpgsqlConnection(db_connection_string);
    }
}