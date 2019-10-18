
using System;
using System.Data;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;

namespace Universal.ExtensionMethods
{
    public static class  IEnumerableExtensionMethods
    {
        public static IEnumerable<T> ReplaceOrAdd<T>(this IEnumerable<T> source, T obj) where T : IEquatable<T>
        {
            return source.Where(x => !x.Equals(obj)).Concat(new List<T>() { obj });
        }
        public static void ForEach<T>(this IEnumerable<T> enumeration, Action<T> action)
        {
            foreach (T item in enumeration)
            {
                action(item);
            }
        }
        public static DataTable PropertyValues<T>(this IEnumerable<T> objects)
        {
            var dataTable = new DataTable();

            PropertyInfo[] propertiesInfo = typeof(T).GetProperties();

            foreach (var propertyInfo in propertiesInfo)
            {
                var columnType = propertyInfo.PropertyType;

                if (propertyInfo.PropertyType.IsGenericType && propertyInfo.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                {
                    // Get nullable's underlying type
                    columnType = propertyInfo.PropertyType.GetGenericArguments()[0];
                }
                dataTable.Columns.Add(new DataColumn(propertyInfo.Name, columnType));
            }

            foreach (object obj in objects)
            {
                object[] row = new object[propertiesInfo.Length];
                int i = 0;

                foreach (var propertyInfo in propertiesInfo)
                {
                    row[i++] = propertyInfo.GetValue(obj, null);
                }

                dataTable.Rows.Add(row);
            }

            return dataTable;
        }
    }
}
