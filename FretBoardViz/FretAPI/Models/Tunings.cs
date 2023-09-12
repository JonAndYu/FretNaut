using System.Collections.Generic;
using System.Text.Json.Serialization;
namespace FretAPI.Models;
public class Tunings
{
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    [JsonPropertyName("tuning")]
    public required List<string> Tuning { get; set; }

    [JsonPropertyName("instrument")]
    public required string Instrument { get; set; }
}
