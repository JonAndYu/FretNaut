using FretAPI.Models;
using System.Text.Json;

namespace FretAPI.Services;
public class BaseTuningService : ITuningService
{
    private readonly ILogger<BaseTuningService> _logger;
    private string instrument = "Bass";

    public BaseTuningService(ILogger<BaseTuningService> logger)
    {
        _logger = logger;
    }

    public IEnumerable<string> Tuning(string name)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Tunings> TuningList()
    {
        throw new NotImplementedException();
    }

    private IEnumerable<string> LookupTuning(string name, string instruement)
    {
        try
        {
            List<Tunings>? tuningSets = JsonSerializer
                .Deserialize<List<Tunings>>
                (
                    File.ReadAllText("Tunings.json")
                );

            Tunings? tuning = tuningSets.First(x => x.Name == name && x.Instrument == instrument);

            if (tuning is null)
            {
                throw new NullReferenceException("The specified tuning was not found in the json file");
            }

            return tuning.Tuning;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error looking up Tunings", ex);
            throw;
        }
    } 
}
