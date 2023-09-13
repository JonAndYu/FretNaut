using System.Text.Json;
using System.Text.Json.Serialization;

namespace FretAPI.Models
{
    public class FretboardModel
    {
        public required int TuningId { get; set; }

        // Use the [JsonIgnore] attribute to ignore this property when serializing to JSON
        [JsonIgnore]
        public List<string> FretboardList
        {
            get
            {
                if (string.IsNullOrEmpty(Fretboard))
                {
                    return new List<string>();
                }

                return JsonSerializer.Deserialize<List<string>>(Fretboard);
            }
            set
            {
                Fretboard = JsonSerializer.Serialize(value);
            }
        }

        // This property will be used for database storage and retrieval
        public string Fretboard { get; set; }
    }
}
