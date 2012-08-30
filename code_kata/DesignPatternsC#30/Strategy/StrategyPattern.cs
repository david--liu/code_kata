using System;
using NUnit.Framework;

// Strategy Pattern              Judith Bishop  Oct 2007
// Shows two strategies and a random switch between them

// The Context
class StrategyContext
{
    // Context state
    public const int start = 5;
    public int Counter = 5;

    // Strategy aggregation
    IStrategy strategy = new Strategy1();

    // Algorithm invokes a strategy method
    public int Algorithm()
    {
        return strategy.Move(this);
    }

    // Changing strategies
    public void SwitchStrategy()
    {
        if (strategy is Strategy1)
            strategy = new Strategy2();
        else
            strategy = new Strategy1();
    }
}

// Strategy interface
interface IStrategy
{
    int Move(StrategyContext c);
}

// Strategy 1
class Strategy1 : IStrategy
{
    public int Move(StrategyContext c)
    {
        return ++c.Counter;
    }
}

// Strategy 2
class Strategy2 : IStrategy
{
    public int Move(StrategyContext c)
    {
        return --c.Counter;
    }
}

// Client
[TestFixture]
public class StrategyPatternTest
{
    [Test]
    public void Main()
    {
        var context = new StrategyContext();
        context.SwitchStrategy();
        var r = new Random(37);
        for (var i = StrategyContext.start; i <= StrategyContext.start + 15; i++)
        {
            if (r.Next(3) == 2)
            {
                Console.Write("|| ");
                context.SwitchStrategy();
            }
            Console.Write(context.Algorithm() + "  ");
        }
        Console.WriteLine();
    }
}