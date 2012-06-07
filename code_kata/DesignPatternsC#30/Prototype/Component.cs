using System;
using PrototypePattern;

namespace CompositePattern
{
    [Serializable]
    public class Component<T> : IPrototype<IComponent<T>>, IComponent<T>
    {
        public string Name { get; set; }

        public Component(string name)
        {
            Name = name;
        }

        public void Add(IComponent<T> c)
        {
            Console.WriteLine("Cannot add to an item");
        }

        public IComponent<T> Remove(T s)
        {
            Console.WriteLine("Cannot remove directly");
            return this;
        }

        public string Display(int depth)
        {
            return new String('-', depth) + Name + "\n";
        }

        public IComponent<T> Find(T s)
        {
            if (s.Equals(Name)) return this;
            else
                return null;
        }

        public IComponent<T> Share(T set, IComponent<T> toHere)
        {
            var prototype =
                Find(set) as IPrototype<IComponent<T>>;
            var copy = prototype.Clone() as IComponent<T>;
            toHere.Add(copy);
            return toHere;
        }
    }
}