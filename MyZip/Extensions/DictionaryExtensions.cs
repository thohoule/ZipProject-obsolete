using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyZip
{
    public static class DictionaryExtensions
    {
        public static bool TryAdd<TKey,TValue>(this Dictionary<TKey, TValue> dictionary, TKey key, TValue value)
        {
            try
            {
                dictionary.Add(key, value);
                return true;
            }
            catch (ArgumentException)
            {
                return false;
            }
        }
    }
}
