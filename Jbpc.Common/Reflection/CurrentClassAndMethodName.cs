﻿
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Reflection;

namespace Jbpc.Common.Reflection
{
    public static class CurrentClassAndMethodName
    {
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string Name()
        {
            var stackFrame = new StackTrace(new StackFrame(1));
            var method = stackFrame.GetFrame(0).GetMethod();


            return method==null ? "StackFrame method not found": $"{method?.DeclaringType?.FullName}.{method.Name}"; 
        }
    }
}
