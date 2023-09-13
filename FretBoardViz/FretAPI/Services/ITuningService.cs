using FretAPI.Models;

namespace FretAPI.Services
{
    public interface ITuningService
    {
        IEnumerable<string> Tuning(string name, string instrument);
        IEnumerable<Tunings> TuningList();
    }
}