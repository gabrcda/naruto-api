using System.Text.Json.Serialization;

namespace api.Enumerates
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Villages
    {
        Leaf,
        Sand,
        Rock,
        Song,
        Mist,
        Cloud,
        Rain,
        Grass,
        Waterfall

    }
}