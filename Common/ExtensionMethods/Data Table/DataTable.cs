using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Jbpc.Common.ExtensionMethods
{
    public static class DataTableExtensionMethods
    {
        public static string MissingColumnsMessage(this DataTable dataTable, string[] expectedColumns)
        {
            var missingFields = dataTable.MissingColumnNames(expectedColumns);

            if (!missingFields.Any()) return "";

            var missingColumns = string.Join($"{Environment.NewLine}\t", missingFields);
            var tableColumnNames = string.Join($"{Environment.NewLine}\t", dataTable.ColumnNames());

            var msg = $"Import file is missing column(s):{Environment.NewLine}\t{missingColumns}";
            msg = $"{msg}{Environment.NewLine}Actual column names found:{Environment.NewLine}\t{tableColumnNames}";

            return msg;
        }
        public static bool IsExpectedColumnsPresent(this DataTable dataTable, string[] expectedColumns) => !dataTable.MissingColumnNames(expectedColumns).Any();
        public static List<string> MissingColumnNames(this DataTable dataTable, string[] fieldNames)
        {
            var columnNames = dataTable.ColumnNames();

            var missingColumnNames = fieldNames
                .ToList()
                .Where(x => !columnNames.Exists(g => g.ToUpper() == x.ToUpper()))
                .ToList();

            return missingColumnNames;
        }
        public static List<string> ColumnNames(this DataTable dataTable )
        {
            return dataTable.Columns.ColumnNames();
        }
    }
}
