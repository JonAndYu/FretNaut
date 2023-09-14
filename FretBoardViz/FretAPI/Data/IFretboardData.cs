using FretAPI.Models;

namespace FretAPI.Data;

public interface IFretboardData
{
    Task DeleteFretboard(global::System.Int32 id);
    Task<FretboardModel> GetFretboard(global::System.Int32 id);
    Task<IEnumerable<FretboardModel>> GetAllFretboards();
    Task InsertFretboard(FretboardModel fretboard);
}