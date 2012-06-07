using System;
using System.Collections.Generic;
using System.Collections;
using System.Threading;
using System.Windows.Forms;
using System.Drawing;

public class ObserverPattern
{
    // Observer Pattern                          Judith Bishop  Sept 2007
    // Demonstrates blog updates. Observers can subscribe and unsubscribe
    // online through a GUI.
    // State type

    public delegate void Callback(Blogs blog);

    // The Subject runs in a thread and changes its state
    // independently by calling the Iterator
    // At each change, it notifies its Observers
    // The Callbacks are in a collection based on blogger name

    private class Subject
    {
        private readonly Dictionary<string, Callback> Notify = new Dictionary<string, Callback>();
        private readonly Simulator simulator = new Simulator();
        private const int speed = 4000;

        public void Go()
        {
            new Thread(Run).Start();
        }

        private void Run()
        {
            foreach (Blogs blog in simulator)
            {
                Register(blog.Name); // if necessary
                Notify[blog.Name](blog); // publish changes
                Thread.Sleep(speed); // milliseconds
            }
        }

        // Adds to the blogger list if unknown
        private void Register(string blogger)
        {
            if (!Notify.ContainsKey(blogger))
            {
                Notify[blogger] = delegate { };
            }
        }

        public void Attach(string blogger, Callback Update)
        {
            Register(blogger);
            Notify[blogger] += Update;
        }

        public void Detach(string blogger, Callback Update)
        {
            // Possible problem here
            Notify[blogger] -= Update;
        }
    }

    private class Interact : Form
    {
        public readonly TextBox wall;
        public readonly Button subscribeButton;
        public readonly Button unsubscribeButton;
        public readonly TextBox messageBox;
        private string name;

        public Interact(string name, EventHandler Input)
        {
            CheckForIllegalCrossThreadCalls = true;
            // wall must be first!
            this.name = name;
            wall = new TextBox();
            wall.Multiline = true;
            wall.Location = new Point(0, 30);
            wall.Width = 300;
            wall.Height = 200;
            wall.AcceptsReturn = true;
            wall.Dock = DockStyle.Fill;
            Text = name;
            Controls.Add(wall);

            // Panel must be second
            var p = new Panel();
            messageBox = new TextBox();
            messageBox.Width = 120;
            p.Controls.Add(messageBox);
            subscribeButton = new Button();
            subscribeButton.Left = messageBox.Width;
            subscribeButton.Text = "Subscribe";
            subscribeButton.Click += Input;
            p.Controls.Add(subscribeButton);
            unsubscribeButton = new Button();
            unsubscribeButton.Left = messageBox.Width + subscribeButton.Width;
            unsubscribeButton.Text = "Unsubscribe";
            unsubscribeButton.Click += Input;
            p.Controls.Add(unsubscribeButton);

            p.Height = subscribeButton.Height;
            p.Height = unsubscribeButton.Height;
            p.Dock = DockStyle.Top;
            Controls.Add(p);
        }

        public void Output(string message)
        {
            if (InvokeRequired)
                Invoke((MethodInvoker) delegate { Output(message); });
            else
            {
                wall.AppendText(message + "\r\n");
                Show();
            }
        }
    }

    // Useful if more observer types
    private interface IObserver
    {
        void Update(Blogs state);
    }

    private class Observer : IObserver
    {
        private string name;
        private readonly Subject blogs;
        private readonly Interact visuals;

        public Observer(Subject subject, string name)
        {
            blogs = subject;
            this.name = name;
            visuals = new Interact(name, Input);
            new Thread(delegate(object o) { Application.Run(visuals); }).Start(this);

            // Wait to load the GUI
            while (visuals == null || !visuals.IsHandleCreated)
            {
                Application.DoEvents();
                Thread.Sleep(100);
            }
            blogs.Attach("Jim", Update);
            blogs.Attach("Eric", Update);
            blogs.Attach("Judith", Update);
        }

        public void Input(object source, EventArgs e)
        {
            // Subscribe to the specified blogger
            if (source == visuals.subscribeButton)
            {
                blogs.Attach(visuals.messageBox.Text, Update);
                visuals.wall.AppendText("Subscribed to " + visuals.messageBox.Text + "\r\n");
            }
            else
                // Unsubscribe from the blogger
                if (source == visuals.unsubscribeButton)
                {
                    blogs.Detach(visuals.messageBox.Text, Update);
                    visuals.wall.AppendText("Unsubscribed from" + visuals.messageBox.Text + "\r\n");
                }
        }

        public void Update(Blogs blog)
        {
            visuals.Output("Blog from " + blog.Name + " on " + blog.Topic);
        }
    }

    // Iterator to supply the data
    private class Simulator : IEnumerable
    {
        private readonly Blogs[] bloggers = {
                                                new Blogs("Jim", "UML diagrams"),
                                                new Blogs("Eric", "Iterators"),
                                                new Blogs("Eric", "Extension Methods"),
                                                new Blogs("Judith", "Delegates"),
                                                new Blogs("Eric", "Type inference"),
                                                new Blogs("Jim", "Threads"),
                                                new Blogs("Eric", "Lamda expressions"),
                                                new Blogs("Judith", "Anonymous properties"),
                                                new Blogs("Eric", "Generic delegates"),
                                                new Blogs("Jim", "Efficiency")
                                            };

        public IEnumerator GetEnumerator()
        {
            foreach (var blog in bloggers)
                yield return blog;
        }
    }

    private static void Main()
    {
        var subject = new Subject();
        var Observer = new Observer(subject, "Thabo");
        var observer2 = new Observer(subject, "Ellen");
        subject.Go();
    }
}

public class Blogs
{
    public string Name { get; set; }
    public string Topic { get; set; }

    public Blogs(string name, string topic)
    {
        Name = name;
        Topic = topic;
    }
}