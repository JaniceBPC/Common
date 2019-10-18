using System.Data;

namespace Universal.Import
{
    public interface IExtractAttributes<out T> where T : ExtractedAttributes
    {
        T Extract(DataRow dataRow, int nthRow);
    }
}
