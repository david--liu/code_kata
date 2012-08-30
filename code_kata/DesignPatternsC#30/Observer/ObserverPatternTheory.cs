using System;
using System.Collections;
using System.Threading;
using NUnit.Framework;

[TestFixture]
class ObserverPatternTheory
{
    // Observer Pattern                  Judith Bishop  Jan 2007

    // The Subject runs in a thread and changes its state
    // independently. At each change, it notifies its Observers.

    class Subject
    {
        public delegate void Callback(string s);

        public event Callback Notify;

        Simulator simulator = new Simulator();
        const int speed = 200;
        public string SubjectState { get; set; }

        public void Go()
        {
            new Thread(Run).Start();
        }

        void Run()
        {
            foreach (string s in simulator)
            {
                Console.WriteLine("Subject: " + s);
                SubjectState = s;
                Notify(s);
                Thread.Sleep(speed); // milliseconds
            }
        }

        interface IObserver
        {
            void Update(string state);
        }

        class Observer : IObserver
        {
            string name;
            Subject subject;
            string state;
            string gap;

            public Observer(Subject subject, string name, string gap)
            {
                this.subject = subject;
                this.name = name;
                this.gap = gap;
                subject.Notify += Update;
            }

            public void Update(string subjectState)
            {
                state = subjectState;
                Console.WriteLine(gap + name + ": " + state);
            }
        }

        [Test]
        public void Main()
        {
            var subject = new Subject();
            var Observer = new Observer(subject, "Center", "\t\t");
            var observer2 = new Observer(subject, "Right", "\t\t\t\t");
            subject.Go();
        }

        class Simulator : IEnumerable
        {
            string[] moves = {"5", "3", "1", "6", "7"};

            public IEnumerator GetEnumerator()
            {
                foreach (var element in moves)
                    yield return element;
            }
        }
    }
}