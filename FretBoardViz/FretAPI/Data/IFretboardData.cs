using FretAPI.Models;

namespace FretAPI.Data;

public interface IFretboardData
{
    Task DeleteFretboard(string tuningValues);
    Task<FretboardModel> GetFretboard(string tuningValues);
    Task<IEnumerable<FretboardModel>> GetAllFretboards();
    Task InsertFretboard(FretboardModel fretboard);
}