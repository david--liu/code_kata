using System;
using NUnit.Framework;

[TestFixture]
class ChainwithStatePattern
{
    // Chain of Responsibility Pattern    Judith Bishop  June 2007

    class Handler
    {
        Handler next;
        int id;
        public int Limit { get; set; }

        public Handler(int id, Handler handler)
        {
            this.id = id;
            Limit = id*1000;
            next = handler;
        }

        public string HandleRequest(int data)
        {
            if (data < Limit)
                return "Request for " + data + " handled at level " + id;
            else if (next != null)
                return next.HandleRequest(data);
            else return ("Request for " + data + " handled BY DEFAULT at level " + id);
        }
    }

    [Test]
    public void Main()
    {
        Handler start = null;
        for (var i = 5; i > 0; i--)
        {
            Console.WriteLine("Handler " + i + " deals up to a limit of " + i*1000);
            start = new Handler(i, start);
        }

        int[] a = {50, 2000, 1500, 10000, 175, 4500};
        foreach (var i in a)
            Console.WriteLine(start.HandleRequest(i));
    }
}