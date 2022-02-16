using DSA.DataStructures.Trees;
using System.Collections.Generic;

namespace Lab1
{
    internal class RedBlackTreeKeyValueMap<TKey, TValue> : IKeyValueMap<TKey, TValue>
    {
        private RedBlackTreeMap<TKey, TValue> redBlackMap = new RedBlackTreeMap<TKey, TValue>();
        public RedBlackTreeKeyValueMap()
        {

        }

        public int Height => redBlackMap.Height;

        public int Count => redBlackMap.Count;

        public void Add(TKey key, TValue value)
        {
            redBlackMap.Add(key,value);
        }

        public KeyValuePair<TKey, TValue> Get(TKey key)
        {
            var value = redBlackMap[key];
            return new KeyValuePair<TKey, TValue>(key, value);
        }

        public bool Remove(TKey key)
        {
            return redBlackMap.Remove(key);
        }
    }
}