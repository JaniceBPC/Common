using System;

namespace Universal.ExtensionMethods
{
    public static class TypeExtensionMethods
    {
        public static bool IsNullable(this Type type) => Nullable.GetUnderlyingType(type) != null;
    }
}
