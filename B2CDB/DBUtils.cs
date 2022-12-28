namespace B2CDB;

internal class DBUtils
{

    internal static bool TableExist(string tableName)
    {
        using var connection = GetConnection();
        //var tables = connection.Query<string>($"SELECT name FROM sqlite_master");
        //return tables.Contains(tableName);

        var tables = connection.Query<string>($"SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'{tableName}'");
        return tables.Count() > 0;
    }

    internal static IDbConnection GetConnection()
    {
        //return new SqliteConnection($"Data Source={Constants.B2CDB}");
        return new SqlConnection($"data source=b2cdb-server.database.windows.net;Initial catalog=b2csqldb;user id=B2CdbAdmin;password=SQL!Q@W1q2w");
    }
}