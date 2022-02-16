using System;
using System.Collections.Generic;
using System.Diagnostics;
using DSA.DataStructures.Trees;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            int MAX = 1000000;
            double addOrAvg = 0.0;
            double addAvg = 0.0;

            double queOrAvg = 0.0;
            double queAvg = 0.0;

            double remOrAvg = 0.0;
            double remAvg = 0.0;
            for (int c = 0; c < 10; c++)
            {
                var intKeyValuePairs = new List<KeyValuePair<int, int>>();

                for (int i = 0; i < MAX; i++)
                {
                    intKeyValuePairs.Add(new KeyValuePair<int, int>(i, i + 42));
                }

                //var dictionaryKeyValueMap = new DictionaryKeyValueMap<int, int>();
                var bstKeyValueMap = new RedBlackTreeKeyValueMap<int, int>();



                //Console.WriteLine("DictionaryKeyValueMap");
                addOrAvg += CreateKeyValueMap<int, int>(bstKeyValueMap, intKeyValuePairs);
                queOrAvg += QueryKeyValueMap<int, int>(bstKeyValueMap, intKeyValuePairs);
                remOrAvg += RemoveKeyValueMap<int, int>(bstKeyValueMap, intKeyValuePairs);


                intKeyValuePairs.Shuffle();
                bstKeyValueMap = new RedBlackTreeKeyValueMap<int, int>();

                addAvg += CreateKeyValueMap<int, int>(bstKeyValueMap, intKeyValuePairs);
                queAvg += QueryKeyValueMap<int, int>(bstKeyValueMap, intKeyValuePairs);
                remAvg += RemoveKeyValueMap<int, int>(bstKeyValueMap, intKeyValuePairs);
            }
            Console.WriteLine("Red Black Create Key value Map");
            Console.WriteLine("Ordered");
            Console.WriteLine(addOrAvg / 10);
            Console.WriteLine("Unordered");
            Console.WriteLine(addAvg / 10);
            Console.WriteLine("");
            Console.WriteLine("BSTQueryKeyValueMap");
            Console.WriteLine("Ordered");
            Console.WriteLine(queOrAvg / 10);
            Console.WriteLine("Unordered");
            Console.WriteLine(queAvg / 10);
            Console.WriteLine("");
            Console.WriteLine("BSTRemoveKeyValueMap");
            Console.WriteLine("Ordered");
            Console.WriteLine(remOrAvg / 10);
            Console.WriteLine("Unordered");
            Console.WriteLine(remAvg / 10);
        }


        public static double CreateKeyValueMap<TKey, TValue>(
                IKeyValueMap<TKey,TValue> keyValueMap,
                List<KeyValuePair<TKey, TValue>> keyValuePairs )
        {
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();
            foreach( var kvp in keyValuePairs)
            {
                keyValueMap.Add(kvp.Key, kvp.Value);
            }
            stopwatch.Stop();
            return stopwatch.Elapsed.TotalSeconds;
            

        }


        public static double QueryKeyValueMap<TKey, TValue>(
                IKeyValueMap<TKey, TValue> keyValueMap,
                List<KeyValuePair<TKey, TValue>> keyValuePairs)
        {
            Stopwatch stopwatch = new Stopwatch();
            
            stopwatch.Start();
            foreach (var kvp in keyValuePairs)
            {
                keyValueMap.Get(kvp.Key);
            }
            stopwatch.Stop();
    
            return stopwatch.Elapsed.TotalSeconds;
        }

        public static double RemoveKeyValueMap<TKey, TValue>(
                IKeyValueMap<TKey, TValue> keyValueMap,
                List<KeyValuePair<TKey, TValue>> keyValuePairs)
        {
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();
            foreach (var kvp in keyValuePairs)
            {
                keyValueMap.Remove(kvp.Key);
            }
            stopwatch.Stop();
            return stopwatch.Elapsed.TotalSeconds;
        }
    }
}
