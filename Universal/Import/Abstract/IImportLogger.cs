using System.Text;

namespace Universal.Import
{
    public interface IImportLogger
    {
        StringBuilder LogMessage { get; }
    }
}
