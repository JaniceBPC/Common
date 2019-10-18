using System;
using System.Collections.Generic;
using System.Linq;

namespace Universal
{
    public class LambdaHashDict<TKey, TValue>
    {
        private Dictionary<int, List<TValue>> dict = new Dictionary<int, List<TValue>>();
        private Dictionary<int, List<TValue>> foreignKeyDict = new Dictionary<int, List<TValue>>();
        public LambdaHashDict() { }

        public TValue Lookup(TValue prototype, Predicate<TValue> isEquivalent)
        {
            var hashCode = prototype.GetHashCode();

            if (!foreignKeyDict.ContainsKey(hashCode))
                return default(TValue);

            return foreignKeyDict[hashCode].Single(x => isEquivalent(x));
        }
        public TValue Lookup(TKey key, Predicate<TValue> isEquivalent)
        {
            var hashCode = key.GetHashCode();

            if (!dict.ContainsKey(hashCode))
                return default(TValue);

            return dict[hashCode].Single(x => isEquivalent(x));
        }
        public void Add(TKey key, TValue obj)
        {
            Add(obj);

            List<TValue> collisionBucket = new List<TValue>();

            var hashCode = key.GetHashCode();

            if (dict.ContainsKey(hashCode))
            {
                collisionBucket = dict[hashCode];
            }
            else
            {
                dict.Add(hashCode, collisionBucket);
            }
            collisionBucket.Add(obj);
        }
        public void Add(TValue obj)
        {
            List<TValue> collisionBucket = new List<TValue>();

            var hashCode = obj.GetHashCode();

            if (foreignKeyDict.ContainsKey(hashCode))
            {
                collisionBucket = dict[hashCode];
            }
            else
            {
                foreignKeyDict.Add(hashCode, collisionBucket);
            }
            collisionBucket.Add(obj);
        }

        public void Remove(TValue obj)
        {
            var hashCode = obj.GetHashCode();

            if (!foreignKeyDict.ContainsKey(hashCode)) return;

            dict[hashCode].Remove(obj);
        }
        public void Clear() => dict.Clear();
    }
}
