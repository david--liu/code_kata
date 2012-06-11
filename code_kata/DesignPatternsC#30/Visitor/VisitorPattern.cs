using System;
using System.Reflection;
using ObjectStructure;

// Visitor Pattern - Example    Judith Bishop October 2007
// Sets up an object structure and visits it
// in two ways - for counting using reflection

namespace ObjectStructure
{

    class VisitorElement
    {
        public VisitorElement Next { get; set; }
        public VisitorElement Part { get; set; }
        public VisitorElement() { }
        public VisitorElement(VisitorElement next)
        {
            Next = next;
        }
    }

    class ElementWithLink : VisitorElement
    {
        public ElementWithLink(VisitorElement part, VisitorElement next)
        {
            Next = next;
            Part = part;
        }
    }
}

abstract class IVisitor
{
    public void ReflectiveVisit(VisitorElement element)
    {
        // Use reflection to find and invoke the correct Visit method
        Type[] types = new Type[] { element.GetType() };
        MethodInfo methodInfo = this.GetType().GetMethod("Visit", types);
        if (methodInfo != null)
            methodInfo.Invoke(this, new object[] { element });
        else Console.WriteLine("Unexpected Visit");
    }
}

// Visitor
class CountVisitor : IVisitor
{
    public int Count { get; set; }
    public void CountElements(VisitorElement element)
    {
        ReflectiveVisit(element);
        if (element.Part != null) CountElements(element.Part);
        if (element.Next != null) CountElements(element.Next);
    }

    public void Visit(ElementWithLink element)
    {
        Console.WriteLine("Not counting");
    }
    // Only Elements are counted
    public void Visit(VisitorElement element)
    {
        Count++;
    }
}

// Client
class VisitorClient
{

    static void Main()
    {
        // Set up the object structure
        VisitorElement objectStructure =
          new VisitorElement(
              new VisitorElement(
              new ElementWithLink(
               new VisitorElement(
                     new VisitorElement(
                       new ElementWithLink(
                   new VisitorElement(null),
                     new VisitorElement(
                     null)))),
          new VisitorElement(
              new VisitorElement(
              new VisitorElement(null))))));

        Console.WriteLine("Count the elements");
        CountVisitor visitor = new CountVisitor();
        visitor.CountElements(objectStructure);
        Console.WriteLine("Number of Elements is: " + visitor.Count);
    }
}/*
Count the elements
Not counting
Not counting
Number of Elements is: 9
*/