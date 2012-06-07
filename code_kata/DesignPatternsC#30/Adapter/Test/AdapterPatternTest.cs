using System;
using NUnit.Framework;

namespace code_kata.DesignPatterns.Adapter
{
    [TestFixture]
    public class AdapterPatternTest
    {
        [Test]
        public void Main()
        {
            var judith = new AdapterPattern.MyCoolBook("Judith");
            judith.Add("Hello world");

            var tom = new AdapterPattern.MyCoolBook("Tom");
            tom.Poke("Judith");
            tom.Add("Hey, We are on CoolBook");
            judith.Poke("Tom");
            Console.ReadLine();
        }
    }
}