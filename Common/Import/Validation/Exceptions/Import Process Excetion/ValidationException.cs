using System;

namespace Jbpc.Common.Import.ValidationExceptions
{
    public class ValidationException : ImportingException
    {
        public ValidationException(Exception exception) : base(exception)
        {
        }
    }
}
