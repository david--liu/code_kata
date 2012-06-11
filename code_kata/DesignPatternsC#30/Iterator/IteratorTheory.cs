using System;
using System.Collections;
using NUnit.Framework;

[TestFixture]
class IteratorPattern
{
    // Simplest Iterator                    Judith Bishop  Sept 2007

    class MonthCollection : IEnumerable
    {
        string[] months = {
            "January", "February", "March", "April", "May", "June",
            "July", "August", "September", "October", "November", "December"
        };

        public IEnumerator GetEnumerator()
        {
            // Generates values from the collection
            foreach (var element in months)
                yield return element;
        }
    }

    [Test]
    public void Main()
    {
        var collection = new MonthCollection();
        // Consumes values generated from collection's GetEnumerator method
        foreach (string n in collection)
            Console.Write(n + "   ");
        Console.WriteLine("\n");
    }
}