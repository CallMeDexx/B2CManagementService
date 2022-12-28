using Dapper;
using Microsoft.Data.Sqlite;

namespace B2CManagementService.DataBase
{
    public class UserRepository : IUserRepository
    {
        private readonly DatabaseConfig _databaseConfig;
        public UserRepository(DatabaseConfig databaseConfig)
        {
            _databaseConfig = databaseConfig;
        }

        public async Task Create(UserModel userModel)
        {
            using var connection = new SqliteConnection($"Data Source={_databaseConfig.UsersDB}");

            await connection.ExecuteAsync("INSERT INTO User (Email)" + "VALUES (@Email);", userModel);


        }
    }
}
