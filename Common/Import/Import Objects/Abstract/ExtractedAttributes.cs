using System.Data;

namespace Jbpc.Common.Import
{
    public abstract class ExtractedAttributes 
    {
        protected ExtractedAttributes(DataRow dataRow, int rowNumber)
        {
            RowNumber = rowNumber;
            DataRow = dataRow;
        }
        public int RowNumber { get;  }
        public DataRow DataRow { get;  }
    }
}
