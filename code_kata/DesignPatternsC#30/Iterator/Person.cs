class Person
{
    public Person() { }
    public string Name { get; set; }
    public int Birth { get; set; }

    public Person(string name, int birth)
    {
        Name = name;
        Birth = birth;
    }

    public override string ToString()
    {
        return ("[" + Name + ", " + Birth + "]");
    }
}