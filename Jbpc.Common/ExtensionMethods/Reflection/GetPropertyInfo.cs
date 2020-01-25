using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Jbpc.Common.ExtensionMethods
{
    public static class GetPropertyInfo<T>
    {
        public static PropertyInfo Get<TValue>(
            Expression<Func<T, TValue>> selector)
        {
            Expression body = selector;
            if (body is LambdaExpression)
            {
                body = ((LambdaExpression)body).Body;
            }
            switch (body.NodeType)
            {
                case ExpressionType.MemberAccess:
                    return (PropertyInfo)((MemberExpression)body).Member;
                default:
                    throw new InvalidOperationException();
            }
        }
    }
}
