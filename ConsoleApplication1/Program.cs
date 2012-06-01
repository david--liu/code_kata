using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using code_kata.ConsoleInteraction;
using code_kata.TicTacToe;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            TicTacToe();
        }

        private static void TicTacToe()
        {
            var game = new TicTacToe();
            while (true)
            {
                Console.Out.WriteLine("Please make a move: x, y");
                var line = Console.ReadLine();
                var strings = line.Split(',');
                if(strings.Count() != 2)
                {
                    Console.Out.WriteLine("Invalid input!");
                    Console.Out.WriteLine();
                }

                try
                {
                    game.Mark(Convert.ToInt32(strings[0]), Convert.ToInt32(strings[1]));
                    game.Print(" | ");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }

                if(game.IsGameOver())
                {
                    Console.Out.WriteLine("New Game?");
                    var yes = Console.ReadLine();
                    if(yes.ToUpper() == "Y")
                        continue;
                    else
                    {
                        break;
                    }
                }
                
            }
        }

        private static void ConsoleInteraction()
        {
            new ConsoleInteraction(new MyConsole()).StartConsole();
        }
    }
}
