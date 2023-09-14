using FretAPI.Models;

namespace FretAPI.Services
{
    public interface IFretboardService
    {
        Task DeleteFretboardById(int id);
        Task<IEnumerable<FretboardModel>> GetAllFretboards();
        Task<FretboardModel?> GetFretboardById(int id);
        Task InsertFretboard(FretboardModel fretboard);
    }
}