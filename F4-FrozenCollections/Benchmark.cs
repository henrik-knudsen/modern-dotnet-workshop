using System.Collections.Frozen;
using System.Text.Json;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;

namespace F4_FrozenCollections;


[MemoryDiagnoser]
public class Benchmark
{

    private static readonly Foo MyFoo = new ()
    {
        Id = 10111,
        Name = "Bar"
    };

    private static readonly Dictionary<int, Foo> Dictionary10000 = Enumerable.Range(0, 10_000).ToDictionary(k => k, _ => MyFoo);

    private static readonly FrozenDictionary<int, Foo> FrozenDictionary10000 = Dictionary10000.ToFrozenDictionary();



    [Benchmark]
    public Foo? TryGetValue_Dictionary()
    {
        Dictionary10000.TryGetValue(100, out var value);

        return value;
    }



    [Benchmark]
    public Foo? TryGetValue_FrozenDictionary()
    {
        FrozenDictionary10000.TryGetValue(100, out var value);

        return value;
    }
    
    
    

    
    
}



public class Foo
{
    public int Id { get; set; }

    public string Name { get; set; }
    
    
}