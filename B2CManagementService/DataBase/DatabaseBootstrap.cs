using Dapper;
using Microsoft.Data.Sqlite;
using System.Linq;

namespace B2CManagementService.DataBase
{
    public class DatabaseBootstrap : IDatabaseBootstrap
    {
        private readonly DatabaseConfig _databaseConfig;
        public DatabaseBootstrap(DatabaseConfig databaseConfig)
        {
            this._databaseConfig = databaseConfig;
        }

        public void Setup()
        {
            using var connection = new SqliteConnection($"Data Source={_databaseConfig.UsersDB}");

            var table = connection.Query<string>("SELECT name FROM sqlite_master WHERE type = 'table' AND name = 'User';");
            var tableName = table.FirstOrDefault();
            if (!string.IsNullOrEmpty(tableName) && tableName == "User")
                return;


            connection.Execute("Create User Table (" +
                "Email VARCHAR(100) NOT NULL);");
        }
    }
}
