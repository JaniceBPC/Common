using System;
using System.Linq;
using System.Reflection;

namespace Jbpc.Common.ExtensionMethods
{
    public static class TypeExtensionMethods
    {
        public static bool IsNullable(this Type type) => Nullable.GetUnderlyingType(type) != null;
        public static string GetExpandedTypeName(this Type type)
        {
            if (!type.IsGenericType) return type.Name;

            var types = type.GetTypeInfo().IsGenericTypeDefinition
                ? type.GetTypeInfo().GenericTypeParameters
                : type.GetTypeInfo().GenericTypeArguments;

            var names = types
                .Select(x => x.GetExpandedTypeName())
                .ToList();

            var typeName = type.Name.Substring(0, type.Name.IndexOf('`'));

            return $"{typeName}<{string.Join(", ", names)}>";
        }
    }
}
