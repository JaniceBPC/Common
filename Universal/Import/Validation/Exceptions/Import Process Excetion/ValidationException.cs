using System;

namespace Universal.Import.ValidationExceptions
{
    public class ValidationException : ImportingException
    {
        public ValidationException(Exception exception) : base(exception)
        {
        }
    }
}
