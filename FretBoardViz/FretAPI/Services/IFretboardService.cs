using FretAPI.Models;

namespace FretAPI.Services
{
    public interface IFretboardService
    {
        Task DeleteFretboardById(string tuningValues);
        Task<IEnumerable<FretboardModel>> GetAllFretboards();
        Task<FretboardModel?> GetFretboardById(string tuningValues);
        Task InsertFretboard(FretboardModel fretboard);
    }
}