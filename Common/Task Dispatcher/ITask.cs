
using System.Threading.Tasks;

namespace Jbpc.Common
{
    public interface ITask
    {
        void PerformTask(ITaskBridge taskBridge);
        string LogMessage { get; }
        string Description { get; }
        void Reset();
        Task Task { get; }
    }
}
