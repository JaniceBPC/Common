using System.Data;

namespace Jbpc.Common.Import
{
    public interface IImportDataRow
    {
        ObjectImportResult Import(DataRow dataRow, int nthRow);
    }
}