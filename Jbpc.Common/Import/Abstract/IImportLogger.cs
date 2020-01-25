using System.Text;

namespace Jbpc.Common.Import
{
    public interface IImportLogger
    {
        StringBuilder LogMessage { get; }
    }
}
