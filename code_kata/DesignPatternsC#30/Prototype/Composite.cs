using System;
using System.Collections.Generic;
using PrototypePattern;


namespace CompositePattern
{
    // The Composite Pattern namespace
    // including the Share operations

    // The Interface

    // The Composite
    [Serializable]
    public class Composite<T> : IPrototype<IComponent<T>>, IComponent<T>
    {
        private readonly List<IComponent<T>> list;
        public string Name { get; set; }

        public Composite(string name)
        {
            Name = name;
            list = new List<IComponent<T>>();
        }

        public void Add(IComponent<T> c)
        {
            list.Add(c);
        }

        // Finds the item from a particular point in the structure
        // and returns the composite from which it was removed
        // If not found, return the point as given
        public IComponent<T> Remove(T s)
        {
            holder = this;
            var p = holder.Find(s);
            if (holder != null)
            {
                (holder as Composite<T>).list.Remove(p);
                return holder;
            }
            else
                return this;
        }

        private IComponent<T> holder;
        // Recursively looks for an item
        // Returns its reference or else null
        public IComponent<T> Find(T s)
        {
            holder = this;
            if (Name.Equals(s)) return this;
            IComponent<T> found = null;
            foreach (var c in list)
            {
                found = c.Find(s);
                if (found != null)
                    break;
            }
            return found;
        }

        public IComponent<T> Share(T set, IComponent<T> toHere)
        {
            var prototype =
                Find(set) as IPrototype<IComponent<T>>;
            var copy = prototype.DeepCopy() as IComponent<T>;
            toHere.Add(copy);
            return toHere;
        }

        // Displays items in a format indicating their level in the composite structure
        public string Display(int depth)
        {
            var s = new String('-', depth) + "Set " + Name +
                    " length :" + list.Count + "\n";
            foreach (var component in list)
                s += component.Display(depth + 2);

            return s;
        }
    }

    // The Component
}