// See https://aka.ms/new-console-template for more information

using System.Net.Http.Json;

Console.WriteLine("Hello, World!");



public interface IMyApiClass
{
    static abstract string Path { get; }
}


public class Foo : IMyApiClass
{
    public static string Path => "foo";
}

public class Bar : IMyApiClass
{
    public static string Path => "bar";
}


public class MyApiClient
{

    private readonly HttpClient _httpClient;

    public MyApiClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }


    public async Task<List<T>> GetData<T>() where T : IMyApiClass
    {
        var path = $"https://localhost:5000/{T.Path}";

        var data = await _httpClient.GetFromJsonAsync<List<T>>(path);

        return data!;
    }
}







