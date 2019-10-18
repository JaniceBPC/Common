using System.Data;

namespace Universal.Import
{
    public interface IImportDataRow
    {
        ObjectImportResult Import(DataRow dataRow, int nthRow);
    }
}