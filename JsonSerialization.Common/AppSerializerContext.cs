using System.Text.Json.Serialization;

namespace JsonSerialization.Common;

[JsonSourceGenerationOptions(DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull)]
[JsonSerializable(typeof(List<User>),  GenerationMode = JsonSourceGenerationMode.Default)]
public partial class AppSerializerContext : JsonSerializerContext
{
    
}


