using System.Collections.Generic;
using System.Data;

namespace Jbpc.Common.Import
{
    public interface IImportObjectsFromDataTable
    {
        List<IObjectImportResult> ImportResults(DataTable dataTable);
        string[] ColumnLabels();
    }
}
