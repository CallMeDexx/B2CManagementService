using Dapper;
using System.Data;

namespace B2CDB;

public static class DapperSchemaHelper
{
    public static DynamicParameters MakeDynamicParameters(IEnumerable<ParamColumns> columns)
    {
        var parameters = new DynamicParameters();

        foreach (var column in columns)
            parameters.Add(column.F, column.V, column.T);

        return parameters;
    }

    public static string MakeFields(IEnumerable<ParamColumns> columns)
    {
        const string fieldSeparator = ",";
        return string.Join(fieldSeparator, columns.Select(c => c.F).ToArray());
    }

    public static string MakeValues(IEnumerable<ParamColumns> columns)
    {
        const string valueSeparator = "','";
        var val = string.Join(valueSeparator, columns.Select(c => c.V).ToArray());
        return $"'{val}'";
    }
}

public class ParamColumns
{
    public ParamColumns(string f, object v, DbType t) { F = f; V = v; T = t; }

    public string F { get; }
    public object V { get; }
    public DbType T { get; }
}
