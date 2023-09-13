using FretAPI.Models;
using System.Text.Json;

namespace FretAPI.Services;
public class BassTuningService : TuningServiceBase, IBassTuningService
{
    protected override string Instrument => "Bass";
    public BassTuningService(ILogger<BassTuningService> logger) : base(logger) { }

}
