using Microsoft.Extensions.Configuration.UserSecrets;
using System.Diagnostics.Metrics;
using System.Runtime.Intrinsics.X86;

namespace FretAPI.Models;

public class TuningsModel
{

    public int TuningId { get; set; }
    public string Name { get; set; }
    public string Instrument { get; set; }
    public string TuningValues { get; set; }
    public int UserId {  get; set; }

}