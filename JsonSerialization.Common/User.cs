namespace JsonSerialization;

public class User
{
    public int Id { get; set; }
    
    public string Name { get; set; }

    public string Description { get; set; }

    public int Age { get; set; }

    public DateTime BirthDateTime { get; set; }
    
    public List<Attribute> Attributes { get; set; }
}


public class Attribute
{

    public int Id { get; set; }
    
    public string Name  { get; set; }

    public Qualifier Qualifier { get; set; }
}



public enum Qualifier
{
    None,
    Disabled,
    Enabled
}

