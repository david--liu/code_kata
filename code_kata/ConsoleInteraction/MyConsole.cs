using System;

namespace code_kata.ConsoleInteraction
{
    public class MyConsole : IConsole
    {
        public void WriteLine(string line)
        {
            Console.Out.WriteLine(line);
        }

        public string ReadLine()
        {
            return Console.ReadLine();
        }

        public decimal ReadRadius()
        {
            return Convert.ToDecimal(Console.ReadLine());
        }

        public decimal ReadRectangleSideALength()
        {
            return Convert.ToDecimal(Console.ReadLine());
        }

        public decimal ReadRectangleSideBLength()
        {
            return Convert.ToDecimal(Console.ReadLine());
        }
    }
}