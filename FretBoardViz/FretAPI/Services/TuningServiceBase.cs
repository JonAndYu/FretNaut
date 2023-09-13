using FretAPI.Models;
using System.Text.Json;

namespace FretAPI.Services;
public abstract class TuningServiceBase : ITuningService
{
    private readonly ILogger<TuningServiceBase> _logger;
    protected abstract string Instrument { get; }

    public TuningServiceBase(ILogger<TuningServiceBase> logger)
    {
        _logger = logger;
    }

    public IEnumerable<string> Tuning(string name)
    {
        return LookupTuning(name);
    }

    public IEnumerable<Tunings> TuningList()
    {
        try
        {
            List<Tunings>? tuningSets = JsonSerializer.Deserialize<List<Tunings>>(File.ReadAllText("Tunings.json"));

            // Filter the list to include only specific instrument tunings
            var instrumentTunings = tuningSets.Where(tuning => tuning.Instrument == Instrument);

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

    private IEnumerable<string> LookupTuning(string name)
    {
        try
        {
            List<Tunings>? tuningSets = JsonSerializer.Deserialize<List<Tunings>>(File.ReadAllText("Tunings.json"));

            Tunings? tuning = tuningSets.FirstOrDefault(x => x.Name == name && x.Instrument == Instrument);

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