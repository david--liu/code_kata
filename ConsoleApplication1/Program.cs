using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using code_kata.ConsoleInteraction;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            new ConsoleInteraction(new MyConsole()).StartConsole();
        }
    }
}
