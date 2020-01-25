namespace Jbpc.Common.ExtensionMethods
{
    public static class IntExtensionMethods
    {
        public static string ToHex(this int value)
        {
            return string.Format("0x{0:X}", value);
        }
    }
}
