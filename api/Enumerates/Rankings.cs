using System.Text.Json.Serialization;

namespace api.Enumerates
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Rankings
    {
        Kage,
        Jounin,
        Chunin,
        Genin,
        Academy
    }
}