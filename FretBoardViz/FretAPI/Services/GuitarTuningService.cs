namespace FretAPI.Services;
public class GuitarTuningService : TuningServiceBase, IGuitarTuningService
{
    protected override string Instrument => "Guitar";
    public GuitarTuningService(ILogger<GuitarTuningService> logger) : base(logger) { }
}

