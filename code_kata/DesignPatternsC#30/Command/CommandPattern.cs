using System;
using NUnit.Framework;

[TestFixture]
class CommandPattern
{
    // Command Pattern                    Judith Bishop  June 2007
    // Uses a single delegate for the single type of commands that
    // the client invokes

    delegate void Invoker();

    static Invoker Execute, Undo, Redo;

    class Command
    {
        public Command(Receiver receiver)
        {
            Execute = receiver.Action;
            Redo = receiver.Action;
            Undo = receiver.Reverse;
        }
    }

    public class Receiver
    {
        string build, oldbuild;
        string s = "some string ";

        public void Action()
        {
            oldbuild = build;
            build += s;
            Console.WriteLine("Receiver is adding " + build);
        }

        public void Reverse()
        {
            build = oldbuild;
            Console.WriteLine("Receiver is reverting to " + build);
        }
    }

    [Test]
    public void Main()
    {
        new Command(new Receiver());
        Execute();
        Redo();
        Undo();
        Execute();
    }
}