using System;
using System.Collections.Generic;
using System.Diagnostics;
using DSA.DataStructures.Trees;
using System.IO;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            //int MAX = 100000;

            //int MAX = 1000000;

            int MAX = 10000000;

            string times = "";

            //string heights = "";

            var bstKeyValueMap = new RedBlackTreeKeyValueMap<int, int>();

            for (int c = 0; c < 10; c++)
            {
                var intKeyValuePairs = new List<KeyValuePair<int, int>>();

                for (int i = 0; i < MAX; i++)
                {
                    intKeyValuePairs.Add(new KeyValuePair<int, int>(i, i + 42));
                }

                //intKeyValuePairs.Shuffle();
                bstKeyValueMap = new RedBlackTreeKeyValueMap<int, int>();

                times += CreateKeyValueMap<int, int>(bstKeyValueMap, intKeyValuePairs);

                //heights += bstKeyValueMap.Height + ", ";
            }
            try
            {
                StreamWriter sw = new StreamWriter(path: "/Users/greenegunnar/Documents/CIS374/Labs/Lab1Data.txt", append:true);
                sw.WriteLine(times);
                sw.WriteLine();
                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Times written to Lab1Data.txt");
            }
        }


        public static string CreateKeyValueMap<TKey, TValue>(
                IKeyValueMap<TKey,TValue> keyValueMap,
                List<KeyValuePair<TKey, TValue>> keyValuePairs )
        {

            foreach( var kvp in keyValuePairs)
            {
                keyValueMap.Add(kvp.Key, kvp.Value);
            }

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            //QueryKeyValueMap(keyValueMap, keyValuePairs);
            RemoveKeyValueMap(keyValueMap, keyValuePairs);

            stopwatch.Stop();
            return stopwatch.Elapsed.TotalSeconds + ", ";
        }


        public static void QueryKeyValueMap<TKey, TValue>(
                IKeyValueMap<TKey, TValue> keyValueMap,
                List<KeyValuePair<TKey, TValue>> keyValuePairs)
        {
           foreach (var kvp in keyValuePairs)
            {
                keyValueMap.Get(kvp.Key);
            }
        }

        public static void RemoveKeyValueMap<TKey, TValue>(
                IKeyValueMap<TKey, TValue> keyValueMap,
                List<KeyValuePair<TKey, TValue>> keyValuePairs)
        {
            foreach (var kvp in keyValuePairs)
            {
                keyValueMap.Remove(kvp.Key);
            }
        }
    }
}
