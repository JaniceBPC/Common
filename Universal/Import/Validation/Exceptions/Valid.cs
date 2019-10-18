namespace Universal.Import.ValidationExceptions
{
    public class Valid : AbstractException
    {
        public override bool IsOK => true;
        public override string ToString() => "Ok";
    }
}

