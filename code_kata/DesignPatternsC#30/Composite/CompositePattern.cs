using System;
using System.Collections.Generic;
using System.Text;
using CompositePattern;

// for StringBuilder

// Composite Pattern Theory    Judith Bishop  Dec 2006, Aug 2007
// Arranges structures hierarchies so that single components and 
// composite groups of components can be treated in the same way.
// Revised July 2008

// The Component
public class Component<T> : IComponent<T>
{
    public IComponent<T> Share(T s, IComponent<T> home)
    {
        throw new NotImplementedException();
    }

    string IComponent<T>.Name
    {
        get { throw new NotImplementedException(); }
        set { throw new NotImplementedException(); }
    }

    public T Name { get; set; }

    public Component(T name)
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
        if (s.Equals(Name))
            return this;
        else
            return null;
    }
}

// The Composite
public class Composite<T> : IComponent<T>
{
    List<IComponent<T>> list;

    public IComponent<T> Share(T s, IComponent<T> home)
    {
        throw new NotImplementedException();
    }

    string IComponent<T>.Name
    {
        get { throw new NotImplementedException(); }
        set { throw new NotImplementedException(); }
    }

    public T Name { get; set; }

    public Composite(T name)
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
        var p = this.Find(s);
        if (this != null)
        {
            (this).list.Remove(p);
        }
        return this;
    }

    // Recursively looks for an item
    // Returns its reference or else null
    public IComponent<T> Find(T s)
    {
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

    // Displays items in a format indicating their level 
    // in the composite structure
    public string Display(int depth)
    {
        var s =
            new StringBuilder(new String('-', depth));
        s.Append("Set " + Name + " length :" + list.Count + "\n");
        foreach (var component in list)
            s.Append(component.Display(depth + 2));
        return s.ToString();
    }
}