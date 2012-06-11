using System;
using NUnit.Framework;

// Adapter Pattern - Simple         Judith Bishop  Oct 2007
// Simplest adapter using interfaces and inheritance

// Existing way requests are implemented
class Adaptee
{
    // Provide full precision
    public double SpecificRequest(double a, double b)
    {
        return a/b;
    }
}

// Required standard for requests
interface ITarget
{
    // Rough estimate required
    string Request(int i);
}

// Implementing the required standard via Adaptee
class Adapter : Adaptee, ITarget
{
    public string Request(int i)
    {
        return "Rough estimate is " + (int) Math.Round(SpecificRequest(i, 3));
    }
}

[TestFixture]
class AdapterClient
{
    [Test]
    public void Main()
    {
        // Showing the Adapteee in standalone mode
        var first = new Adaptee();
        Console.Write("Before the new standard\nPrecise reading: ");
        Console.WriteLine(first.SpecificRequest(5, 3));

        // What the client really wants
        ITarget second = new Adapter();
        Console.WriteLine("\nMoving to the new standard");
        Console.WriteLine(second.Request(5));
    }
}

/* Output
   Before the new standard
   Precise reading: 1.66666666666667

   Moving to the new standard
   Rough estimate is 2
   */