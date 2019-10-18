using System;

namespace Universal.Import.ValidationExceptions
{
    public class ExtractAttributesException : ImportingException
    {
        public ExtractAttributesException(Exception exception) : base(exception)
        {
        }
        public override string ToString() => FormatException.Format(Exception);
    }
}
