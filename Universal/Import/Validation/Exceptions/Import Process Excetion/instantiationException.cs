using System;

namespace Universal.Import.ValidationExceptions
{
    public class instantiationException : ImportingException
    {
        public instantiationException(Exception exception) : base(exception)
        {
        }
        public override string ToString() => FormatException.Format(Exception);
    }
}
