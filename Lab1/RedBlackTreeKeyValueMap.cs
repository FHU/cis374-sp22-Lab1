using System.Collections.Generic;
using DSA.DataStructures.Trees;

namespace Lab1
{
    internal class RedBlackTreeKeyValueMap<TKey, TValue> : IKeyValueMap<TKey, TValue>
    {
        private RedBlackTreeMap<TKey, TValue> RBTree = new RedBlackTreeMap<TKey, TValue>();

        public RedBlackTreeKeyValueMap()
        {
        }

        public int Height => RBTree.Height;

        public int Count => RBTree.Count;

        public void Add(TKey key, TValue value)
        {
            RBTree.Add(key, value);
        }

        public KeyValuePair<TKey, TValue> Get(TKey key)
        {
            TValue value = RBTree[key];

            return new KeyValuePair<TKey, TValue>(key, value);
        }

        public bool Remove(TKey key)
        {
            if (RBTree.ContainsKey(key))
            {
                RBTree.Remove(key);

                return true;
            }

            return false;
        }
    }
}