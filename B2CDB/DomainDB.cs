using Dapper;
using Microsoft.Data.Sqlite;
using System.Data;

namespace B2CDB
{
    public class DomainDB : IDomainDB, IBlackListDB, IWhiteListDB
    {

        public DomainDB()
        {
            CreateBlackListTable();
            CreateWhiteListTable();
        }

        public bool AddToBlackList(string domain)
        {
            if (IsBlackListed(domain)) 
                return false;
            
            using var connection = DBUtils.GetConnection();


            var schema = MakeSchemaFromModel(domain);

            var fields = DapperSchemaHelper.MakeFields(schema);
            var values = DapperSchemaHelper.MakeValues(schema);

            var query = $"INSERT INTO {Constants.BlackListDomainsTable} ({fields}) VALUES ({values})";

            var result = connection.Execute(query, domain);

            return true;
        }

        //TODO:
        public bool AddToWhiteList(string domain)
        {
            if (IsBlackListed(domain))
                return false;

            using var connection = DBUtils.GetConnection();
            //cnn.Execute("insert into Table(val) values (@val)", new { val });


            var schema = MakeSchemaFromModel(domain);

            var fields = DapperSchemaHelper.MakeFields(schema);
            var values = DapperSchemaHelper.MakeValues(schema);

            var query = $"INSERT INTO {Constants.WhiteListDomainsTable} ({fields}) VALUES ({values})";

            var result = connection.Execute(query, domain);

            return true;
        }

        public ISet<string> GetBlackList()
        {
            using var connection = new SqliteConnection($"Data Source={Constants.B2CDB}");
            var result = connection.Query<string>($"SELECT * From {Constants.BlackListDomainsTable}");
            return new HashSet<string>(result);
        }

        public ISet<string> GetWhiteList()
        {
            using var connection = new SqliteConnection($"Data Source={Constants.B2CDB}");
            var result = connection.Query<string>($"SELECT * From {Constants.WhiteListDomainsTable}");
            return new HashSet<string>(result);
        }
        //TODO: Exist Query
        public bool IsBlackListed(string userEmail)
        {
            var userDomain = Utils.ParsEmailDomain(userEmail);
            if (userEmail == null)
                throw new Exception("invalid user email");
            
            using var connection = new SqliteConnection($"Data Source={Constants.B2CDB}");
            var exists = connection.ExecuteScalar<bool>($"SELECT count(1) FROM {Constants.BlackListDomainsTable} WHERE {Constants.DomainColumName}=@{nameof(userDomain)}", new { userDomain });
            return exists;
        }
        //TODO: Exist Query
        public bool IsWhiteListed(string userEmail)
        {
            var userDomain = Utils.ParsEmailDomain(userEmail);
            if (userEmail == null)
                throw new Exception("invalid user email");

            using var connection = new SqliteConnection($"Data Source={Constants.B2CDB}");
            var exists = connection.ExecuteScalar<bool>($"SELECT count(1) FROM {Constants.WhiteListDomainsTable} WHERE {Constants.DomainColumName}=@{nameof(userDomain)}", new { userDomain });
            return exists;
        }

        private void CreateBlackListTable()
        {
            if (DBUtils.TableExist(Constants.BlackListDomainsTable)) return;
            using var connection =  DBUtils.GetConnection();

            connection.Execute($"CREATE TABLE {Constants.BlackListDomainsTable} ({Constants.DomainColumName} CHAR(100) NOT NULL);");
        }
        private void CreateWhiteListTable()
        {
            if (DBUtils.TableExist(Constants.WhiteListDomainsTable)) return;
            using var connection = DBUtils.GetConnection();

            connection.Execute($"CREATE TABLE {Constants.WhiteListDomainsTable} ({Constants.DomainColumName} CHAR(100) NOT NULL);");
        }

        private static ParamColumns[] MakeSchemaFromModel(string domain)
        {
            return new[]
            {
                new ParamColumns (Constants.DomainColumName, domain, DbType.String),
            };
        }
    }
}
