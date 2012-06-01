using System;
using System.Linq;
using System.Text;
using code_kata.ConsoleInteraction;

namespace code_kata.TicTacToe
{
    public class TicTacToe
    {
        private readonly IPrintMessage printMessage;

        Step[][] board = new Step[3][]
                             {
                                 new Step[3]{new Step(), new Step(), new Step()}, 
                                 new Step[3]{new Step(), new Step(), new Step()}, 
                                 new Step[3]{new Step(), new Step(), new Step()}
                             };



        private string currentSymbol = "";


        public TicTacToe() : this(new MessagePrinter())
        {
        }

        private class MessagePrinter : IPrintMessage
        {
            public void Print(string message)
            {
                Console.Out.WriteLine(message);
            }
        }

        public TicTacToe(IPrintMessage printMessage)
        {
            this.printMessage = printMessage;
        }

        public void Mark(int row, int column)
        {
            if (!(row > 0 && row <= 3 && column > 0 && column <= 3) || board[row - 1][column - 1].Symbol != null || IsGameOver())
                throw new NotSupportedException();

            currentSymbol = currentSymbol == "X" ? "O" : "X";
            board[row - 1][column - 1].Symbol = currentSymbol;

            if(IsGameDraw())
            {
                printMessage.Print("Game is a draw!");
            }

            if (IsWinner("X"))
            {
                printMessage.Print("X is the winner!");
            }

            if (IsWinner("O"))
            {
                printMessage.Print("X is the winner!");
            }


            if(IsGameOver())
            {
                printMessage.Print("Game Over!");
            }
        }

        public bool IsNew
        {
            get{ return board.SelectMany(steps => steps).All(step => step.Symbol == null); }
        }

        private class Step
        {
            public string Symbol { get; set; }
        }

        public void StartNew()
        {
            foreach (var step  in board.SelectMany(steps => steps))
            {
                step.Symbol = null;
            }
        }

        public void Print(string splitter)
        {
            var builder = new StringBuilder();
            foreach (var rows in board)
            {
                builder.Append(rows[0].Symbol ?? " ");
                builder.Append(splitter);
                builder.Append(rows[1].Symbol ?? " ");
                builder.Append(splitter);
                builder.Append(rows[2].Symbol ?? " ");

                builder.Append("\n");
            }

            builder.Remove(builder.Length - 1, 1);

            printMessage.Print(builder.ToString());
        }

        public bool IsWinner(string symbol)
        {
            bool isWinner = false;

            isWinner = isWinner ||
                       (board[0][0].Symbol == symbol && board[1][1].Symbol == symbol && board[2][2].Symbol == symbol);

            isWinner = isWinner ||
                       (board[0][2].Symbol == symbol && board[1][1].Symbol == symbol && board[2][0].Symbol == symbol);

            for (int i = 0; i < 3; i++)
            {
                isWinner = isWinner ||
                    (board[i][0].Symbol == symbol && board[i][1].Symbol == symbol && board[i][2].Symbol == symbol);
                isWinner = isWinner ||
                    (board[0][i].Symbol == symbol && board[1][i].Symbol == symbol && board[2][i].Symbol == symbol);

            }

            return isWinner;
        }

        public bool IsGameOver()
        {
            return AllStepsTaken()
                || IsWinner("X")
                || IsWinner("O");
        }

        private bool AllStepsTaken()
        {
            return board.SelectMany(step => step).All(step => step.Symbol != null);
        }

        public bool IsGameDraw()
        {
            return AllStepsTaken() && !IsWinner("X") && !IsWinner("O");
        }
    }

    public interface IPrintMessage
    {
        void Print(string message);
    }
}