using System;
using System.Reflection;
using System.Windows.Forms;
using System.Xml;

public class ElementCommand : Command
{
    public override void Interpret(Mirror context)
    {
        if (context.Reader.NodeType != XmlNodeType.Element) return;
        var type = GetTypeOf(context.Reader.Name);
        if (type == null) return;
        var o = Activator.CreateInstance(type);

        if (context.Peek() != null)
            ((Control) context.Peek()).Controls.Add((Control) o);
        context.Push(o);
    }

    public Type GetTypeOf(string s)
    {
        var ns = "System.Windows.Forms";
        var asm = Assembly.Load("System.Windows.Forms, Version=2.0.0.0,Culture=neutral, PublicKeyToken=b77a5c561934e089");
        var type = asm.GetType(ns + "." + s);
        return type;
    }
}