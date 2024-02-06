using System.Text.Json.Serialization;

namespace api.Enumerates
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Clans
    {
        Random,
        Senju,
        Uchiha,
        Uzumaki,
        Hyuuga,
        Aburame,
        Sarutobi,
        Nara,
        Inuzuka,
        Akimichi,
        Yamanaka,
        Kaguya,
        Fuma
    }
}