
namespace B2CDB;

internal class DBUtils
{

    internal static bool TableExist(string tableName)
    {
        using var connection = GetConnection();
        var tables = connection.Query<string>($"SELECT name FROM sqlite_master");
        return tables.Contains(tableName);
    }

    internal static IDbConnection GetConnection()
    {
        return new SqliteConnection($"Data Source={Constants.B2CDB}");
    }
}
