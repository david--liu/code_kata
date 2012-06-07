using System;
using System.Linq;
using NUnit.Framework;

// T is the data type. The Node type is built-in.

[TestFixture]
public class IteratorPatternTest
{
    // Iterator Pattern for a Tree        Judith Bishop  Sept 2007
    // Shows two enumerators using links and recursion
    [Test]
    public void Main()
    {
        var family = new Tree<Person>(new Node<Person>
                                          (new Person("Tom", 1950),
                                           new Node<Person>(new Person("Peter", 1976),
                                                            new Node<Person>
                                                                (new Person("Sarah", 2000), null,
                                                                 new Node<Person>
                                                                     (new Person("James", 2002), null,
                                                                      null) // no more siblings James
                                                                ),
                                                            new Node<Person>
                                                                (new Person("Robert", 1978), null,
                                                                 new Node<Person>
                                                                     (new Person("Mark", 1980),
                                                                      new Node<Person>
                                                                          (new Person("Carrie", 2005), null, null),
                                                                      null) // no more siblings Mark
                                                                )),
                                           null) // no siblings Tom
            );

        Console.WriteLine("Full family");
        foreach (var p in family.Preorder)
            Console.Write(p + "  ");
        Console.WriteLine("\n");

        // Older syntax
        var selection = family.
            Where(p => p.Birth > 1980);

        // New syntax
        selection = from p in family
                    where p.Birth > 1980
                    orderby p.Name
                    select p;

        Console.WriteLine("Born after 1980 in alpha order");
        foreach (var p in selection)
            Console.Write(p + "   ");
        Console.WriteLine("\n");
    }
}