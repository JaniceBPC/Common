namespace Universal.Import.ValidationExceptions
{
    public class OtherException : AbstractException
    {
        public OtherException(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }
        public string ErrorMessage { get; }
        public override string ToString() => ErrorMessage;
    }
}
