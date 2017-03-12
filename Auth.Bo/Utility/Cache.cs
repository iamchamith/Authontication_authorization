﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Bo.Utility
{
    public class Cache
    {
        public static bool Add(string key, object value, int hours = 24)
        {
            var dateTimeOffset = DateTimeOffset.Parse(DateTime.Now.ToShortDateString());
            MemoryCache memoryCache = MemoryCache.Default;
            return memoryCache.Add(key, value, dateTimeOffset.AddHours(hours));
        }

        public static object GetValue(string key)
        {
            MemoryCache memoryCache = MemoryCache.Default;
            return memoryCache.Get(key);
        }

        public static void Delete(string key)
        {
            MemoryCache memoryCache = MemoryCache.Default;
            if (memoryCache.Contains(key))
            {
                memoryCache.Remove(key);
            }
        }
    }
}

