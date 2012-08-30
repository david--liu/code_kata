public sealed class Singleton
{
    // Private Constructor
    Singleton()
    {
    }

    // Private object instantiated with private constructor
    static readonly Singleton instance = new Singleton();

    // Public static property to get the object
    public static Singleton Instance
    {
        get { return instance; }
    }
}