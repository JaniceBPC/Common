using System;

namespace Universal.Import.ValidationExceptions
{
    public class ImportingException : AbstractException
    {
        public ImportingException(Exception exception)
        {
            Exception = exception;
        }
        public override bool IsOK => false;
        public Exception Exception { get; }
        public override string ToString() => $"{GetType().Name} Exception name=\"{Exception.GetType().Name}\", message=\"{Exception.Message}\"";
    }
}
