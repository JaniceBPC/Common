using System.Data;

namespace Jbpc.Common.Import
{
    public class ObjectImportResult : IObjectImportResult
    {
        public ObjectImportResult(DataRow dataRow, ValidationResultCollection validationResultCollection)
        {
            DataRow = dataRow;
            ValidationResultCollection = validationResultCollection;
        }
        public DataRow DataRow { get;  }
        public ValidationResultCollection ValidationResultCollection { get; }
    }
}
