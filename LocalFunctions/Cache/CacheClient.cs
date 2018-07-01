using System;
using System.Collections.Generic;
using System.Text;

namespace LocalFunctions.Cache
{
    internal class CacheClient
    {
        private IDictionary<string, object> keyValues = new Dictionary<string, object>();

        internal CacheClient()
        {
        }

        internal T GetValue<T>(string key, Func<T> resolver)
        {
            keyValues.TryGetValue(key, out object value);

            if (value == null && !keyValues.ContainsKey(key))
            {
                // resolve value
                value = resolver();

                // add to cache
                keyValues.Add(key, value);
            }

            return (T)value;
        }
    }
}
