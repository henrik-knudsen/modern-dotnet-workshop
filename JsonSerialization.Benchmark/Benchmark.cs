using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace JsonSerialization;


[MemoryDiagnoser]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
[CategoriesColumn]
public class Benchmark
{

    private static readonly User User  = new User()
    {
        Id = 1113,
        Name = "Bob",
        Description = "Some freetext description.......",
        Age = 30,
        BirthDateTime = DateTime.Now,
        Attributes = new List<Attribute>()
        {
            new Attribute()
            {
                Id = 1,
                Name = "AttributeA",
                Qualifier = Qualifier.Enabled
            },
            new Attribute()
            {
                Id = 2,
                Name = "AttributeA",
                Qualifier = Qualifier.Disabled
            },
            new Attribute()
            {
                Id = 3,
                Name = "AttributeA",
                Qualifier = Qualifier.None
            }
        }
    };

    private static readonly List<User> Users10 = Enumerable.Repeat(User, 10).ToList();
    
    private static readonly List<User> Users1000 = Enumerable.Repeat(User, 1000).ToList();
    
    private static readonly List<User> Users100000 = Enumerable.Repeat(User, 100_000).ToList();
    
    
    
    // Newtonsoft

    [Benchmark(Baseline = true)]
    [BenchmarkCategory(nameof(Users10))]
    public string Serialize_Newtonsoft_Reflection_Users10() => JsonConvert.SerializeObject(Users10);
    
    [Benchmark(Baseline = true)]
    [BenchmarkCategory(nameof(Users1000))]
    public string Serialize_Newtonsoft_Reflection_Users1000() => JsonConvert.SerializeObject(Users1000);
    
    [Benchmark(Baseline = true)]
    [BenchmarkCategory(nameof(Users100000))]
    public string Serialize_Newtonsoft_Reflection_Users100000() => JsonConvert.SerializeObject(Users100000);
    
    
    // System.Text - Out of the box
    
    [Benchmark]
    [BenchmarkCategory(nameof(Users10))]
    public string Serialize_SystemText_Reflection_Users10() => JsonSerializer.Serialize(Users10);
    
    [Benchmark]
    [BenchmarkCategory(nameof(Users1000))]
    public string Serialize_SystemText_Reflection_Users1000() => JsonSerializer.Serialize(Users1000);
    
    [Benchmark]
    [BenchmarkCategory(nameof(Users100000))]
    public string Serialize_SystemText_Reflection_Users100000() => JsonSerializer.Serialize(Users100000);
    
    
    // System.Text - Source generated.
    
    [Benchmark]
    [BenchmarkCategory(nameof(Users10))]
    public string Serialize_SystemText_SourceGen_Optimized_Users10() => JsonSerializer.Serialize(Users10, Common.AppSerializerContext.Default.ListUser);
    
    [Benchmark]
    [BenchmarkCategory(nameof(Users1000))]
    public string Serialize_SystemText_SourceGen_Optimized_Users1000() => JsonSerializer.Serialize(Users1000, Common.AppSerializerContext.Default.ListUser);
    
    [Benchmark]
    [BenchmarkCategory(nameof(Users100000))]
    public string Serialize_SystemText_SourceGen_Optimized_Users100000() => JsonSerializer.Serialize(Users100000, Common.AppSerializerContext.Default.ListUser);
    

    
    
}