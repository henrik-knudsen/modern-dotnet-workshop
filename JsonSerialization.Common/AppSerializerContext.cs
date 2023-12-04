using System.Text.Json.Serialization;

namespace JsonSerialization.Common;


[JsonSerializable(typeof(List<User>), GenerationMode = JsonSourceGenerationMode.Serialization)]
public partial class AppSerializerContext : JsonSerializerContext
{
    
}


