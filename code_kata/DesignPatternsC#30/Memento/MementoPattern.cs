using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using NUnit.Framework;

// Memento Pattern           Judith Bishop  Sept 2007
// Simple illustration with undo

[TestFixture]
class MementoPattern
{
    // Client
    [Test]
    public void Main()
    {
        // References to the mementos
        var c = new Caretaker[10];
        var originator = new Originator();

        var move = 0;
        // Iterator for the moves
        var simulator = new Simulator();

        foreach (string command in simulator)
        {
            // Check for undo
            if (command[0] == '*' && move > 0)
                originator.Restore(c[move - 1].Memento);
            else
                originator.Operation(command);
            move++;
            c[move] = new Caretaker();
            c[move].Memento = originator.SetMemento();
        }
    }

    // Originator
    [Serializable]
    class Originator
    {
        List<string> state = new List<string>();

        public void Operation(string s)
        {
            state.Add(s);
            foreach (var line in state)
                Console.WriteLine(line);
            Console.WriteLine("=======================");
        }

        // The reference to the memento is passed back to the client
        public Memento SetMemento()
        {
            var memento = new Memento();
            return memento.Save(state);
        }

        public void Restore(Memento memento)
        {
            state = (List<string>) memento.Restore();
        }
    }

    [Serializable]
    // Serializes by deep copy to memory and back
        class Memento
    {
        MemoryStream stream = new MemoryStream();
        BinaryFormatter formatter = new BinaryFormatter();

        public Memento Save(object o)
        {
            formatter.Serialize(stream, o);
            return this;
        }

        public object Restore()
        {
            stream.Seek(0, SeekOrigin.Begin);
            var o = formatter.Deserialize(stream);
            stream.Close();
            return o;
        }
    }

    class Caretaker
    {
        public Memento Memento { get; set; }
    }

    class Simulator : IEnumerable
    {
        string[] lines = {
            "The curfew tolls the knell of parting day",
            "The lowing herd winds slowly o'er the lea",
            "Uh hum uh hum",
            "*UNDO",
            "The plowman homeward plods his weary way",
            "And leaves the world to darkness and to me."
        };

        public IEnumerator GetEnumerator()
        {
            foreach (var element in lines)
                yield return element;
        }
    }
}