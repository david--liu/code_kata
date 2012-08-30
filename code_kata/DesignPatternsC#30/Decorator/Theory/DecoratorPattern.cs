using System;
using NUnit.Framework;

class DecoratorPattern
{
    // Decorator Pattern             Judith Bishop  Dec 2006
    // Shows two decorators and the output of various
    // combinations of the decorators on the basic component

    interface IDecoratorComponent
    {
        string Operation();
    }

    class Component : IDecoratorComponent
    {
        public string Operation()
        {
            return "I am walking ";
        }
    }

    class DecoratorA : IDecoratorComponent
    {
        IDecoratorComponent component;

        public DecoratorA(IDecoratorComponent c)
        {
            component = c;
        }

        public string Operation()
        {
            var s = component.Operation();
            s += "and listening to Classic FM ";
            return s;
        }
    }

    class DecoratorB : IDecoratorComponent
    {
        IDecoratorComponent component;
        public string addedState = "past the Coffee Shop ";

        public DecoratorB(IDecoratorComponent c)
        {
            component = c;
        }

        public string Operation()
        {
            var s = component.Operation();
            s += "to school ";
            return s;
        }

        public string AddedBehavior()
        {
            return "and I bought a cappuccino ";
        }
    }


    [TestFixture]
    public class DecoratorClient
    {
        static void Display(string s, IDecoratorComponent c)
        {
            Console.WriteLine(s + c.Operation());
        }

        [Test]
        public void Main()
        {
            Console.WriteLine("Decorator Pattern\n");

            IDecoratorComponent component = new Component();
            Display("1. Basic component: ", component);
            Display("2. A-decorated : ", new DecoratorA(component));
            Display("3. B-decorated : ", new DecoratorB(component));
            Display("4. B-A-decorated : ", new DecoratorB(
                                               new DecoratorA(component)));
            // Explicit DecoratorB
            var b = new DecoratorB(new Component());
            Display("5. A-B-decorated : ", new DecoratorA(b));
            // Invoking its added state and added behavior
            Console.WriteLine("\t\t\t" + b.addedState + b.AddedBehavior());
        }
    }
}

/* Output
 Decorator Pattern

 1. Basic component: I am walking
 2. A-decorated : I am walking and listening to Classic FM
 3. B-decorated : I am walking to school
 4. B-A-decorated : I am walking and listening to Classic FM to school
 5. A-B-decorated : I am walking to school and listening to Classic FM
          past the Coffee Shop and I bought a cappuccino
 */