using System.Data.SqlClient;

namespace Universal.ExtensionMethods
{
    public static class SqlParameterExtensionMethods
    {
        public static string PrettyPrint(this SqlParameter parameter, string fieldName)
        {
            return $"sqlName={parameter.ParameterName}, fieldName={fieldName}, SqlDBType={parameter.DbType}, value={parameter.Value}";
        }
    }
}
