using System.Data;

namespace Universal.Import
{
    public class ObjectImportResult : IObjectImportResult
    {
        public ObjectImportResult(DataRow dataRow, ValidationResult validationResult)
        {
            DataRow = dataRow;
            ValidationResult = validationResult;
        }
        public DataRow DataRow { get;  }
        public ValidationResult ValidationResult { get; }
    }
}
