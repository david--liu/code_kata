namespace code_kata.ConsoleInteraction
{
    public class ConsoleInteraction
    {
        private IConsole console;

        public ConsoleInteraction(IConsole console)
        {
            this.console = console;
        }

        private void PrintFirstMessage()
        {
            console.WriteLine("Shape: (C)ircle or (R)ectangle?");
        }


    }

    public interface IConsole
    {
        void WriteLine(string line);
    }
}