using System.Data;

namespace Universal.Import
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
