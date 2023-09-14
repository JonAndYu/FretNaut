using FretAPI.Models;
namespace FretAPI.Data;

public interface ITuningsData
{
    Task DeleteTunings(global::System.Int32 id);
    Task<IEnumerable<TuningsModel>> GetTunings();
    Task<TuningsModel> GetTunings(global::System.Int32 id);
    Task InsertTunings(TuningsModel tune);
}