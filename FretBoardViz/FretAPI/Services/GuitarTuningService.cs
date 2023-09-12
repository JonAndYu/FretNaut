using FretAPI.Models;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace FretAPI.Services;
public class GuitarTuningService : ITuningService
{
    private readonly ILogger<GuitarTuningService> _logger;
    private string instrument = "Guitar";
    public GuitarTuningService(ILogger<GuitarTuningService> logger)
    {
        _logger = logger;
    }

    public IEnumerable<string> Tuning(string name)
    {
        return LookUpTuning(name, instrument);
    }

    public IEnumerable<Tunings> TuningList()
    {
        try
        {
            List<Tunings>? tuningSets = JsonSerializer
                .Deserialize<List<Tunings>>
                (
                    File.ReadAllText("Tunings.json")
                );

            // Filter the list to include only guitar tunings
            var guitarTunings = tuningSets.Where(tuning => tuning.Instrument == "Guitar");

            if (guitarTunings.Any())
            {
                return guitarTunings;
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

    private IEnumerable<string> LookUpTuning(string name, string instrument)
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

