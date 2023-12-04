// See https://aka.ms/new-console-template for more information


var user = new User("Bob", "Lee");


Console.WriteLine(user.FullName);




public class User(string firstname, string lastname)
{
    public string FullName { get; } = $"{firstname} {lastname}";
}




#region TODO: readonly parameters


public interface IService
{
    public void Foo();
}

public class Service : IService
{
    public void Foo()
    {
        
    }
}


public class MyDiClass1(IService service)
{
    private readonly IService _service = service;
}




public class MyDiClass2(IService service)
{
    public void Bar()
    {
        // Can mutate the parameter, which will mutate the hidden private field. 
        // service is NOT readonly.
        
        service = new Service();
        
        service.Foo();
    }
}



#endregion
