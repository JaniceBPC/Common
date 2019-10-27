
using System;

namespace Jbpc.Common.ExtensionMethods
{
    public static class ExceptionExtensionMethods
    {
        public static string RecursiveToString(this Exception ex, bool stackTrace = true)
        {
            return FormatException.Format(ex, stackTrace);
        }
    }
}