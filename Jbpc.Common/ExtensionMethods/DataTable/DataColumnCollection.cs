using System.Collections.Generic;
using System.Data;

namespace Jbpc.Common.ExtensionMethods
{
    public static class DataColumnCollectionExtensionMethods
    {
        public static List<string> ColumnNames(this DataColumnCollection columns)
        {
            var columnNames = new List<string>();

            for (int i = 0; i < columns.Count; i++)
            {
                columnNames.Add(columns[i].ColumnName);
            }

            return columnNames;
        }
    }
}
