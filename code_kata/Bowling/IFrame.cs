namespace code_kata.Bowling
{
    public interface IFrame
    {
        void Throw(int pins);
        int PinsDown { get; }
        bool IsComplete { get; }
        int FirstThrow { get; }
        int SecondThrow { get; }
        bool IsStrike { get; }
        bool IsSpare { get; }
        bool IsLastFrame { get; }
    }
}