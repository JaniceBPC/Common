using System.Data;

namespace Jbpc.Common.Import
{
    public interface IExtractAttributes<out T> where T : ExtractedAttributes
    {
        T Extract(DataRow dataRow, int nthRow);
    }
}
