using FretAPI.Models;

namespace FretAPI.Services
{
    public interface ITuningsService
    {
        Task DeleteTunings(int id);
        Task<IEnumerable<TuningsModel>> GetAllTunings();
        Task<TuningsModel?> GetTunings(int id);
        Task InsertTunings(TuningsModel tuningsModel);
    }
}