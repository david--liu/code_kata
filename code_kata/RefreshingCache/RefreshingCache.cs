using System;
using System.Collections.Generic;
using code_kata.RefreshingCache.Test;
using System.Linq;

namespace code_kata.RefreshingCache
{
    public class RefreshingCache : IService

    {
        private readonly IService service;
        private readonly int maxItems;
        private readonly int staleIntervalInSeconds;
        private readonly Dictionary<string, ValueWithAccessTime> map = new Dictionary<string, ValueWithAccessTime>();

        public RefreshingCache(IService service, int maxItems, int staleIntervalInSeconds)
        {
            this.service = service;
            this.maxItems = maxItems;
            this.staleIntervalInSeconds = staleIntervalInSeconds;
        }

        public string GetValue(string key)
        {
            if (!map.ContainsKey(key))
            {
                AddNewKey(key);
            }
            else
            {
                var isKeyStale = (DateTime.Now - map[key].LastAccessTime).TotalSeconds > staleIntervalInSeconds;
                if(isKeyStale)
                {
                    map[key] = GetValueWithAccessTime(key);
                }
            }


            UpdateLastAccessTime(map[key]);

            return map[key].Value;
        }

        private void AddNewKey(string key)
        {
            if(map.Count == maxItems)
            {
                var leastRecentlyUsedKey = map.OrderBy(x => x.Value.LastAccessTime).First().Key;
                map.Remove(leastRecentlyUsedKey);
            }
            map.Add(key, GetValueWithAccessTime(key));
        }


        private ValueWithAccessTime GetValueWithAccessTime(string key)
        {
            return new ValueWithAccessTime
                       {
                           Value = service.GetValue(key),
                       };
        }

        private void UpdateLastAccessTime(ValueWithAccessTime valueWithAccessTime)
        {
            valueWithAccessTime.LastAccessTime = DateTime.Now;
        }


        private class ValueWithAccessTime
        {
            public string Value { get; set; }
            public DateTime LastAccessTime { get; set; }
        }
    }
}