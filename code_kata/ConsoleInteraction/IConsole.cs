namespace code_kata.ConsoleInteraction
{
    public interface IConsole
    {
        void WriteLine(string line);
        string ReadLine();
        decimal ReadRadius();
        decimal ReadRectangleSideALength();
        decimal ReadRectangleSideBLength();
    }
}