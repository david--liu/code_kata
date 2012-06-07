namespace CompositePattern
{
    public interface IComponent<T>
    {
        void Add(IComponent<T> c);
        IComponent<T> Remove(T s);
        string Display(int depth);
        IComponent<T> Find(T s);
        IComponent<T> Share(T s, IComponent<T> home);
        string Name { get; set; }
    }
}