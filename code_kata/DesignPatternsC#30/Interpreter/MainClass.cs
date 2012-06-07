using System.Windows.Forms;

// Handles an XML element. Creates a new object that reflects the XML
// element name.

// Handles an XML end element. Removes the element from the object stack.

// Applies attributes to the current object. The attributes reflect to the
// properties of the object.

public class MainClass
{
    public static void Main()
    {
        var m = new Mirror("calc_winforms.xml");
        Application.Run((Form) m.LastObject);
    }
}