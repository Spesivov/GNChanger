using System.Text.Json.Serialization;
using System.Text.Json;

namespace TestFramework.Extensions
{
    public static class JsonExtension
    {
        private static readonly JsonSerializerOptions _options =
            new() { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull };

        public static void ExtractToJson<T>(this T obj, string fileName = "Blog") where T : class
        {
            using var fileStream = File.Create($"{fileName}.json");
            using var utf8JsonWriter = new Utf8JsonWriter(fileStream);
           
            JsonSerializer.Serialize(utf8JsonWriter, obj, _options);
        }
    }
}
