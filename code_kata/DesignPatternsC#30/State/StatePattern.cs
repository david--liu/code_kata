using System;
using NUnit.Framework;

// State Pattern                               Judith Bishop  Oct 2007
// Shows two states with two operations, which themselves change the state
// Increments and decrements a counter in the context

interface IState
{
    int MoveUp(StateContext stateContext);
    int MoveDown(StateContext stateContext);
}

// State 1
class NormalState : IState
{
    public int MoveUp(StateContext stateContext)
    {
        stateContext.Counter += 2;
        return stateContext.Counter;
    }

    public int MoveDown(StateContext stateContext)
    {
        if (stateContext.Counter < StateContext.limit)
        {
            stateContext.State = new FastState();
            Console.Write("|| ");
        }
        stateContext.Counter -= 2;
        return stateContext.Counter;
    }
}

// State 2
class FastState : IState
{
    public int MoveUp(StateContext stateContext)
    {
        stateContext.Counter += 5;
        return stateContext.Counter;
    }

    public int MoveDown(StateContext stateContext)
    {
        if (stateContext.Counter < StateContext.limit)
        {
            stateContext.State = new NormalState();
            Console.Write("||");
        }
        stateContext.Counter -= 5;
        return stateContext.Counter;
    }
}

// Context
class StateContext
{
    public const int limit = 10;
    public IState State { get; set; }
    public int Counter = limit;

    public int Request(int n)
    {
        if (n == 2)
            return State.MoveUp(this);
        else
            return State.MoveDown(this);
    }
}

[TestFixture]
class StateTest
{
    // The user interface
    [Test]
    public void Main()
    {
        var stateContext = new StateContext();
        stateContext.State = new NormalState();
        var r = new Random(37);
        for (var i = 5; i <= 25; i++)
        {
            var command = r.Next(3);
            Console.Write(stateContext.Request(command) + " ");
        }
        Console.WriteLine();
    }
}