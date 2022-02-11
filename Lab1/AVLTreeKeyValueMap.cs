using System.Collections.Generic;
using DSA.DataStructures.Trees;

namespace Lab1
{
    class AVLTreeKeyValueMap<TKey, TValue> : IKeyValueMap<TKey, TValue>
    {
        private AVLTreeMap<TKey, TValue> AVLTree = new AVLTreeMap<TKey, TValue>();

        public AVLTreeKeyValueMap()
        {
        }

        public int Height => AVLTree.Height;

        public int Count => AVLTree.Count;

        public void Add(TKey key, TValue value)
        {
            AVLTree.Add(key, value);
        }

        public KeyValuePair<TKey, TValue> Get(TKey key)
        {
            TValue value = AVLTree[key];

            return new KeyValuePair<TKey, TValue>(key, value);
        }

        public bool Remove(TKey key)
        {
            if (AVLTree.ContainsKey(key))
            {
                AVLTree.Remove(key);

                return true;
            }

            return false;
        }
    }
}