
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Reflection;

namespace Jbpc.Common.Reflection
{
    public static class CurrentAssemblyClassAndMethodName
    {
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string Name()
        {
            var stackFrame = new StackTrace(new StackFrame(1));
            var method = stackFrame.GetFrame(0).GetMethod();
            return $"{method.DeclaringType.AssemblyQualifiedName}.{method.Name}";
        }
    }
}
