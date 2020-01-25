using System;
using System.Data;

namespace Jbpc.Common.ExtensionMethods
{
    public static class DataRowExtensionMethods
    {
        public static string GetString(this DataRow dataRow, string fieldName) => GetValue<string>(dataRow, fieldName)?.Trim();
        public static T Get<T>(this DataRow dataRow, string fieldName) => GetValue<T>(dataRow, fieldName);
        private static T GetValue<T>(DataRow dataRow, string fieldName)
        {
            var actualType = !typeof(T).IsNullable() ? typeof(T) : Nullable.GetUnderlyingType(typeof(T));

            try
            {
                if (DBNull.Value.Equals(dataRow[fieldName])) return default(T);

                var a = dataRow[fieldName].GetType().Name;
                var b = dataRow[fieldName].ToString();

                if (dataRow[fieldName].GetType() == actualType) return (T)dataRow[fieldName];
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Column=\"{fieldName}\" not in data table columns=[{string.Join(", ", dataRow.Table.ColumnNames())}], ex message={ex.Message}");
            }

            T result;
            try
            {
                result = (T)Convert.ChangeType(dataRow[fieldName].ToString(), typeof(T));
            }
            catch (Exception)
            {
                result = default(T);
            }
            return result;
        }
    }
}
