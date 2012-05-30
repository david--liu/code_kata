using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace code_kata.StringSet
{
    public class StringSet : IEnumerable<string>
    {
        readonly List<string> list;

        public StringSet() : this(new List<string>())
        {
        }

        public StringSet(IEnumerable<string> list)
        {
            this.list = list.ToList();
        }

        public int Count
        {
            get { return list.Count; }
        }

        public void Add(string item)
        {
            list.Add(item);
        }

        public bool Contains(string item)
        {
            return list.Contains(item);
        }

        public void Remove(string item)
        {
            list.Remove(item);
        }

        public void Clear()
        {
            list.Clear();
        }

        public IEnumerator<string> GetEnumerator()
        {
            return list.GetEnumerator();    
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public StringSet Union(StringSet other)
        {
            return new StringSet(list.Union(other));
        }

        public StringSet Intersect(StringSet other)
        {
            return new StringSet(list.Intersect(other));
        }
    }
}