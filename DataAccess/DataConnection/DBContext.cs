using Npgsql;

public class DataConnection
{
    private readonly string db_connection_string = Environment.GetEnvironmentVariable("ConnectionString") ?? string.Empty;
    public NpgsqlConnection GetConnection()
    {
        return new NpgsqlConnection(db_connection_string);
    }
}