
using System;
using System.Data;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;

namespace Jbpc.Common.ExtensionMethods
{
    public static class DataRowCollectionExtensionMethods
    {
        public static List<DataRow> DataRows(this DataRowCollection rows)
        {
            var dataRows = new List<DataRow>();

            for (int i = 0; i < rows.Count; i++)
            {
                dataRows.Add(rows[i]);
            }

            return dataRows;
        }
    }
}
