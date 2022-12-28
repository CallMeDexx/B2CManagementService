namespace B2CDB;

public class UserDB : IUserDB
{
    //private readonly DatabaseConfig _databaseConfig;

    public UserDB()
    {
        CreateUsersTable();
    }

    private void CreateUsersTable(string tableName)
    {
        if (DBUtils.TableExist(Constants.UsersTable)) return;
        using var connection = DBUtils.GetConnection();

        var user = new UserModel();
        var schema = MakeSchemaFromModel(user);

        var fields = DapperSchemaHelper.MakeFields(schema);
        //var values = DapperSchemaHelper.MakeValues(schema);

        var query = $"CREATE TABLE {Constants.UsersTable} ({fields})";

        var result = connection.Execute(query);
    }

    public UserModel? CreateUser(UserModel user)
    {
        if (GetUser(user.Email) != null)
            return null;

        using var connection = DBUtils.GetConnection();


        var schema = MakeSchemaFromModel(user);

        var fields = DapperSchemaHelper.MakeFields(schema);
        var values = DapperSchemaHelper.MakeValues(schema);

        var query = $"INSERT INTO {Constants.UsersTable} ({fields}) VALUES ({values})";

        var result = connection.Execute(query, user);


        return user;
    }

    public IEnumerable<UserModel> GetAllUsers()
    {
        throw new NotImplementedException();
    }

    public UserModel? GetUser(string email)
    {
        throw new NotImplementedException();
    }

    public UserModel? UpdateUser(UserModel user)
    {
        throw new NotImplementedException();
    }

    public bool ValidateUser(UserModel user)
    {
        throw new NotImplementedException();
    }

    private static ParamColumns[] MakeSchemaFromModel(UserModel user)
    {
        return new[]
        {
            new ParamColumns (Constants.UserMailColumName, user.Email, DbType.String)
        };
    }
    private void CreateUsersTable()
    {
        if (DBUtils.TableExist(Constants.UsersTable)) return;
        using var connection = DBUtils.GetConnection();

        //connection.Execute($"CREATE TABLE {Constants.BlackListDomainsTable} ({Constants.DomainColumName} CHAR(100) NOT NULL);");
    }
}
