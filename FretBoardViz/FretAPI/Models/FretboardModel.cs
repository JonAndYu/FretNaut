using System.Text.Json;
using System.Text.Json.Serialization;

namespace FretAPI.Models;

public class FretboardModel
{
    public string TuningValues { get; set; }

    // Use the [JsonIgnore] attribute to ignore this property when serializing to JSON
    [JsonIgnore]
    public List<string> NotesList
    {
        get
        {
            if (string.IsNullOrEmpty(Notes))
            {
                return new List<string>();
            }

            return JsonSerializer.Deserialize<List<string>>(Notes);
        }
        set
        {
            Notes = JsonSerializer.Serialize(value);
        }
    }

    // This property will be used for database storage and retrieval
    public string Notes { get; set; }
}
