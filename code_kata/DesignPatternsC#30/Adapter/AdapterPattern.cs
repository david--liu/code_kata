using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;

// Adapter Pattern Example               Judith Bishop  Aug 2007
// Sets up a CoolBook
// This is D-J's as changed for the book
internal class AdapterPattern
{
    // class SpaceBookSystem {

    public delegate void InputEventHandler(object sender, EventArgs e, string s);

    // Adapter
    public class MyCoolBook : MyOpenBook
    {
        private static readonly SortedList<string, MyCoolBook> community =
            new SortedList<string, MyCoolBook>(100);

        private Interact visuals;

        public MyCoolBook(string name) : base(name)
        {
            // Create interact on the relevant thread, and start it!
            new Thread(delegate()
                           {
                               visuals = new Interact("CoolBook Beta");
                               visuals.InputEvent += OnInput;
                               visuals.FormClosed += OnFormClosed;
                               Application.Run(visuals);
                           }).Start();
            community[name] = this;
            while (visuals == null)
            {
                Application.DoEvents();
                Thread.Sleep(100);
            }

            Add("Welcome to CoolBook " + Name);
        }

        private void OnFormClosed(object sender, FormClosedEventArgs e)
        {
            community.Remove(Name);
        }

        private void OnInput(object sender, EventArgs e, string s)
        {
            Add("\r\n");
            Add(s, "Poked you");
        }

        public new void Poke(string who)
        {
            Add("\r\n");
            if (community.ContainsKey(who))
                community[who].Add(Name, "Poked you");
            else
                Add("Friend " + who + " is not part of the community");
        }

        public new void Add(string message)
        {
            visuals.Output(message);
        }

        public new void Add(string friend, string message)
        {
            if (community.ContainsKey(friend))
                community[friend].Add(Name + " : " + message);
            else
                Add("Friend " + friend + " is not part of the community");
        }
    }

    // New implementation (Adaptee)
    public class Interact : Form
    {
        public TextBox Wall { get; set; }
        public Button Poke { get; set; }

        public Interact()
        {
        }

        public Interact(string title)
        {
            CheckForIllegalCrossThreadCalls = true;
            Poke = new Button();
            Poke.Text = "Poke";
            Controls.Add(Poke);
            Poke.Click += Input;
            Wall = new TextBox();
            Wall.Multiline = true;
            Wall.Location = new Point(0, 30);
            Wall.Width = 300;
            Wall.Height = 200;
            Wall.AcceptsReturn = true;
            Text = title;
            Controls.Add(Wall);
        }

        public event InputEventHandler InputEvent;

        public void Input(object source, EventArgs e)
        {
            var who = Wall.SelectedText;
            if (InputEvent != null)
                InputEvent(this, EventArgs.Empty, who);
        }

        public void Output(string message)
        {
            if (InvokeRequired)
                Invoke((MethodInvoker) delegate { Output(message); });
            else
            {
                Wall.AppendText(message + "\r\n");
                Show();
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            // Remove the interact and CoolBook from the community here!
            base.OnFormClosed(e);
        }
    }

    // The RealSubject (Proxy pattern)
    // CANNOT CHANGE
    public class SpaceBook
    {
        private static readonly SortedList<string, SpaceBook> community =
            new SortedList<string, SpaceBook>(100);

        private string pages;
        private readonly string name;
        private string gap = "\n\t\t\t\t";

        public static bool Unique(string name)
        {
            return community.ContainsKey(name);
        }

        internal SpaceBook(string n)
        {
            name = n;
            community[n] = this;
        }

        internal string Add(string s)
        {
            pages += gap + s;
            return gap + "======== " + name + "'s SpaceBook =========\n" +
                   pages +
                   gap + "\n===================================";
        }

        internal string Add(string friend, string message)
        {
            return community[friend].Add(message);
        }

        internal void Poke(string who, string friend)
        {
            community[who].pages += gap + friend + " poked you";
        }
    }

    // Target (Adapter pattern)
    // CANNOT CHANGE
    public class MyOpenBook
    {
        private readonly SpaceBook myOpenBook;
        public string Name { get; set; }
        public static int Users { get; set; }

        public MyOpenBook(string n)
        {
            Name = n;
            Users++;
            myOpenBook = new SpaceBook(Name + "-" + Users);
        }

        public void Add(string message)
        {
            Console.WriteLine(myOpenBook.Add(message));
        }

        public void Add(string friend, string message)
        {
            Console.WriteLine(myOpenBook.Add(friend, Name + " : " + message));
        }

        public void Poke(string who)
        {
            myOpenBook.Poke(who, Name);
        }

        public void SuperPoke(string who, string what)
        {
            myOpenBook.Add(who, what + " you");
        }
    }

    //// }
    //// The Client

 
}