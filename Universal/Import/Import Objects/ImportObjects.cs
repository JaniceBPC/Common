using System.Collections.Generic;
using System.Data;

namespace Universal.Import
{
    public class ImportObjects
    {
        private readonly IImportDataRow importDataTableRow;
        public int NthRow { get; set; }
        public ImportObjects(IImportDataRow importDataTableRow)
        {
            this.importDataTableRow = importDataTableRow;
        }
        public List<ObjectImportResult> Import(DataTable dataTable)
        {
            List<ObjectImportResult> importResults = new List<ObjectImportResult>();

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                var dataRow = (DataRow)dataTable.Rows[i];

                var objectImportResult = importDataTableRow.Import(dataRow, i);

                importResults.Add(objectImportResult);
            }

            return importResults;
        }

    }
}
