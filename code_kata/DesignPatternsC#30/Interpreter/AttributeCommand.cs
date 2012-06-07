using System;
using System.Xml;

public class AttributeCommand : Command
{
    public override void Interpret(Mirror context)
    {
        if (context.Reader.NodeType != XmlNodeType.Attribute) return;
        SetProperty(context.Peek(), context.Reader.Name, context.Reader.Value);
    }

    public void SetProperty(object o, string name, string val)
    {
        var type = o.GetType();
        var property = type.GetProperty(name);

        // Find an appropriate property to match the attribute name
        if (property.PropertyType.IsAssignableFrom(typeof (string)))
        {
            property.SetValue(o, val, null);
        }
        else if (property.PropertyType.IsSubclassOf(typeof (Enum)))
        {
            var ev = Enum.Parse(property.PropertyType, val, true);
            property.SetValue(o, ev, null);
        }
        else
        {
            var m = property.PropertyType.GetMethod("Parse", new[]
                                                                 {
                                                                     typeof (string)
                                                                 });
            var newval = m.Invoke(null /*static */, new object[] {val});
            property.SetValue(o, newval, null);
        }
    }
}