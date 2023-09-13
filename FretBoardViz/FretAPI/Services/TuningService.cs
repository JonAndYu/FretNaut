using FretAPI.Models;
using System.Diagnostics.Metrics;
using System.Text.Json;

namespace FretAPI.Services;

public class TuningService
{
    private readonly ILogger<TuningService> _logger;

    public TuningService(ILogger<TuningService> logger)
    {
        _logger = logger;
    }

    /*public IEnumerable<string> Tuning(string name, string instrument)
    {
        return LookupTuning(name, instrument);
    }*/

   /* public IEnumerable<Tunings> TuningList()
    {
        try
        {
            List<Tunings>? tuningSets = JsonSerializer.Deserialize<List<Tunings>>(File.ReadAllText("Tunings.json"));

            // Filter the list to include only specific instrument tunings
            // var instrumentTunings = tuningSets.Where(tuning => tuning.Instrument == Instrument);
            var instrumentTunings = tuningSets;

            if (instrumentTunings.Any())
            {
                return instrumentTunings;
            }
            else
            {
                throw new NullReferenceException("The specified tuning was not found in the json file");
            }
        }
        catch (Exception ex)
        {
            _logger.LogError("Error looking up Tunings", ex);
            throw;
        }
    }

    private IEnumerable<string> LookupTuning(string name, string instrument)
    {
        try
        {
            List<Tunings>? tuningSets = JsonSerializer.Deserialize<List<Tunings>>(File.ReadAllText("Tunings.json"));

            Tunings? tuning = tuningSets.FirstOrDefault(x => x.Name == name && x.Instrument == instrument);

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
    }*/
}
