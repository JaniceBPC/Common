namespace Jbpc.Common.Import.ValidationExceptions
{
    public abstract class AbstractException : IValidationException 
    {
        public virtual bool IsOK => true;
    }
}
