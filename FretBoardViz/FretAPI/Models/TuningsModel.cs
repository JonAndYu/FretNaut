using Microsoft.Extensions.Configuration.UserSecrets;
using System.Diagnostics.Metrics;
using System.Runtime.Intrinsics.X86;

namespace FretAPI.Models;

public class TuningsModel
{

    public required int TuningId { get; set; }
    public required string Name { get; set; }
    public required string Instrument { get; set; }
    public required string TuningValues { get; set; }
    public required int UserId {  get; set; }

}