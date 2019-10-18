using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Universal.ExtensionMethods
{
    public static class AggregateExceptionExtensionMethods
    {
        public static bool IsCancelationException(this AggregateException aggregateException)
        {
            var exceptions = new List<Exception>();
            exceptions.AddRange(aggregateException.Flatten().InnerExceptions);

            return exceptions.Exists(x => x.GetType() == typeof(TaskCanceledException));
        }
    }
}
