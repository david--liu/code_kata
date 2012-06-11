using System;
using Library;
using NUnit.Framework;

// Facade Pattern                 Judith Bishop  Dec 2006
// Sets up a library of three systems, accessed through a
// Facade of two operations
// Compile with
// csc /t:library /out:FacadeLib.dll Facade-Library.cs

namespace Library
{
    class SubsystemA
    {
        internal string A1()
        {
            return "Subsystem A, Method A1\n";
        }

        internal string A2()
        {
            return "Subsystem A, Method A2\n";
        }
    }

    class SubsystemB
    {
        internal string B1()
        {
            return "Subsystem B, Method B1\n";
        }
    }

    class SubsystemC
    {
        internal string C1()
        {
            return "Subsystem C, Method C1\n";
        }
    }
}

public static class Facade
{
    static SubsystemA a = new SubsystemA();
    static SubsystemB b = new SubsystemB();
    static SubsystemC c = new SubsystemC();

    public static void Operation1()
    {
        Console.WriteLine("Operation 1\n" +
            a.A1() +
                a.A2() +
                    b.B1());
    }

    public static void Operation2()
    {
        Console.WriteLine("Operation 2\n" +
            b.B1() +
                c.C1());
    }
}

// ============= Different compilation

// Compile with csc /r:FacadeLib.dll Facade-Main.cs
[TestFixture]
class FacadeClient
{
    [Test]
    public void Main()
    {
        Facade.Operation1();
        Facade.Operation2();
    }
}

/* Output

 Operation 1
 Subsystem A, Method A1
 Subsystem A, Method A2
 Subsystem B, Method B1

 Operation 2
 Subsystem B, Method B1
 Subsystem C, Method C1
 */