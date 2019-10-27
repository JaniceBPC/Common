using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Jbpc.Common.ExtensionMethods
{
    public static class ListExtensionMethods
    {
        public static List<T> From<T>(T item1, T item2)
        {
            var list = new List<T>();

            list.Add(item1);
            list.Add(item2);

            return list;
        }
        public static List<T> SkipNext<T>(this List<T> list) => list.Skip(1).ToList();
        public static T TakeNext<T>(this List<T> list)
        {
            System.Diagnostics.Debug.Assert(list.Any());

            var first = list.First();

            list.Remove(first);

            return first;
        }
        public static TMax Max<TMax, TElement>(this List<TElement> list, Func<TMax, TElement,bool> maxFunc, Func<TElement, TMax> getValue)
        {
            var max = default(TMax);

            foreach (TElement each in list)
            {
                if (maxFunc(max, each))
                {
                    max = getValue(each);
                }
            }

            return max;
        }
        public static void AddOrReplace<T>(this List<T> list, T element)
        {
            var index = list.IndexOf(element);

            if (index != -1)
            {
                list[index] = element;
            }
            else
            {
                list.Add(element);
            }
        }
        public static bool IsContainedWithinList<T>(this List<T> a, List<T> b)
        {
            if (!a.Any() || a.Count>b.Count) return false;

            b = b.SkipWhile(x => !x.Equals(a.First())).ToList();

            if (b.Count < a.Count) return false;

            for (int i = 0; i < a.Count; i++)
            {
                if (!b[i].Equals(a[i])) return false;
            }

            return true;
        }
    }
}
