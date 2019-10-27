using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Jbpc.Common.Import.ValidationExceptions;

namespace Jbpc.Common.Import
{
    public class ValidationResult : IEnumerable<IValidationException>
    {
        private readonly List<IValidationException> exceptions = new List<IValidationException>();
        public ValidationResult() { }
        public ValidationResult(IValidationException validationException)
        {
            exceptions.Add(validationException);
        }
        public IEnumerator<IValidationException> GetEnumerator() => exceptions.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        public void Add(AbstractException exception) => exceptions.Add(exception);
        public void AddRange(List<IValidationException> exceptionsToAdd) => exceptions.AddRange(exceptionsToAdd);
        public bool IsOk => !exceptions.Any();
        public override string ToString()
        {
            return !exceptions.Any() ? "ok " : string.Join(", ", exceptions.Select(x => x.ToString()));
        }
    }
}
