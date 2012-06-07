using System;
using System.Collections.Generic;

class Tree<T>
{
    Node<T> root;
    public Tree() { }
    public Tree(Node<T> head)
    {
        root = head;
    }

    public IEnumerable<T> Preorder
    {
        get { return ScanPreorder(root); }
    }

    // Enumerator with Filter
    public IEnumerable<T> Where(Func<T, bool> filter)
    {
        foreach (T p in ScanPreorder(root))
            if (filter(p) == true)
                yield return p;
    }

    // Enumerator with T as Person
    private IEnumerable<T> ScanPreorder(Node<T> root)
    {
        yield return root.Data;
        if (root.Left != null)
            foreach (T p in ScanPreorder(root.Left))
                yield return p;
        if (root.Right != null)
            foreach (T p in ScanPreorder(root.Right))
                yield return p;
    }
}