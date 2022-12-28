using Dapper;
using Microsoft.Data.Sqlite;

namespace B2CManagementService.DataBase
{
    public class UserProvider : IUserProvider
    {
        private readonly DatabaseConfig _databaseConfig;
        public UserProvider(DatabaseConfig databaseConfig)
        {
            _databaseConfig = databaseConfig;
        }

        public async Task<IEnumerable<UserModel>> Get()
        {
            using var connection = new SqliteConnection($"Data Source={_databaseConfig.UsersDB}");

            return await connection.QueryAsync<UserModel>("SELECT rowid as Id, Name FROM User;");
        }
    }
}
