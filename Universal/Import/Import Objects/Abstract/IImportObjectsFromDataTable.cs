using System.Collections.Generic;
using System.Data;

namespace Universal.Import
{
    public interface IImportObjectsFromDataTable
    {
        List<IObjectImportResult> ImportResults(DataTable dataTable);
        string[] ColumnLabels();
    }
}
