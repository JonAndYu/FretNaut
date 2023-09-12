using FretAPI.Models;

namespace FretAPI.Services
{
    public interface ITuningService
    {
        IEnumerable<string> Tuning(string name);
        IEnumerable<Tunings> TuningList();
    }
}