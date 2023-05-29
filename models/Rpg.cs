using System.Text.Json.Serialization;

namespace CmdApi.models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Rpg
    {
        Knight = 1,
        Mage = 2,
        Cleric = 3,
    }
}