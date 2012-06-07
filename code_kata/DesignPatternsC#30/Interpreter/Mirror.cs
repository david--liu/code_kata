using System.Collections;
using System.Collections.Generic;
using System.Xml;

public class Mirror
{
    // Mirrors                          Hans Lombard  June 2006, revised Sept 2007
    // Based on Views and Views-2 by Nigel Horspool, Judith Bishop, and D-J Miller
    // A general-purpose interpreter for any .NET API
    // Reads XML and executes the methods it represents
    // This example assumes the Windows Form API only in the final line
    // where Application.Run is called

    private readonly Stack objectStack;
    private readonly List<Command> commands;

    public object CurrentObject
    {
        get { return objectStack.Peek(); }
    }

    public XmlTextReader Reader { get; set; }
    public object LastObject { get; set; }

    public Mirror(string spec)
    {
        objectStack = new Stack();
        objectStack.Push(null);

        // Register the commands
        commands = new List<Command>();
        commands.Add(new ElementCommand());
        commands.Add(new EndElementCommand());
        commands.Add(new AttributeCommand());

        Reader = new XmlTextReader(spec);
        while (Reader.Read())
        {
            InterpretCommands();

            var b = Reader.IsEmptyElement;
            if (Reader.HasAttributes)
            {
                for (var i = 0; i < Reader.AttributeCount; i++)
                {
                    Reader.MoveToAttribute(i);
                    InterpretCommands();
                }
            }
            if (b) Pop();
        }
    }

    public void InterpretCommands()
    {
        // Run through the commands and interpret
        foreach (var c in commands)
            c.Interpret(this);
    }

    public void Push(object o)
    {
        objectStack.Push(o);
    }

    public void Pop()
    {
        LastObject = objectStack.Pop();
    }

    public object Peek()
    {
        return objectStack.Peek();
    }
}