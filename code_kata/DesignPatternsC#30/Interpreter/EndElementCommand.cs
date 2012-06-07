using System.Xml;

public class EndElementCommand : Command
{
    public override void Interpret(Mirror context)
    {
        if (context.Reader.NodeType != XmlNodeType.EndElement) return;
        context.Pop();
    }
}